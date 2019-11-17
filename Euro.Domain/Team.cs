using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Euro.Domain
{
    public class Team
    {
        public string FlagImage { get; set; }

        [NotMapped]
        public Group Group { get; set; }

        public int GroupId { get; set; }

        [NotMapped]
        public ICollection<Match> Matches { get; set; } = new HashSet<Match>();

        public string Name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }
    }
}