namespace AMDb.Web.Models.Actors
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ActorInputModel
    {
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 4)]
        public string BirthName { get; set; }

        public DateTime? BirthDate { get; set; }

        [StringLength(50, MinimumLength = 4)]
        public string BirthPlace { get; set; }

        [Range(typeof(float), "0,5", "2,5", ConvertValueInInvariantCulture = true)]
        public float? Height { get; set; }

        [StringLength(1000, MinimumLength = 20)]
        public string Biography { get; set; }

        [Url]
        public string ImageUrl { get; set; }
    }
}
