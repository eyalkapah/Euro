using AutoMapper;
using Euro.Data;
using Euro.Domain;
using Euro.Domain.ApiModels;
using Euro.Shared;
using Euro.Shared.Out;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Euro.API.Controllers
{
    //[Route("api/[controller]")]
    //[EnableCors("CorsPolicy")]
    //[ApiController]
    public class MatchController : BaseController<Match, MatchApiModel, MatchResultApiModel>
    {
        public MatchController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            Repository = unitOfWork.Matches;
        }

        [HttpDelete("{id}")]
        [Route(Routes.Matches)]
        public new Task<ActionResult> Delete(int id, CancellationToken token = default)
        {
            return base.Delete(id, token);
        }

        [HttpGet]
        [Route(Routes.Matches)]
        [Produces(typeof(List<MatchApiModel>))]
        public new Task<ActionResult<IEnumerable<MatchResultApiModel>>> Get(CancellationToken token = default)
        {
            return base.Get(token);
        }

        [HttpGet("{id}", Name = "GetMatch")]
        [Route(Routes.Matches)]
        [Produces(typeof(MatchApiModel))]
        public new Task<ActionResult<MatchApiModel>> Get(int id, CancellationToken token = default)
        {
            return base.Get(id, token);
        }

        [HttpGet("team/{id}")]
        [Route(Routes.GetMatchByTeam)]
        [Produces(typeof(MatchApiModel))]
        public async Task<ActionResult<MatchApiModel>> GetByTeamId(int id, CancellationToken token = default)
        {
            try
            {
                var matches = await UnitOfWork.Matches.GetByTeamIdAsync(token, id);

                var apiModel = Mapper.Map<IEnumerable<MatchApiModel>>(matches);

                return Ok(apiModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route(Routes.Matches)]
        public new async Task<ActionResult<MatchApiModel>> Post([FromBody] MatchApiModel input, CancellationToken token = default)
        {
            var output = await base.Post<MatchResultApiModel>(input, token);

            if (output is OkObjectResult okResult)
            {
                return CreatedAtRoute("GetMatch", new { id = ((MatchResultApiModel)okResult.Value).MatchId }, okResult.Value);
            }

            return output;
        }

        [HttpPut("{id}")]
        [Route(Routes.Matches)]
        public new async Task<ActionResult<MatchApiModel>> Put(int id, [FromBody] MatchApiModel input, CancellationToken token = default)
        {
            var output = await base.Put(id, input, token);

            if (output is OkObjectResult okResult)
            {
                return CreatedAtRoute("GetMatch", new { id }, okResult.Value);
            }

            return output;
        }
    }
}