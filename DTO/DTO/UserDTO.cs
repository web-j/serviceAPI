using Commons.Enums;
using DTO.DTO.Base;

namespace DTO.DTO
{
    public class UserDTO : BaseDTO
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
