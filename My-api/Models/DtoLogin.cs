using System.ComponentModel.DataAnnotations;

namespace My_api.Models
{
    public class DtoLogin
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
