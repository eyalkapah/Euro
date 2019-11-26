using Euro.API.Authentication;
using Euro.API.Base;
using Euro.ContextDb.Models;
using Euro.Domain.ApiModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [Route("api/register")]
        [HttpPost]
        public async Task<ApiResponse> Register([FromBody] RegisterCredentialsApiModel userCredentials)
        {
            var invalidErrorMessage = "Please provide all required details to register for an account.";

            var errorResponse = new ApiResponse
            {
                ErrorMessage = invalidErrorMessage
            };

            if (userCredentials == null)
            {
                return errorResponse;
            }

            if (!ModelState.IsValid)
            {
                return new ApiResponse
                {
                    ErrorMessage = ModelState.ToString()
                };
                //return new UnprocessableEntityObjectResult(ModelState);
            }

            var user = new ApplicationUser
            {
                Email = userCredentials?.Email,
                FirstName = userCredentials?.FirstName,
                LastName = userCredentials?.LastName,
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

                return new ApiResponse
                {
                    Response = new RegisterCredentialsResultApiModel
                    {
                        FirstName = userIdentity.FirstName,
                        LastName = userIdentity.LastName,
                        Email = userIdentity.Email,
                        Token = userIdentity.GenerateJwtToken(jwtParameters)
                    }
                };
            }
            else
            {
                return new ApiResponse
                {
                    ErrorMessage = result.Errors?.ToList().Select(f => f.Description).Aggregate((a, b) => $"{a}{Environment.NewLine}{b}")
                };
            }
            return null;
        }
    }
}