namespace AMDb.Services.Implementations
{
    using AMDb.Data;
    using AMDb.DataModels;
    using AMDb.Web.Models.MovieActors;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MoviesActorsService : DataService, IMoviesActorsService
    {
        public MoviesActorsService(AMDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddAsync(int movieId, IList<MovieActorsInputModel> actorsWithRoles)
        {
            foreach (var item in actorsWithRoles)
            {
                var movieActor = new MovieActor
                {
                    MovieId = movieId,
                    ActorId = item.ActorId,
                    Role = item.Role
                };

                await this.DbContext.AddAsync(movieActor);
            }

            await this.DbContext.SaveChangesAsync();
        }
    }
}
