namespace AMDb.Web.Models.Identity.Login
{
    using System.ComponentModel.DataAnnotations;

    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
