using Euro.Data;
using Euro.Domain.ApiModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Euro.API.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("CorsPolicy")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupApiModel>>> Get(CancellationToken token = default)
        {
            try
            {
                var apiModels = await _unitOfWork.Groups.GetAllGroupsAsync(token);

                return Ok(apiModels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}