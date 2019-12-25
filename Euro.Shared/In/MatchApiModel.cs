using System;

namespace Euro.Domain.ApiModels
{
    public class MatchApiModel
    {
        public int GuestScored { get; set; }

        public int GuestTeamId { get; set; }

        public int HostScored { get; set; }

        public int HostTeamId { get; set; }

        public DateTime PlayDateTime { get; set; }
    }
}