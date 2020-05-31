namespace AMDb.Web.Models.Movies
{
    using AMDb.DataModels.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class MovieInputModel
    {
        public MovieInputModel()
        {
            this.Actors = new Dictionary<int, string>();
        }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; }

        public float Duration { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        public Dictionary<int, string> Actors { get; set; }
    }
}
