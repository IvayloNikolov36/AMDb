namespace AMDb.Services.Implementations
{
    using AMDb.Data;
    using AMDb.DataModels;
    using AMDb.DataModels.Enums;
    using System;
    using System.Threading.Tasks;

    public class MoviesService : IMoviesService
    {
        private readonly AMDbContext db;

        public MoviesService(AMDbContext db)
        {
            this.db = db;
        }

        public async Task<int?> Publish(string title, float duration, DateTime? releaseDate, Genre genre, string imageUrl)
        {            
            var movie = new Movie
            {
                Title = title,
                Duration = duration,
                Genre = genre,
                ReleaseDate = releaseDate,
                ImageUrl = imageUrl
            };

            await this.db.AddAsync(movie);
            await this.db.SaveChangesAsync();

            return movie.Id;
        }
    }
}
