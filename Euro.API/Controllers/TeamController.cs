using AutoMapper;
using Euro.Data;
using Euro.Domain;
using Euro.Shared;
using Euro.Shared.In;
using Euro.Shared.Out;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Euro.API.Controllers
{
    //[EnableCors("CorsPolicy")]

    //[ApiController]
    public class TeamController : BaseController<Team, TeamApiModel, TeamResultApiModel>
    {
        public TeamController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            Repository = unitOfWork.Teams;
        }

        [HttpDelete("{id}")]
        [Route(Routes.GetTeam)]
        public new Task<ActionResult> Delete(int id, CancellationToken token = default)
        {
            return base.Delete(id, token);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route(Routes.GetAllTeams)]
        [Produces(typeof(List<TeamApiModel>))]
        public new Task<ActionResult<IEnumerable<TeamResultApiModel>>> Get(CancellationToken token = default)
        {
            return base.Get(token);
        }

        [Route(Routes.GetTeam)]
        [HttpGet("{id}", Name = "GetTeam")]
        [Produces(typeof(TeamApiModel))]
        public new Task<ActionResult<TeamApiModel>> Get(int id, CancellationToken token = default)
        {
            return base.Get(id, token);
        }

        [Route(Routes.GetGroup)]
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
        [Route(Routes.GetTeam)]
        public new async Task<ActionResult<TeamApiModel>> Post([FromBody] TeamApiModel input, CancellationToken token = default)
        {
            var output = await base.Post<TeamResultApiModel>(input, token);

            if (output is OkObjectResult okResult)
            {
                return CreatedAtRoute("GetTeam", new { id = ((TeamResultApiModel)okResult.Value).TeamId }, okResult.Value);
            }

            return output;
        }

        [HttpPut("{id}")]
        [Route(Routes.GetTeam)]
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