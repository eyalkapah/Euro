using Euro.Domain;
using Microsoft.EntityFrameworkCore;

namespace Euro.ContextDb.Seeders
{
    public static class GroupSeeder
    {
        public static void SeedGroups(this ModelBuilder builder)
        {
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 1,
                Name = "A",
                IsGroupLevel = true
            });
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 2,
                Name = "B",
                IsGroupLevel = true
            });
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 3,
                Name = "C",
                IsGroupLevel = true
            });
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 4,
                Name = "D",
                IsGroupLevel = true
            });
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 5,
                Name = "E",
                IsGroupLevel = true
            });
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 6,
                Name = "F",
                IsGroupLevel = true
            });
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 7,
                Name = "G",
                IsGroupLevel = true
            });
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 8,
                Name = "H",
                IsGroupLevel = true
            });
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 9,
                Name = "I",
                IsGroupLevel = true
            });
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 10,
                Name = "J",
                IsGroupLevel = true
            });
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 11,
                Name = "Round of 16"
            });
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 12,
                Name = "Quaterfinal"
            });
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 13,
                Name = "Semifinal"
            });
            builder.Entity<Group>().HasData(new Group
            {
                GroupId = 14,
                Name = "Final"
            });
        }
    }
}