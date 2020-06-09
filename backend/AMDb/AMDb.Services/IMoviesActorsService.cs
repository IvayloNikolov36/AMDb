namespace AMDb.Services
{
    using AMDb.Web.Models.MovieActors;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMoviesActorsService
    {
        Task AddAsync(int movieId, IList<MovieActorsInputModel> actorsWithRoles);

    }
}
