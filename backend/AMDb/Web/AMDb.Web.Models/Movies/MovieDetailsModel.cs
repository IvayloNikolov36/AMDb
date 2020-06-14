namespace AMDb.Web.Models.Movies
{
    using AMDb.DataModels;
    using AMDb.Services.Mapping;
    using AMDb.Web.Models.MovieActors;
    using System;
    using System.Collections.Generic;

    public class MovieDetailsModel : IMapFrom<Movie>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public float Duration { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string Genre { get; set; }

        public string SummaryText { get; set; }

        public string Storyline { get; set; }

        public string ImageUrl { get; set; }

        public string TrailerUrl { get; set; }

        public IEnumerable<MovieActorsModel> Cast { get; set; }
    }
}
