using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Euro.Domain
{
    public class Match
    {
        [NotMapped]
        public Group Group { get; set; }

        public int GroupId { get; set; }

        public int GuestScored { get; set; }

        [NotMapped]
        public Team GuestTeam { get; set; }

        public int GuestTeamId { get; set; }

        public int HostScored { get; set; }

        [NotMapped]
        public Team HostTeam { get; set; }

        public int HostTeamId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchId { get; set; }

        public DateTime PlayDateTime { get; set; }
    }
}