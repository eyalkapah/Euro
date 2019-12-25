using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euro.Shared.Out
{
    public class MatchResultApiModel
    {
        public int GuestScored { get; set; }

        public int GuestTeamId { get; set; }

        public int HostScored { get; set; }

        public int HostTeamId { get; set; }
        public int MatchId { get; set; }

        public DateTime PlayDateTime { get; set; }
    }
}