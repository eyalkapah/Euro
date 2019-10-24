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
    public class GroupController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GroupController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces(typeof(List<GroupApiModel>))]
        public async Task<ActionResult<IEnumerable<GroupApiModel>>> Get(CancellationToken token = default)
        {
            try
            {
                var groups = await _unitOfWork.Groups.GetAllGroupsAsync(token);

                var groupApiModels = _mapper.Map<IEnumerable<GroupApiModel>>(groups);

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
                var group = await _unitOfWork.Groups.GetGroupByIdAsync(id, token);

                if (group == null)
                {
                    return NotFound();
                }

                var groupApiModel = _mapper.Map<GroupApiModel>(group);

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
                    return BadRequest();

                if (!ModelState.IsValid)
                {
                    return new UnprocessableEntityObjectResult(ModelState);
                }

                var group = _mapper.Map<Group>(input);

                await _unitOfWork.Groups.AddGroupAsync(group, token);

                if (!await _unitOfWork.SaveAsync(token))
                {
                    throw new Exception("Failed to save group.");
                }

                return CreatedAtRoute("GetGroup", new { id = group.GroupId });
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
                    return BadRequest();

                if (await _unitOfWork.Groups.GetGroupByIdAsync(id) == null)
                    return NotFound();

                if (!ModelState.IsValid)
                {
                    return new UnprocessableEntityObjectResult(ModelState);
                }

                var group = _mapper.Map<Group>(input);

                group = await _unitOfWork.Groups.UpdateGroupAsync(id, group, token);

                if (!await _unitOfWork.SaveAsync(token))
                {
                    throw new Exception("Failed to save group.");
                }

                return CreatedAtRoute("GetGroup", new { id = group.GroupId });
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
                if (await _unitOfWork.Groups.GetGroupByIdAsync(id) == null)
                {
                    return NotFound();
                }

                _unitOfWork.Groups.Delete(id);

                if (!await _unitOfWork.SaveAsync(token))
                {
                    throw new Exception("Failed to save group.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}