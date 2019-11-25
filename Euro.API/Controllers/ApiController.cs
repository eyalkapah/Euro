using Euro.API.Base;
using Euro.ContextDb.Models;
using Euro.Domain.ApiModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euro.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApiController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

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
            };

            var result = await _userManager.CreateAsync(user, userCredentials.Password);

            if (result.Succeeded)
            {
                // Generate an email verification code
                var emailVerificationCode = _userManager.GenerateEmailConfirmationTokenAsync(user);
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