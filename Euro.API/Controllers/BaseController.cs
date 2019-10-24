using AutoMapper;
using Euro.Data;
using Euro.Domain.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Euro.API.Controllers
{
    public abstract class BaseController<TEntity, TEntityApiModel> : ControllerBase
    {
        public BaseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        protected async Task SaveAsync(CancellationToken token = default)
        {
            if (!await UnitOfWork.SaveAsync(token))
            {
                throw new Exception("Failed to save group.");
            }
        }

        public abstract Task<ActionResult<IEnumerable<TEntityApiModel>>> Get(CancellationToken token = default);

        public IUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }
    }
}