namespace AMDb.Web.Controllers.Identity
{
    using AMDb.DataModels;
    using AMDb.Web.Models.Identity.Login;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using static Infrastructure.ProjectConstants;

    public class LoginController : ApiController
    {
        private readonly IConfiguration configuration;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public LoginController(IConfiguration configuration,
                               SignInManager<User> signInManager,
                               UserManager<User> userManager)
        {
            this.configuration = configuration;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await signInManager
                .PasswordSignInAsync(userName: model.Username, model.Password, false, false);

            if (!result.Succeeded)
            {
                return this.BadRequest(new LoginResult { Message = InvalidUserNameAndPass });
            }

            var user = await this.userManager.FindByNameAsync(model.Username);
            var roles = await this.userManager.GetRolesAsync(user);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(configuration["Jwt:ExpiryInDays"]));

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            return this.Ok(new LoginResult
            {
                Message = LoginSuccess,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Username = user.UserName,
                Id = user.Id,
                Role = roles.Any() ? roles.First() : string.Empty,
            });
        }
    }
}
