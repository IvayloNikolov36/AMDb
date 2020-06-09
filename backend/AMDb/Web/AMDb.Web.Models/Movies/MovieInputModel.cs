namespace AMDb.Web.Models.Movies
{
    using AMDb.DataModels.Enums;
    using AMDb.Web.Models.MovieActors;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class MovieInputModel
    {
        public MovieInputModel()
        {
            this.Actors = new List<MovieActorsInputModel>();
        }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; }

        public float Duration { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 50)]
        public string SummaryText { get; set; }

        [Required]
        [StringLength(600, MinimumLength = 200)]
        public string Storyline { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Url]
        public string TrailerUrl { get; set; }

        public IList<MovieActorsInputModel> Actors { get; set; }
    }
}
