using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_api.Models
{
    public class ImgAnimation
    {
        [Key]
        public int Id { get; set; }
        public string? Imqge { get; set; }
        [NotMapped]
        public IFormFile? ClientFile { get; set; }
    }
}
