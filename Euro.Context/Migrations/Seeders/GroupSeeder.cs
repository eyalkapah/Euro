using Euro.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euro.Context.Migrations.Seeders
{
    public static class GroupSeeder
    {
        public static void SeedGroups(this ModelBuilder builder)
        {
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 1,
                Name = "A"
            });
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 2,
                Name = "B"
            });
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 3,
                Name = "C"
            });
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 4,
                Name = "D"
            });
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 5,
                Name = "E"
            });
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 6,
                Name = "F"
            });
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 7,
                Name = "G"
            });
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 8,
                Name = "H"
            });
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 9,
                Name = "I"
            });
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 10,
                Name = "J"
            });
        }
    }
}