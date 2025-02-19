using Microsoft.AspNetCore.Identity;
using SWECVI.ApplicationCore.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using SWECVI.ApplicationCore.Interfaces;
using SWECVI.ApplicationCore.Entities;
using SWECVI.ApplicationCore.Interfaces.Services;

namespace SWECVI.ApplicationCore.DomainServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;



        public AuthenticationService(IUserRepository userRepo, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration)
        {
            _userRepo = userRepo;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<LoginDto.LoginResult> Login(LoginDto.Login model)
        {
            var appUser = _userManager.Users.FirstOrDefault(r => r.UserName == model.Email || r.Email == model.Email);
            
            if (appUser == null)
            {
                throw new Exception("Credentials invalid");
            }

            if (appUser.UserName == null)
            {
                throw new Exception("User name is null");
            }

            var result = await _signInManager.PasswordSignInAsync(appUser.UserName, model.Password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userRepo.Get(u => u.IdentityId == appUser.Id);

                if (user == null)
                {
                    throw new Exception("Credentials invalid");
                }

                

                if (user.IsActive == false)
                {
                    throw new Exception("User is inactive");
                }

                string token = await GenerateJwtToken(model.Email,appUser, null);


                return new LoginDto.LoginResult(){
                    Token = token
                };
            }
            throw new Exception("Credentials invalid");
        }

        private async Task<string> GenerateJwtToken(string email,AppUser user, IList<string>? userRoles)
        {
            if (userRoles == null)
            {
                userRoles = await _userManager.GetRolesAsync(user);
            }

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, userRoles[0].ToString())
            };

            claims.AddRange(userRoles.Select(r => new Claim(ClaimTypes.Role, r)));

            var jwtKey = _configuration["JwtKey"] ?? string.Empty;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
