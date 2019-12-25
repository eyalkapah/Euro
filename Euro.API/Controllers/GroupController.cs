using AutoMapper;
using Euro.Data;
using Euro.Domain;
using Euro.Shared;
using Euro.Shared.In;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Euro.API.Controllers
{
    //[Route("api/[controller]")]
    //[EnableCors("CorsPolicy")]
    //[ApiController]
    public class GroupController : BaseController<Group, GroupApiModel, GroupResultApiModel>
    {
        public GroupController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            Repository = unitOfWork.Groups;
        }

        [HttpDelete("{id}")]
        [Route(Routes.Groups)]
        public new Task<ActionResult> Delete(int id, CancellationToken token = default)
        {
            return base.Delete(id, token);
        }

        [HttpGet]
        [Route(Routes.Groups)]
        [Produces(typeof(List<GroupApiModel>))]
        public new Task<ActionResult<IEnumerable<GroupResultApiModel>>> Get(CancellationToken token = default)
        {
            return base.Get(token);
        }

        [HttpGet("{id}", Name = "GetGroup")]
        [Route(Routes.Groups)]
        [Produces(typeof(GroupApiModel))]
        public new Task<ActionResult<GroupApiModel>> Get(int id, CancellationToken token = default)
        {
            return base.Get(id, token);
        }

        [HttpGet("team/{id}")]
        [Route(Routes.GetGroupByTeam)]
        [Produces(typeof(GroupApiModel))]
        public async Task<ActionResult<GroupApiModel>> GetByTeamId(int id, CancellationToken token = default)
        {
            try
            {
                var team = await UnitOfWork.Teams.GetByIdAsync(token, id);

                if (team == null)
                    return NotFound();

                var group = await Repository.GetByIdAsync(token, team.GroupId);

                var apiModel = Mapper.Map<GroupApiModel>(group);

                return Ok(apiModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route(Routes.Groups)]
        public new async Task<ActionResult<GroupApiModel>> Post([FromBody] GroupApiModel input, CancellationToken token = default)
        {
            var output = await base.Post<GroupResultApiModel>(input, token);

            if (output is OkObjectResult okResult)
            {
                return CreatedAtRoute("GetGroup", new { id = ((GroupResultApiModel)okResult.Value).GroupId }, okResult.Value);
            }

            return output;
        }

        [HttpPut("{id}")]
        [Route(Routes.Groups)]
        public new async Task<ActionResult<GroupApiModel>> Put(int id, [FromBody] GroupApiModel input, CancellationToken token = default)
        {
            var output = await base.Put(id, input, token);

            if (output is OkObjectResult okResult)
            {
                return CreatedAtRoute("GetGroup", new { id }, okResult.Value);
            }

            return output;
        }
    }
}