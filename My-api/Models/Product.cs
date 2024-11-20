using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace My_api.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string? Desc { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? ClientFile { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? category { get; set; }
       // public ICollection<Cart>? carts { get; set; }

    }
}

