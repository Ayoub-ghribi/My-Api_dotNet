using Microsoft.AspNetCore.Identity;

namespace My_api.Models
{
    public class AppUser:IdentityUser
    {
        public ICollection<Cart>? carts { get; set; }
    }
}
