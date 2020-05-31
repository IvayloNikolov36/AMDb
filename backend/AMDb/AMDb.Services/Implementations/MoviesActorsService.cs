namespace AMDb.Services.Implementations
{
    using AMDb.Data;
    using AMDb.DataModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class MoviesActorsService : DataService, IMoviesActorsService
    {
        public MoviesActorsService(AMDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddAsync(int movieId, Dictionary<int, string> actorsWithRoles)
        {
            foreach (var item in actorsWithRoles)
            {
                var movieActor = new MovieActor
                {
                    MovieId = movieId,
                    ActorId = item.Key,
                    Role = item.Value
                };

                await this.DbContext.AddAsync(movieActor);
            }

            await this.DbContext.SaveChangesAsync();
        }
    }
}
