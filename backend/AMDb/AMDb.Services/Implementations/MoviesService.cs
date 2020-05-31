namespace AMDb.Services.Implementations
{
    using AMDb.Data;
    using AMDb.DataModels;
    using AMDb.DataModels.Enums;
    using System;
    using System.Threading.Tasks;

    public class MoviesService : DataService, IMoviesService
    {
        public MoviesService(AMDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> Publish(string title, float duration, DateTime? releaseDate, Genre genre, string imageUrl)
        {            
            var movie = new Movie
            {
                Title = title,
                Duration = duration,
                Genre = genre,
                ReleaseDate = releaseDate,
                ImageUrl = imageUrl
            };

            await this.DbContext.AddAsync(movie);
            await this.DbContext.SaveChangesAsync();

            return movie.Id;
        }
    }
}
