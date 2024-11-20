using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_api.Data;
using My_api.Models;

namespace My_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class CartsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CartsController(AppDbContext context)
        {
            _context=context;
        }
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var cart =await _context.carts.ToListAsync();
            return Ok(cart);
        }
        [HttpPost]
        public async Task<IActionResult> Cart(Cart cart)
        {
            if (cart != null) 
            {
               await _context.carts.AddAsync(cart);
               await _context.SaveChangesAsync();
                return Ok(cart);

            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var cart = await _context.carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.carts.Remove(cart);
            await _context.SaveChangesAsync();

            return Ok(cart);
        }
    }
}
