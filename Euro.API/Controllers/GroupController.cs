using AutoMapper;
using Euro.Data;
using Euro.Domain;
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
    public class GroupController : BaseController
    {
        public GroupController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Produces(typeof(List<GroupApiModel>))]
        public async Task<ActionResult<IEnumerable<GroupApiModel>>> Get(CancellationToken token = default)
        {
            try
            {
                var groups = await UnitOfWork.Groups.GetAllGroupsAsync(token);

                var groupApiModels = Mapper.Map<IEnumerable<GroupApiModel>>(groups);

                return Ok(groupApiModels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{id}", Name = "GetGroup")]
        [Produces(typeof(GroupApiModel))]
        public async Task<ActionResult<GroupApiModel>> Get(int id, CancellationToken token = default)
        {
            try
            {
                var group = await UnitOfWork.Groups.GetGroupByIdAsync(id, token);

                if (group == null)
                {
                    return NotFound();
                }

                var groupApiModel = Mapper.Map<GroupApiModel>(group);

                return Ok(groupApiModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<GroupApiModel>> Post([FromBody] GroupApiModel input, CancellationToken token = default)
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

                var group = Mapper.Map<Group>(input);

                await UnitOfWork.Groups.AddGroupAsync(group, token);

                await SaveAsync(token);

                var output = Mapper.Map<GroupApiModel>(group);

                return CreatedAtRoute("GetGroup", new { id = group.GroupId }, output);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GroupApiModel>> Put(int id, [FromBody] GroupApiModel input, CancellationToken token = default)
        {
            try
            {
                if (input == null)
                {
                    return BadRequest();
                }

                if (await UnitOfWork.Groups.GetGroupByIdAsync(id) == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return new UnprocessableEntityObjectResult(ModelState);
                }

                var group = Mapper.Map<Group>(input);

                await UnitOfWork.Groups.UpdateGroupAsync(id, group, token);

                await SaveAsync(token);

                var output = Mapper.Map<GroupApiModel>(group);

                return CreatedAtRoute("GetGroup", new { id = group.GroupId }, output);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id, CancellationToken token = default)
        {
            try
            {
                if (await UnitOfWork.Groups.GetGroupByIdAsync(id) == null)
                {
                    return NotFound();
                }

                UnitOfWork.Groups.Delete(id);

                await SaveAsync(token);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}