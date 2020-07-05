using System.ComponentModel.DataAnnotations.Schema;

namespace API.Security
{
    [NotMapped]
    public class UserCredential
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AccessRule { get; set; }
    }
}
