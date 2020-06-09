namespace AMDb.Web.Controllers
{
    using AMDb.Services;
    using AMDb.Web.Models.MovieActors;
    using AMDb.Web.Models.Movies;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
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
                .Publish(m.Title, m.Duration, m.ReleaseDate, m.Genre, m.ImageUrl, m.TrailerUrl, m.Storyline, m.SummaryText);

            if (m.Actors.Count > 0)
            {
                await this.moviesActors.AddAsync(movieId, m.Actors);
            }

            return this.Ok(new { Id = movieId });
        }

        [HttpPost("movie/{id}/add-actors")]
        [Authorize]
        public async Task<IActionResult> AddActors(int id, [FromBody] IList<MovieActorsInputModel> m)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(new { Errors = this.ModelState.Values });
            }

            await this.moviesActors.AddAsync(movieId: id, actorsWithRoles: m);

            return this.NoContent();
        }

        [HttpGet("this-month")]
        public async Task<IActionResult> ThisMonth()
        {
            var thisMonthMovies = await this.movies
                .GetThisMonthMoviesAsync<MovieConciseViewModel>();

            return this.Ok(thisMonthMovies);
        }

        [HttpGet("all")]
        public async Task<IActionResult> All(int page = 1)
        {
            var movies = await this.movies
                .AllAsync<MovieListingViewModel>(page);

            return this.Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var movie = await this.movies.DetailsAsync<MovieDetailsModel>(id);
            if (movie == null)
            {
                return this.NotFound(new { Message = "Movie with such id is not existing!" });
            }

            return this.Ok(movie);
        }

    }
}
