using Euro.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Euro.ContextDb.Seeders
{
    public static class MatchSeeder
    {
        public static void SeedMatches(this ModelBuilder builder)
        {
            builder.Entity<Match>().HasData(new Match
            {
                MatchId = 1,
                HostTeamId = 6,
                GuestTeamId = 7,
                HostScored = 3,
                GuestScored = 0,
                PlayDateTime = new DateTime(2019, 3, 21),
                GroupId = 9
            });
            builder.Entity<Match>().HasData(new Match
            {
                MatchId = 2,
                HostTeamId = 8,
                GuestTeamId = 9,
                HostScored = 5,
                GuestScored = 0,
                PlayDateTime = new DateTime(2019, 3, 21),
                GroupId = 9
            });
            builder.Entity<Match>().HasData(new Match
            {
                MatchId = 3,
                HostTeamId = 10,
                GuestTeamId = 11,
                HostScored = 2,
                GuestScored = 0,
                PlayDateTime = new DateTime(2019, 3, 21),
                GroupId = 3
            });
            builder.Entity<Match>().HasData(new Match
            {
                MatchId = 4,
                HostTeamId = 12,
                GuestTeamId = 13,
                HostScored = 4,
                GuestScored = 0,
                PlayDateTime = new DateTime(2019, 3, 21),
                GroupId = 3
            });
            builder.Entity<Match>().HasData(new Match
            {
                MatchId = 5,
                HostTeamId = 14,
                GuestTeamId = 15,
                HostScored = 2,
                GuestScored = 0,
                PlayDateTime = new DateTime(2019, 3, 21),
                GroupId = 5
            });
            builder.Entity<Match>().HasData(new Match
            {
                MatchId = 6,
                HostTeamId = 16,
                GuestTeamId = 17,
                HostScored = 2,
                GuestScored = 1,
                PlayDateTime = new DateTime(2019, 3, 21),
                GroupId = 5
            });
            builder.Entity<Match>().HasData(new Match
            {
                MatchId = 7,
                HostTeamId = 18,
                GuestTeamId = 19,
                HostScored = 1,
                GuestScored = 1,
                PlayDateTime = new DateTime(2019, 3, 21),
                GroupId = 7
            });
            builder.Entity<Match>().HasData(new Match
            {
                MatchId = 8,
                HostTeamId = 20,
                GuestTeamId = 21,
                HostScored = 3,
                GuestScored = 1,
                PlayDateTime = new DateTime(2019, 3, 21),
                GroupId = 7
            });
            builder.Entity<Match>().HasData(new Match
            {
                MatchId = 9,
                HostTeamId = 22,
                GuestTeamId = 23,
                HostScored = 0,
                GuestScored = 1,
                PlayDateTime = new DateTime(2019, 3, 21),
                GroupId = 3
            });
            builder.Entity<Match>().HasData(new Match
            {
                MatchId = 10,
                HostTeamId = 24,
                GuestTeamId = 25,
                HostScored = 3,
                GuestScored = 1,
                PlayDateTime = new DateTime(2019, 3, 21),
                GroupId = 9
            });
        }
    }
}