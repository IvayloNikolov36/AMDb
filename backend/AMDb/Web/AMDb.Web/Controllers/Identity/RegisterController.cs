namespace AMDb.Web.Controllers.Identity
{
    using AMDb.DataModels;
    using AMDb.Web.Models.Identity.Register;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;
    using static Infrastructure.ProjectConstants;

    public class RegisterController : ApiController
    {
        private readonly UserManager<User> userManager;

        public RegisterController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var newUser = new User
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await this.userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return BadRequest(new RegisterResult { Successful = false, Errors = errors });
            }

            return Ok(new RegisterResult { Successful = true, Message = RegisterSuccess });
        }
    }
}
