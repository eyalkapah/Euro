using Microsoft.EntityFrameworkCore;
using System;

namespace Euro.Context
{
    public class EuroContext : DbContext
    {
        public EuroContext(DbContextOptions options) : base(options)
        {
        }
    }
}