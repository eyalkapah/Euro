using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euro.Domain.ApiModels
{
    public class TeamApiModel
    {
        public int GroupId { get; set; }

        [Required]
        public string Name { get; set; }

        public int TeamId { get; set; }

        [MaxLength(32)]
        public string FlagImage { get; set; }
    }
}