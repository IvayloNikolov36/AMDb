namespace AMDb.Services.Implementations
{
    using AMDb.Data;

    public abstract class DataService
    {
        public DataService(AMDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public AMDbContext DbContext { get; }
    }
}
