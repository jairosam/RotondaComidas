using System.ComponentModel.DataAnnotations;

namespace APIRotonda.DTO.Users
{
    public class UserCredentials
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
