using System.ComponentModel.DataAnnotations;

namespace Euro.Domain.ApiModels
{
    public class TeamApiModel
    {
        [MaxLength(32)]
        public string FlagImage { get; set; }

        public int GroupId { get; set; }

        [Required]
        public string Name { get; set; }

        public int TeamId { get; set; }
    }
}