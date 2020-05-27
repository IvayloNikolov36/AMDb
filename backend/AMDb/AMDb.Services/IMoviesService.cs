namespace AMDb.Services
{
    using AMDb.DataModels.Enums;
    using System;
    using System.Threading.Tasks;

    public interface IMoviesService
    {
        Task<int?> Publish(string title, float duration, DateTime? releaseDate, Genre genre, string imageUrl);
    }
}
