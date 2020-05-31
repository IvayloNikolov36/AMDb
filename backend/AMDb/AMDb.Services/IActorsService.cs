namespace AMDb.Services
{
    using System;
    using System.Threading.Tasks;

    public interface IActorsService
    {
        Task<int> AddAsync(
            string name, string birthName, DateTime? birthDate, string BirthPlace, float? height, string biography);
    }
}
