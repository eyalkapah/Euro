using Euro.ContextDb.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Euro.API.Authentication
{
    public static class JwtTokenExtensionMethods
    {
        public static string GenerateJwtToken(this ApplicationUser user, JwtParameters parameters)
        {
            // Set claims
            var claims = new[]
            {
                // Unique ID for the token
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),

                // Fills out the HttpContext.User.Identity.Name value
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),

                // Add user Id so that UserManager.GetUserAsync can find the user based on Id
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            // Create the credentials used to generate the token
            var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(parameters.SecretKey)), SecurityAlgorithms.HmacSha256);

            // Generate the Jwt token
            var token = new JwtSecurityToken(
                issuer: parameters.Issuer,
                audience: parameters.Audience,
                claims: claims,
                signingCredentials: credentials,
                expires: DateTime.Now.AddMonths(3));

            // Return the generate token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}