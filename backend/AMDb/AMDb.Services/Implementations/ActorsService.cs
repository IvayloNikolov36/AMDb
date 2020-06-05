namespace AMDb.Services.Implementations
{
    using AMDb.Data;
    using AMDb.DataModels;
    using AMDb.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ActorsService : DataService, IActorsService
    {
        public ActorsService(AMDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> AddAsync(
            string name, string birthName, DateTime? birthDate, string BirthPlace, 
            float? height, string biography, string imageUrl)
        {
            var actor = new Actor
            {
                Name = name,
                BirthName = birthName,
                BirthDate = birthDate,
                BirthPlace = BirthPlace,
                Height = height,
                Biography = biography,
                ImageUrl = imageUrl
            };

            await this.DbContext.AddAsync(actor);
            await this.DbContext.SaveChangesAsync();

            return actor.Id;
        }

        public async Task<List<T>> BornToday<T>()
        {
            var day = DateTime.Today.Day;
            var month = DateTime.Today.Month;

            return await this.DbContext.Actors.AsNoTracking()
                .Where(a => a.BirthDate.Value.Day == day && a.BirthDate.Value.Month == month)
                .OrderBy(a => a.Name)
                .To<T>()
                .ToListAsync();
        }
    }
}
