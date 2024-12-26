using System.ComponentModel.DataAnnotations;

namespace My_api.Models
{
    public class DtoNewUser
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public List<string>? Roles { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
