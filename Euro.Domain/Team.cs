using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Euro.Domain
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public Group Group { get; set; }

        public int GroupId { get; set; }
        public ICollection<Match> Matches { get; set; } = new HashSet<Match>();
        public bool IsHostTeam { get; set; }
    }
}