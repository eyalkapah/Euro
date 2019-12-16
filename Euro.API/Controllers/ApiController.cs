using AutoMapper;
using Euro.API.Authentication;
using Euro.API.Extensions;
using Euro.ContextDb.Models;
using Euro.Shared;
using Euro.Shared.In;
using Euro.Shared.Out;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Euro.API.Controllers
{
    public class ApiController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApiController(UserManager<ApplicationUser> userManager, IConfiguration configuration, IMapper mapper, IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _configuration = configuration;
            _environment = environment;
        }

        [HttpGet]
        [Route(Routes.GetProfileImage)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> GetProfileImage()
        {
            var user = await GetCurrentUserAsync();

            // If we have no user...
            if (user == null)
                // Return error
                return Unauthorized("User not found");

            var path = $"{_environment.WebRootPath}\\uploads\\{user.Id}\\profile.jpg";

            if (!System.IO.File.Exists(path))
            {
                return NotFound();
            }

            var image = System.IO.File.OpenRead(path);

            return File(image, "image/jpeg");
        }

        [HttpPost]
        [Route(Routes.UploadImage)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Auth()
        {
            // Get user claims
            var user = await _userManager.GetUserAsync(HttpContext.User);

            // If we have no user return Unauthorized
            if (user == null)
                // Return error
                return Unauthorized();

            // Return ok
            return Ok();
        }

        [Route(Routes.GetUserProfile)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<GeneralApiResponse<UserProfileDetailsResultApiModel>>> GetUserProfile()
        {
            // Get user claims
            var user = await _userManager.GetUserAsync(HttpContext.User);

            // If we have no user...
            if (user == null)
                // Return error
                return new GeneralApiResponse<UserProfileDetailsResultApiModel>()
                {
                    // TODO: Localization
                    Error = "User not found"
                };

            // Return token to user
            return new GeneralApiResponse<UserProfileDetailsResultApiModel>
            {
                // Pass back the user details and the token
                Response = new UserProfileDetailsResultApiModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                }
            };
        }

        [Route(Routes.LogIn)]
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
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                }
            });
        }

        [Route(Routes.Register)]
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

        [Route(Routes.Test)]
        public ActionResult Test([FromBody] Test test)
        {
            return Ok(test);
        }

        [Route(Routes.UpdateUserProfile)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> UpdateProfileAsync([FromBody] UserProfileDetailsApiModel userProfile)
        {
            // Get user claims
            var user = await _userManager.GetUserAsync(HttpContext.User);

            // If we have no user return Unauthorized
            if (user == null)
                // Return error
                return Unauthorized();

            user.FirstName = userProfile.FirstName;
            user.LastName = userProfile.LastName;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok();
            }

            return StatusCode(500);
        }

        [HttpPost]
        [Route(Routes.UploadImage)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> UploadImage(IFormFile file)
        {
            var user = await GetCurrentUserAsync();

            // If we have no user...
            if (user == null)
                // Return error
                return Unauthorized("User not found");

            var extension = Path.GetExtension(file.FileName).ToLower();

            if (!extension.Equals(".png") && !extension.Equals(".bmp") && !extension.Equals(".jpg"))
                return BadRequest("Image format not allowed");

            if (file.Length > 0)
            {
                try
                {
                    var uploadFolder = $"{_environment.WebRootPath}\\uploads\\{user.Id}";
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    using var fileStream = System.IO.File.Create($"{uploadFolder}\\profile{Path.GetExtension(file.FileName)}");

                    await file.CopyToAsync(fileStream);

                    fileStream.Flush();

                    return Ok($"File successfully uploaded");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }

            return StatusCode(500, "Failure");
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}