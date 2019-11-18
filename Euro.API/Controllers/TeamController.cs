using AutoMapper;
using Euro.Data;
using Euro.Domain;
using Euro.Domain.ApiModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Euro.API.Controllers
{
    [Route("api/[controller]")]
    //[EnableCors("CorsPolicy")]
    [ApiController]
    [Authorize]
    public class TeamController : BaseController<Team, TeamApiModel>
    {
        public TeamController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            Repository = unitOfWork.Teams;
        }

        [HttpDelete("{id}")]
        public new Task<ActionResult> Delete(int id, CancellationToken token = default)
        {
            return base.Delete(id, token);
        }

        [HttpGet]
        [AllowAnonymous]
        [Produces(typeof(List<TeamApiModel>))]
        public new Task<ActionResult<IEnumerable<TeamApiModel>>> Get(CancellationToken token = default)
        {
            return base.Get(token);
        }

        [HttpGet("{id}", Name = "GetTeam")]
        [Produces(typeof(TeamApiModel))]
        public new Task<ActionResult<TeamApiModel>> Get(int id, CancellationToken token = default)
        {
            return base.Get(id, token);
        }

        [HttpGet("group/{id}")]
        [Produces(typeof(List<TeamApiModel>))]
        public async Task<ActionResult<TeamApiModel>> GetByTeamId(int id, CancellationToken token = default)
        {
            try
            {
                var group = await UnitOfWork.Groups.GetByIdAsync(token, id);

                if (group == null)
                    return NotFound();

                var teams = await UnitOfWork.Teams.GetTeamsByGroupIdAsync(token, group.GroupId);

                var apiModel = Mapper.Map<IEnumerable<TeamApiModel>>(teams);

                return Ok(apiModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public new async Task<ActionResult<TeamApiModel>> Post([FromBody] TeamApiModel input, CancellationToken token = default)
        {
            var output = await base.Post(input, token);

            if (output is OkObjectResult okResult)
            {
                return CreatedAtRoute("GetTeam", new { id = ((TeamApiModel)okResult.Value).TeamId }, okResult.Value);
            }

            return output;
        }

        [HttpPut("{id}")]
        public new async Task<ActionResult<TeamApiModel>> Put(int id, [FromBody] TeamApiModel input, CancellationToken token = default)
        {
            var output = await base.Put(id, input, token);

            if (output is OkObjectResult okResult)
            {
                return CreatedAtRoute("GetTeam", new { id }, okResult.Value);
            }

            return output;
        }
    }
}