using AutoMapper;
using Euro.Data;
using Euro.Data.Exceptiona;
using Euro.Domain;
using Euro.Domain.ApiModels;
using Euro.Domain.Interfaces.Repositories;
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
    public class GroupController : BaseController<Group, GroupApiModel>
    {
        public GroupController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            Repository = unitOfWork.Groups;
        }

        [HttpDelete("{id}")]
        public new Task<ActionResult> Delete(int id, CancellationToken token = default)
        {
            return base.Delete(id, token);
        }

        [HttpGet]
        [Produces(typeof(List<GroupApiModel>))]
        public new Task<ActionResult<IEnumerable<GroupApiModel>>> Get(CancellationToken token = default)
        {
            return base.Get(token);
        }

        [HttpGet("{id}", Name = "GetGroup")]
        [Produces(typeof(GroupApiModel))]
        public new Task<ActionResult<GroupApiModel>> Get(int id, CancellationToken token = default)
        {
            return base.Get(id, token);
        }

        [HttpGet("team/{id}")]
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
        public new async Task<ActionResult<GroupApiModel>> Post([FromBody] GroupApiModel input, CancellationToken token = default)
        {
            var output = await base.Post(input, token);

            if (output is OkObjectResult okResult)
            {
                return CreatedAtRoute("GetGroup", new { id = ((GroupApiModel)okResult.Value).GroupId }, okResult.Value);
            }

            return output;
        }

        [HttpPut("{id}")]
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