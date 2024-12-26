using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_api.Data;
using My_api.DTO;
using My_api.Models;

namespace My_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ImgAnimationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _host;

       

        public ImgAnimationsController(AppDbContext context, IWebHostEnvironment host)
        {
            _host = host;
            _context = context;
        }

        // GET: api/ImgAnimations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImgAnimation>>> GetimgAnimations()
        {
            var imganimation= await _context.imgAnimations.Select(p => new DTOImgAnimation
            {
                Id = p.Id,
                Imqge = "https://localhost:7196/images/"+p.Imqge

            }).ToListAsync();
            return Ok(imganimation);
        }

        // GET: api/ImgAnimations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImgAnimation>> GetImgAnimation(int id)
        {
            var imgAnimation = await _context.imgAnimations.FindAsync(id);

            if (imgAnimation == null)
            {
                return NotFound();
            }

            return Ok(new DTOImgAnimation { Id= imgAnimation.Id, Imqge = "https://localhost:7196/images/"+imgAnimation.Imqge });
        }

        // PUT: api/ImgAnimations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImgAnimation(int id, ImgAnimation imgAnimation)
        {
            if (id != imgAnimation.Id)
            {
                return BadRequest();
            }

            _context.Entry(imgAnimation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImgAnimationExists(id))
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

        // POST: api/ImgAnimations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImgAnimation>> PostImgAnimation(ImgAnimation imgAnimation)
        {
            if (imgAnimation.ClientFile != null)
            {
                var path = Path.Combine(_host.WebRootPath, "images");
                var fileName = imgAnimation.ClientFile.FileName;
                var fullPath = Path.Combine(path, fileName);
                imgAnimation.ClientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                imgAnimation.Imqge = fileName;
            }
            
           _context.imgAnimations.Add(imgAnimation);
            await _context.SaveChangesAsync();

            return Ok(imgAnimation);
        }

        // DELETE: api/ImgAnimations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImgAnimation(int id)
        {
            var imgAnimation = await _context.imgAnimations.FindAsync(id);
            if (imgAnimation == null)
            {
                return NotFound();
            }

            _context.imgAnimations.Remove(imgAnimation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImgAnimationExists(int id)
        {
            return _context.imgAnimations.Any(e => e.Id == id);
        }
    }
}
