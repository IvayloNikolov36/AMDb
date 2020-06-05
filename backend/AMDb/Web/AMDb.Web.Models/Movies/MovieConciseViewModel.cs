namespace AMDb.Web.Models.Movies
{
    using AMDb.DataModels;
    using AMDb.Services.Mapping;

    public class MovieConciseViewModel : IMapFrom<Movie>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }
    }
}
