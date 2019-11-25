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

        public IActionResult Register([FromBody] RegisterCredentialsApiModel userCredentials)
        {
            var user = new ApplicationUser
            {
                Email = userCredentials?.Email,
                FirstName = userCredentials?.FirstName,
                LastName = userCredentials?.LastName,
            };

            // TODO: Get the UserManager<ApplicationUser>
            return null;
        }
    }
}