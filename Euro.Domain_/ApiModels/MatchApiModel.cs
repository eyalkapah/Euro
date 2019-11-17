using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euro.Domain.ApiModels
{
    public class MatchApiModel
    {
        public int MatchId { get; set; }

        public DateTime PlayDateTime { get; set; }
        public int HostTeamId { get; set; }

        public int GuestTeamId { get; set; }

        [Required]
        public int HostScored { get; set; }

        [Required]
        public int GuestScored { get; set; }
    }
}