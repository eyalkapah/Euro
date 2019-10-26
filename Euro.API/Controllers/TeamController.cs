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
        public ITeamRepository<Team> Repository { get; }

        public TeamController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            Repository = unitOfWork.Teams;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id, CancellationToken token = default)
        {
            try
            {
                await Repository.DeleteAsync(token, id);

                await SaveAsync(token);

                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpGet]
        //[Produces(typeof(List<TeamApiModel>))]
        //public override async Task<ActionResult<IEnumerable<TeamApiModel>>> Get(CancellationToken token = default)
        //{
        //    try
        //    {
        //        var teams = await Repository.GetAllAsync(token);

        //        var apiModel = Mapper.Map<IEnumerable<TeamApiModel>>(teams);

        //        return Ok(apiModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex);
        //    }
        //}

        [HttpGet("{id}", Name = "GetById")]
        [Produces(typeof(TeamApiModel))]
        public async Task<ActionResult<TeamApiModel>> Get(int id, CancellationToken token = default)
        {
            try
            {
                var team = await Repository.GetByIdAsync(token, id);

                var apiModel = Mapper.Map<TeamApiModel>(team);

                return Ok(apiModel);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<TeamApiModel>> Post([FromBody] TeamApiModel input, CancellationToken token = default)
        {
            try
            {
                if (input == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return new UnprocessableEntityObjectResult(ModelState);
                }

                var team = Mapper.Map<Team>(input);

                await Repository.AddAsync(team, token);

                await SaveAsync(token);

                var output = Mapper.Map<TeamApiModel>(team);

                return CreatedAtRoute("GetById", new { id = team.TeamId }, output);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TeamApiModel>> Put(int id, [FromBody] TeamApiModel input, CancellationToken token = default)
        {
            try
            {
                if (input == null)
                {
                    return BadRequest();
                }

                var team = await Repository.GetByIdAsync(token, id);

                if (!ModelState.IsValid)
                {
                    return new UnprocessableEntityObjectResult(ModelState);
                }

                team = Mapper.Map(input, team);

                await Repository.UpdateAsync(team, token, id);

                await SaveAsync(token);

                var output = Mapper.Map<TeamApiModel>(team);

                return CreatedAtRoute("GetById", new { id = team.TeamId }, output);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}