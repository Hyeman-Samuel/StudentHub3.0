using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentHubApi1.Models;
using StudentHubApi1.Models.AuthModel;

namespace StudentHubApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> UserManager;
        public AuthController(UserManager<ApplicationUser> _userManager)
        {
            this.UserManager = _userManager;
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterModel RegisterModel)
        {
            if (RegisterModel != null)
            {
                var user = await CreateUser(RegisterModel);
                await UserManager.AddToRoleAsync(user, Roles.User);
                var token = await GenerateToken(user);
                return Ok(new
                {
                    User = user,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expires = token.ValidTo
                });
            }
            return null;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel loginModel)
        {
            var user = await UserManager.FindByNameAsync(loginModel.Username);
            if (user != null && await UserManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var token = await GenerateToken(user);
                return Ok(new
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expires = token.ValidTo
                });
            }
            return Unauthorized();
        }




        ///Put this in user repository

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var Claims = new[]
                {
                            new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        };
            var roles = await UserManager.GetRolesAsync(user);
            if (roles != null)
            {
                foreach (var item in roles)
                {
                    var Role = new Claim(ClaimTypes.Role, item);
                    Claims.Append(Role);
                }
            }
            var SignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySuperSecureKey"));
            var Token = new JwtSecurityToken(
                issuer: "issue",
                audience: "audience",
                claims: Claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(SignInKey, SecurityAlgorithms.HmacSha256)
                );
            return Token;
        }

        private async Task<ApplicationUser> CreateUser(RegisterModel RegisterModel)
        {       
                ApplicationUser user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = RegisterModel.Email,
                    UserName = RegisterModel.UserName,
                    PhoneNumber = RegisterModel.PhoneNumber,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };
                await UserManager.CreateAsync(user, RegisterModel.Password);
                return user;
        }
    }
}