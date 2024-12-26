using System.ComponentModel.DataAnnotations.Schema;

namespace My_api.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string? Desc { get; set; }
        public string? Image { get; set; }
       
        public DateTime? Date { get; set; } = DateTime.Now;
        public int? CategoryId { get; set; }

    }
}
