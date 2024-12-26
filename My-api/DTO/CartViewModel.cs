using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_api.DTO
{
    public class CartViewModel
    {
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [Required]
        public string UserId { get; set; }
        public short? State { get; set; }
        public int? Quantity { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;
    }
}
