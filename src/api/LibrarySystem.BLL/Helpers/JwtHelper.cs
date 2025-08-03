using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Enums;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibrarySystem.BLL.Helpers
{
  
    public static class JwtHelper
    {
        private static string SecretKey => ConfigurationManager.AppSettings["JwtSecretKey"];

        public static string GenerateToken(AuthenticatedUserDto user, int expireMinutes = 300)
        {
            var claims = new[]
            {
                new Claim("UID", user.UID.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber ?? ""),
                new Claim(ClaimTypes.Role, user.UserLevel.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expireMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static AuthenticatedUserDto ValidateToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(SecretKey);

                var validationParams = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero
                };

                var principal = tokenHandler.ValidateToken(token, validationParams, out _);

                string roleValue = principal.FindFirst(ClaimTypes.Role)?.Value;

                UserLevelEnum userLevel;
                if (!Enum.TryParse(roleValue, out userLevel))
                {
                    userLevel = UserLevelEnum.Student; // default fallback
                }

                return new AuthenticatedUserDto
                {
                    UID = int.Parse(principal.FindFirst("UID")?.Value ?? "-1"),
                    UserName = principal.FindFirst(ClaimTypes.Name)?.Value,
                    Email = principal.FindFirst(ClaimTypes.Email)?.Value,
                    PhoneNumber = principal.FindFirst(ClaimTypes.MobilePhone)?.Value,
                    UserLevel = userLevel,
                };
            }
            catch
            {
                return null;
            }
        }
    }
}