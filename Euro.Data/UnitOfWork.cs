using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Euro.Context;
using Euro.Domain.Interfaces.Repositories;

namespace Euro.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EuroContext _context;

        public IGroupRepository Groups { get; set; }

        public UnitOfWork(EuroContext context, IGroupRepository groupRepository)
        {
            _context = context;

            Groups = groupRepository;
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}