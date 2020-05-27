namespace AMDb.Web.Controllers
{
    using AMDb.Services;
    using AMDb.Web.Models.Movies;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class MoviesController : ApiController
    {
        private readonly IMoviesService movies;

        public MoviesController(IMoviesService movies)
        {
            this.movies = movies;
        }

        [HttpPost("publish")]
        [Authorize]
        public async Task<IActionResult> Publish([FromBody] MovieInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(new { Errors = this.ModelState.Values });
            }

            int? movieId = await this.movies.Publish(model.Title, model.Duration, model.ReleaseDate, model.Genre, model.ImageUrl);
            if (movieId == null)
            {
                return this.BadRequest(new { Message = "Not created!" });
            }

            return this.Ok(movieId);
        }
    }
}
