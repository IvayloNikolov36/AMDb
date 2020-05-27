namespace AMDb.Web.Models.Identity.Register
{
    using System.Collections.Generic;

    public class RegisterResult
    {
        public bool Successful { get; set; }

        public string Message { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
