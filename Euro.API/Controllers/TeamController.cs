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