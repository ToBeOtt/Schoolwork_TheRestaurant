using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TheRestaurant.Authentication.Interfaces;
using TheRestaurant.Domain.Entities.Authentication;

namespace TheRestaurant.Common.Infrastructure.Repositories.Authentication
{
    public class JwtTokenRepository : IJwtTokenRepository
    {
        private readonly IConfiguration _config;
        private readonly UserManager<AppUser> _userManager;

        public JwtTokenRepository(
            IConfiguration config,
            UserManager<AppUser> userManager)
        {
            _config = config;
            _userManager = userManager;
        }
        public async Task<string> GenerateToken(AppUser user)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);

            // Create claims for the user, including their ID and roles
            var claims = new List<Claim>
            {
                new Claim("UserId", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Aud, jwtSettings["Audience"]),
                new Claim(JwtRegisteredClaimNames.Iss, jwtSettings["Issuer"])
            };

            // Add Identity roles to claims
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2), // Set the token expiration time as needed
                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                // Set issuer, audience, etc. as needed
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<ClaimsPrincipal> ValidateToken(string token)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);

            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidateAudience = true,
                ValidAudience = jwtSettings["Audience"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero // Optional: set to zero for exact token expiration validation
            };

            try
            {
                var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out _);
                return claimsPrincipal;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
