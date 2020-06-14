namespace AMDb.Web.Models.MovieActors
{
    using System.ComponentModel.DataAnnotations;

    public class MovieActorsInputModel
    {
        public int ActorId { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string Role { get; set; }
    }
}
