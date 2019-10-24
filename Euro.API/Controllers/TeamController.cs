using AutoMapper;
using Euro.Data;
using Euro.Domain;
using Euro.Domain.ApiModels;
using Microsoft.AspNetCore.Components;
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
    public class TeamController : BaseController<Team, TeamApiModel>
    {
        public TeamController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Produces(typeof(List<TeamApiModel>))]
        public override async Task<ActionResult<IEnumerable<TeamApiModel>>> Get(CancellationToken token = default)
        {
            try
            {
                var groups = await UnitOfWork.Teams.GetAllGroupsAsync(token);

                var groupApiModels = Mapper.Map<IEnumerable<GroupApiModel>>(groups);

                return Ok(groupApiModels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}