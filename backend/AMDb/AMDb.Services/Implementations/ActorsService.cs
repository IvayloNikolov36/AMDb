using AMDb.Data;
using AMDb.DataModels;
using System;
using System.Threading.Tasks;

namespace AMDb.Services.Implementations
{
    public class ActorsService : DataService, IActorsService
    {
        public ActorsService(AMDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> AddAsync(
            string name, string birthName, DateTime? birthDate, string BirthPlace, float? height, string biography)
        {
            var actor = new Actor
            {
                Name = name,
                BirthName = birthName,
                BirthDate = birthDate,
                BirthPlace = BirthPlace,
                Height = height,
                Biography = biography
            };

            await this.DbContext.AddAsync(actor);
            await this.DbContext.SaveChangesAsync();

            return actor.Id;
        }
    }
}
