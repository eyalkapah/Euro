using Euro.Domain;
using Microsoft.EntityFrameworkCore;

namespace Euro.ContextDb.Migrations.Seeders
{
    public static class TeamSeeder
    {
        public static void SeedTeams(this ModelBuilder builder)
        {
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 1,
                Name = "England",
                GroupId = 1
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 2,
                Name = "Chech Republic",
                GroupId = 1
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 3,
                Name = "Bulgaria",
                GroupId = 1
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 4,
                Name = "Montenegro",
                GroupId = 1
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 5,
                Name = "Kosovo",
                GroupId = 1
            });

            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 6,
                Name = "Kazakhstan",
                GroupId = 9
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 7,
                Name = "Scotland",
                GroupId = 9
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 8,
                Name = "Cyprus",
                GroupId = 9
            }); builder.Entity<Team>().HasData(new Team
            {
                TeamId = 9,
                Name = "San Marino",
                GroupId = 9
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 10,
                Name = "Northern Ireland",
                GroupId = 3
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 11,
                Name = "Estonia",
                GroupId = 3
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 12,
                Name = "Netherlands",
                GroupId = 3
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 13,
                Name = "Belarus",
                GroupId = 3
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 14,
                Name = "Slovkia",
                GroupId = 5
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 15,
                Name = "Hungary",
                GroupId = 5
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 16,
                Name = "Croatia",
                GroupId = 5
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 17,
                Name = "Azerbaijan",
                GroupId = 5
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 18,
                Name = "Israel",
                GroupId = 7
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 19,
                Name = "Slovenia",
                GroupId = 7
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 20,
                Name = "North Macedonia",
                GroupId = 7
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 21,
                Name = "Latvia",
                GroupId = 7
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 22,
                Name = "Austria",
                GroupId = 7
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 23,
                Name = "Poland",
                GroupId = 7
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 24,
                Name = "Belgium",
                GroupId = 9
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 25,
                Name = "Russia",
                GroupId = 9
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 26,
                Name = "Portugal",
                GroupId = 2
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 27,
                Name = "Ukraine",
                GroupId = 2
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 28,
                Name = "Luxembourg",
                GroupId = 2
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 29,
                Name = "Lithuania",
                GroupId = 2
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 30,
                Name = "Moldova",
                GroupId = 8
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 31,
                Name = "France",
                GroupId = 8
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 32,
                Name = "Andora",
                GroupId = 8
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 33,
                Name = "Iceland",
                GroupId = 8
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 34,
                Name = "Albania",
                GroupId = 8
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 35,
                Name = "Turkey",
                GroupId = 8
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 36,
                Name = "Georgia",
                GroupId = 4
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 37,
                Name = "Switzerland",
                GroupId = 4
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 38,
                Name = "Gibraltar",
                GroupId = 4
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 39,
                Name = "Republic of Ireland",
                GroupId = 4
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 40,
                Name = "Sweden",
                GroupId = 6
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 41,
                Name = "Romania",
                GroupId = 6
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 42,
                Name = "Malta",
                GroupId = 6
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 43,
                Name = "Faroe Islands",
                GroupId = 6
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 44,
                Name = "Spain",
                GroupId = 6
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 45,
                Name = "Norway",
                GroupId = 6
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 46,
                Name = "Liechtenstein",
                GroupId = 10
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 47,
                Name = "Greece",
                GroupId = 10
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 48,
                Name = "Italy",
                GroupId = 10
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 49,
                Name = "Fineland",
                GroupId = 10
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 50,
                Name = "Bosnia and Herzegovina",
                GroupId = 10
            });
            builder.Entity<Team>().HasData(new Team
            {
                TeamId = 51,
                Name = "Armenia",
                GroupId = 10
            });
        }
    }
}