using Commons.Enums;
using Domain.Models.Base;

namespace Domain.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Sirname { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public EAccessRule AccessRole { get; set; }
    }
}
