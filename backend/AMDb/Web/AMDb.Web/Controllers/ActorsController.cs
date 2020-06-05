namespace AMDb.Web.Controllers
{
    using AMDb.Services;
    using AMDb.Web.Models.Actors;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ActorsController : ApiController
    {
        private readonly IActorsService actors;

        public ActorsController(IActorsService actors)
        {
            this.actors = actors;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ActorInputModel m)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(new { Errors = this.ModelState.Values });
            }

            int actorId = await this.actors
                .AddAsync(m.Name, m.BirthName, m.BirthDate, m.BirthPlace, m.Height, m.Biography, m.ImageUrl);

            return this.Ok(new { Id = actorId });
        }  

        [HttpGet("born-today")]
        public async Task<IActionResult> BornToday()
        {
            var todayBorn = await this.actors.BornToday<ActorConciseViewModel>();

            return this.Ok(todayBorn);
        }

    }
}
