using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euro.Domain
{
    public class Match
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchId { get; set; }

        public DateTime PlayDateTime { get; set; }
        public int HostTeamId { get; set; }

        [NotMapped]
        public Team HostTeam { get; set; }

        public int GuestTeamId { get; set; }

        [NotMapped]
        public Team GuestTeam { get; set; }

        public int HostScored { get; set; }
        public int GuestScored { get; set; }
    }
}