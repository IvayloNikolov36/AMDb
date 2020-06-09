namespace AMDb.Services.Implementations
{
    using AMDb.Data;
    using AMDb.DataModels;
    using AMDb.DataModels.Enums;
    using AMDb.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MoviesService : DataService, IMoviesService
    {
        public MoviesService(AMDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<T>> AllAsync<T>(int page)
        {
            return await this.DbContext.Movies.AsNoTracking()
                .Skip((page - 1) * 5)
                .Take(5)
                .To<T>()
                .ToListAsync();
        }

        public async Task<T> DetailsAsync<T>(int id)
        {
            return await this.DbContext.Movies.AsNoTracking()
                .Where(m => m.Id == id)
                .To<T>()
                .FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetThisMonthMoviesAsync<T>()
        {
            var today = DateTime.Today;
            return await this.DbContext.Movies.AsNoTracking()
                .Where(m => m.ReleaseDate.Value.Year == today.Year 
                    && m.ReleaseDate.Value.Month == today.Month)
                .OrderByDescending(m => m.CreatedOn)
                .To<T>()
                .ToListAsync();
        }

        public async Task<int> Publish(string title, float duration, DateTime? releaseDate, Genre genre,
            string imageUrl, string trailerUrl, string storyline, string summaryText)
        {            
            var movie = new Movie
            {
                Title = title,
                Duration = duration,
                Genre = genre,
                ReleaseDate = releaseDate,
                ImageUrl = imageUrl,
                TrailerUrl = trailerUrl,
                Storyline = storyline,
                SummaryText = summaryText
            };

            await this.DbContext.AddAsync(movie);
            await this.DbContext.SaveChangesAsync();

            return movie.Id;
        }

    }
}
