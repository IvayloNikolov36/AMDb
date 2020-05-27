namespace AMDb.DataModels
{
    using AMDb.DataModels.Common;
    using AMDb.DataModels.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Movie : BaseModel<int>
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; }

        public float Duration { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

    }
}
