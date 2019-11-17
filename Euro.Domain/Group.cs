using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Euro.Domain
{
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupId { get; set; }

        [NotMapped]
        public ICollection<Match> Matches { get; set; } = new HashSet<Match>();

        public string Name { get; set; }

        [NotMapped]
        public ICollection<Team> Teams { get; set; } = new HashSet<Team>();
    }
}