namespace AMDb.Web.Models.MovieActors
{
    using AMDb.DataModels;
    using AMDb.Services.Mapping;

    public class MovieActorsModel : IMapFrom<MovieActor>
    {
        public int ActorId { get; set; }

        public string Role { get; set; }

        public string ActorName { get; set; }

    }
}
