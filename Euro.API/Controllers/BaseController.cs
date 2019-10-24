using AutoMapper;
using Euro.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Euro.API.Controllers
{
    public class BaseController : ControllerBase
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

        public IUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }
    }
}