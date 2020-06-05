namespace AMDb.Web.Models.Movies
{
    using AMDb.DataModels;
    using AMDb.Services.Mapping;
    using AutoMapper;
    using System;

    public class MovieListingViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string Genre { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Movie, MovieListingViewModel>()
                .ForMember(x => x.Genre, m => m.MapFrom(m => m.Genre.ToString()));
        }
    }
}
