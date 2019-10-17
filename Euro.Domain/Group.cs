using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euro.Domain
{
    public class Group
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupId { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public ICollection<Team> Teams { get; set; } = new HashSet<Team>();
    }
}