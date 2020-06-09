namespace AMDb.DataModels
{
    using AMDb.DataModels.Common;
    using AMDb.DataModels.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Movie : BaseModel<int>
    {
        public Movie()
        {
            this.Cast = new HashSet<MovieActor>();
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

        public ICollection<MovieActor> Cast { get; set; }

    }
}
