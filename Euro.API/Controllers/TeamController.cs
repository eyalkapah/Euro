using AutoMapper;
using Euro.Data;
using Euro.Domain;
using Euro.Domain.ApiModels;
using Euro.Shared;
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
    public class TeamController : BaseController<Team, TeamResultApiModel>
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
        [Produces(typeof(List<TeamResultApiModel>))]
        public new Task<ActionResult<IEnumerable<TeamResultApiModel>>> Get(CancellationToken token = default)
        {
            return base.Get(token);
        }

        [Route(Routes.GetTeam)]
        [HttpGet("{id}", Name = "GetTeam")]
        [Produces(typeof(TeamResultApiModel))]
        public new Task<ActionResult<TeamResultApiModel>> Get(int id, CancellationToken token = default)
        {
            return base.Get(id, token);
        }

        [Route(Routes.GetGroup)]
        [HttpGet("group/{id}")]
        [Produces(typeof(List<TeamResultApiModel>))]
        public async Task<ActionResult<TeamResultApiModel>> GetByTeamId(int id, CancellationToken token = default)
        {
            try
            {
                var group = await UnitOfWork.Groups.GetByIdAsync(token, id);

                if (group == null)
                    return NotFound();

                var teams = await UnitOfWork.Teams.GetTeamsByGroupIdAsync(token, group.GroupId);

                var apiModel = Mapper.Map<IEnumerable<TeamResultApiModel>>(teams);

                return Ok(apiModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route(Routes.GetTeam)]
        public new async Task<ActionResult<TeamResultApiModel>> Post([FromBody] TeamResultApiModel input, CancellationToken token = default)
        {
            var output = await base.Post(input, token);

            if (output is OkObjectResult okResult)
            {
                return CreatedAtRoute("GetTeam", new { id = ((TeamResultApiModel)okResult.Value).TeamId }, okResult.Value);
            }

            return output;
        }

        [HttpPut("{id}")]
        [Route(Routes.GetTeam)]
        public new async Task<ActionResult<TeamResultApiModel>> Put(int id, [FromBody] TeamResultApiModel input, CancellationToken token = default)
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