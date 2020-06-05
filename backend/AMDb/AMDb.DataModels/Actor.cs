namespace AMDb.DataModels
{
    using AMDb.DataModels.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Actor : BaseModel<int>
    {
        public Actor()
        {
            this.Movies = new HashSet<MovieActor>();
        }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 4)]
        public string BirthName { get; set; }

        public DateTime? BirthDate { get; set; }

        [StringLength(50, MinimumLength = 4)]
        public string BirthPlace { get; set; }

        [Range(typeof(float), "0.5", "2.5")]
        public float? Height { get; set; }

        [StringLength(1000, MinimumLength = 20)]
        public string Biography { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<MovieActor> Movies { get; set; }
    }
}
