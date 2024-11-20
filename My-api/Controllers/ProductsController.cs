using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _host;

        public ProductsController(AppDbContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
        }

       
        [HttpGet]
        public async Task<ActionResult<Product>> GetProducts()
        {

            var product = await _context.products.ToListAsync();

           
                return Ok(product);
           
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
               var productId = await _context.products.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(productId);        
        }

        [HttpGet("FelterProducts/{id}")]
        public async Task<ActionResult<Product>> FelterProducts(int? id)
        {
            var product =await _context.products.Where(x => x.CategoryId == id).ToListAsync();
            if (product == null)
            {
                return NotFound($"Product id {id} has no items");
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (product.ClientFile != null) 
            { 
            var path = Path.Combine(_host.WebRootPath, "images");
            var fileName = product.ClientFile.FileName;
            var fullPath = Path.Combine(path, fileName);
            product.ClientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
            product.Image =fileName;
            }
            //
            _context.products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            var img = await _context.products.FindAsync(id);
            string nameimg = img.Image;
            
            string path = Path.Combine(_host.WebRootPath, "images" + nameimg);
            //var fileName = img.Image;
            //var fullPath = Path.Combine(path, fileName);
            System.IO.File.Delete(path);

           
                _context.products.Remove(img);
                await _context.SaveChangesAsync();
               
                    return Ok($"deletet :{img.Name}");
          
        }

        private bool ProductExists(int id)
        {
            return _context.products.Any(e => e.Id == id);
        }
    }
}
