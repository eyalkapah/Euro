﻿using Euro.API.Authentication;
using Euro.API.Extensions;
using Euro.ContextDb.Models;
using Euro.Shared;
using Euro.Shared.In;
using Euro.Shared.Out;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Euro.API.Controllers
{
    public class ApiController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public ApiController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [Route("api/profile")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<GeneralApiResponse<UserProfileDetailsApiModel>>> GetUserProfile()
        {
            // Get user claims
            var user = await _userManager.GetUserAsync(HttpContext.User);

            // If we have no user...
            if (user == null)
                // Return error
                return new GeneralApiResponse<UserProfileDetailsApiModel>()
                {
                    // TODO: Localization
                    Error = "User not found"
                };

            // Return token to user
            return new GeneralApiResponse<UserProfileDetailsApiModel>
            {
                // Pass back the user details and the token
                Response = new UserProfileDetailsApiModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                }
            };
        }

        [Route("api/test")]
        public ActionResult Test([FromBody] Test test)
        {
            return Ok(test);
        }

        [Route("api/login")]
        public async Task<ActionResult<ApiResponse<LoginResultApiModel>>> LogIn([FromBody] LoginCredentialsApiModel loginCredentials)
        {
            var invalidErrorMessage = "Invalid username or password";

            var errorReposnse = new GeneralApiResponse<LoginResultApiModel>
            {
                Error = invalidErrorMessage
            };

            var user = await _userManager.FindByEmailAsync(loginCredentials.Username);

            if (user == null)
                return BadRequest(errorReposnse);

            var isValidPassword = await _userManager.CheckPasswordAsync(user, loginCredentials.Password);

            if (!isValidPassword)
                return BadRequest(errorReposnse);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(ClaimsIdentity.DefaultNameClaimType, loginCredentials.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            // Create the credentials
            var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])), SecurityAlgorithms.HmacSha256);

            // Generate the Jwt token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMonths(3),
                signingCredentials: credentials);

            return Ok(new GeneralApiResponse<LoginResultApiModel>
            {
                Response = new LoginResultApiModel
                {
                    Username = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                }
            });
        }

        [Route("api/register")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse<RegisterCredentialsResultApiModel>>> Register([FromBody] RegisterCredentialsApiModel userCredentials)
        {
            var user = new ApplicationUser
            {
                Email = userCredentials?.Email,
                UserName = userCredentials.Email
            };

            var result = await _userManager.CreateAsync(user, userCredentials.Password);

            if (result.Succeeded)
            {
                // Get the user details
                var userIdentity = await _userManager.FindByEmailAsync(user.Email);

                // Send verification code
                var emailVerificationCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var confirmationUrl = $"http://{Request.Host.Value}/api/verify/email/?userId={HttpUtility.UrlEncode(userIdentity.Id)}&emailToken={HttpUtility.UrlEncode(emailVerificationCode)}";

                // Send email

                // Read token parameters from the configuration file
                var jwtParameters = new JwtParameters
                {
                    SecretKey = _configuration["Jwt:Key"],
                    Audience = _configuration["Jwt:Audience"],
                    Issuer = _configuration["Jwt:Issuer"]
                };

                return Ok(new ApiResponse<RegisterCredentialsResultApiModel>
                {
                    Response = new RegisterCredentialsResultApiModel
                    {
                        FirstName = userIdentity.FirstName,
                        LastName = userIdentity.LastName,
                        Email = userIdentity.Email,
                        Token = userIdentity.GenerateJwtToken(jwtParameters)
                    }
                });
            }
            else
            {
                return BadRequest(new ApiResponse<RegisterCredentialsResultApiModel>
                {
                    Errors = result.Errors.ParseErrors()
                });
            }
        }
    }
}