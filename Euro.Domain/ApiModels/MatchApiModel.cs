using System;
using System.ComponentModel.DataAnnotations;

namespace Euro.Domain.ApiModels
{
    public class MatchApiModel
    {
        [Required]
        public int GuestScored { get; set; }

        public int GuestTeamId { get; set; }

        [Required]
        public int HostScored { get; set; }

        public int HostTeamId { get; set; }
        public int MatchId { get; set; }

        public DateTime PlayDateTime { get; set; }
    }
}