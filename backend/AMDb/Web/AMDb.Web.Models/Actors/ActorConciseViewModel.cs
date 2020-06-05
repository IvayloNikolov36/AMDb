namespace AMDb.Web.Models.Actors
{
    using AMDb.DataModels;
    using AMDb.Services.Mapping;

    public class ActorConciseViewModel : IMapFrom<Actor>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }
    }
}
