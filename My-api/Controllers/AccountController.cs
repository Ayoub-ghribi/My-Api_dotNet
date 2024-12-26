using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using My_api.DTO;
using My_api.Migrations;
using My_api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace My_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<AppUser> _userManager, IConfiguration configuration)
        {
            userManager = _userManager;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> getUser()
        {

            return Ok(userManager.Users.ToListAsync());
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Resister(DtoNewUser user)
        {
            if (ModelState.IsValid)
            {
                
                AppUser appUser = new AppUser
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                };

                IdentityResult result = await userManager.CreateAsync(appUser, user.Password);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }
                 await  userManager.AddToRoleAsync(appUser, "User");
                

            }
            return Ok(new AuthResponseDTO
            {
                IsSuccess = true,
                Message = "Account craeted Successfully!"
            });
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(DtoLogin login)
        {
            if (ModelState.IsValid)
            {
                AppUser? user = await userManager.FindByEmailAsync(login.Email);
                if (user != null) 
                {
                    if (await userManager.CheckPasswordAsync(user, login.Password))
                    {
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                        var roles = await userManager.GetRolesAsync(user);
                        foreach (var role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                        }
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
                        var sc = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                         claims: claims,
                         issuer: _configuration["JWT:Issuer"],
                         audience: _configuration["JWT:Audience"],
                         expires: DateTime.Now.AddHours(1),
                         signingCredentials: sc
                            );
                        var _token = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        };
                        
                        var resualt = new{_token.token , user.UserName,user.Id};
                        return Ok(resualt);
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "user name is invalid");
                }
            }
            return BadRequest(ModelState);
        }
    }
}
