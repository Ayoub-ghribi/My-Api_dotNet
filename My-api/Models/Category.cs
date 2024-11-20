using System.ComponentModel.DataAnnotations;

namespace My_api.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Image { get; set; }
        public List<Product>? products { get; set; }
    }
}
