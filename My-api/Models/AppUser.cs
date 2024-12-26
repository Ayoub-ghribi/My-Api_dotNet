using Microsoft.AspNetCore.Identity;

namespace My_api.Models
{
    public class AppUser:IdentityUser
    {
        public List<string>? Roles { get; set; }
        public DateTime? expiration { get; set; } = DateTime.Now;
        public ICollection<Cart>? carts { get; set; }
    }
}
