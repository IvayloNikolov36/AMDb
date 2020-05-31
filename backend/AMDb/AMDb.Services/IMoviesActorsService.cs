namespace AMDb.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMoviesActorsService
    {
        Task AddAsync(int movieId, Dictionary<int, string> actorsWithRoles);
    }
}
