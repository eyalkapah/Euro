using AutoMapper;
using Euro.Data;
using Euro.Data.Exceptions;
using Euro.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Euro.API.Controllers
{
    public abstract class BaseController<TEntity, TEntityApiModel> : ControllerBase where TEntity : class
    {
        public IMapper Mapper { get; }

        public IBaseRepository<TEntity> Repository { get; set; }
        public IUnitOfWork UnitOfWork { get; }

        public BaseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

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

        public async Task<ActionResult<IEnumerable<TEntityApiModel>>> Get(CancellationToken token = default)
        {
            try
            {
                var entities = await Repository.GetAllAsync(token);

                var apiModels = Mapper.Map<IEnumerable<TEntityApiModel>>(entities);

                return Ok(apiModels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        public async Task<ActionResult<TEntityApiModel>> Get(int id, CancellationToken token = default)
        {
            try
            {
                var entity = await Repository.GetByIdAsync(token, id);

                var apiModel = Mapper.Map<TEntityApiModel>(entity);

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

        public async Task<ObjectResult> Post([FromBody] TEntityApiModel input, CancellationToken token = default)
        {
            try
            {
                if (input == null)
                {
                    return StatusCode(400, input);
                }

                if (!ModelState.IsValid)
                {
                    return new UnprocessableEntityObjectResult(ModelState);
                }

                var entity = Mapper.Map<TEntity>(input);

                await Repository.AddAsync(entity, token);

                await SaveAsync(token);

                var output = Mapper.Map<TEntityApiModel>(entity);

                return Ok(output);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public async Task<ObjectResult> Put(int id, [FromBody] TEntityApiModel input, CancellationToken token = default)
        {
            try
            {
                if (input == null)
                {
                    return StatusCode(400, input);
                }

                var entity = await Repository.GetByIdAsync(token, id);

                if (!ModelState.IsValid)
                {
                    return new UnprocessableEntityObjectResult(ModelState);
                }

                entity = Mapper.Map(input, entity);

                await Repository.UpdateAsync(entity, token, id);

                await SaveAsync(token);

                var output = Mapper.Map<TEntityApiModel>(entity);

                return Ok(output);
            }
            catch (NotFoundException)
            {
                return StatusCode(404, input);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        protected async Task SaveAsync(CancellationToken token = default)
        {
            if (!await UnitOfWork.SaveAsync(token))
            {
                throw new Exception("Failed to save group.");
            }
        }
    }
}