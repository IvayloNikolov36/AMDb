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
        private readonly IMoviesActorsService moviesActors;

        public MoviesController(IMoviesService movies, IMoviesActorsService moviesActors)
        {
            this.movies = movies;
            this.moviesActors = moviesActors;
        }

        [HttpPost("publish")]
        [Authorize]
        public async Task<IActionResult> Publish([FromBody] MovieInputModel m)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(new { Errors = this.ModelState.Values });
            }

            int movieId = await this.movies
                .Publish(m.Title, m.Duration, m.ReleaseDate, m.Genre, m.ImageUrl);

            if (m.Actors.Count > 0)
            {
                await this.moviesActors.AddAsync(movieId, m.Actors);
            }

            return this.Ok(new { Id = movieId });
        }
    }
}
