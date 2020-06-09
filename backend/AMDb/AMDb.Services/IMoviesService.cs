namespace AMDb.Services
{
    using AMDb.DataModels.Enums;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMoviesService
    {
        Task<int> Publish(string title, float duration, DateTime? releaseDate, 
            Genre genre, string imageUrl, string trailerUrl, string storyline, string summaryText);

        Task<List<T>> GetThisMonthMoviesAsync<T>();

        Task<List<T>> AllAsync<T>(int page);

        Task<T> DetailsAsync<T>(int id);
    }
}
