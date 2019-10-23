using AutoMapper;
using Euro.Data;
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
                var apiModels = await _unitOfWork.Groups.GetAllGroupsAsync(token);

                return Ok(apiModels);
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

                return Ok(group);
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

                var group = await _unitOfWork.Groups.AddGroupAsync(input, token);

                if (!await _unitOfWork.SaveAsync(token))
                {
                    throw new Exception("Failed to save group.");
                }

                var groupApiModel = _mapper.Map<GroupApiModel>(group);

                return CreatedAtRoute("GetGroup", new { groupId = group.GroupId }, groupApiModel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}