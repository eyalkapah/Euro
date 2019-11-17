using System.ComponentModel.DataAnnotations;

namespace Euro.Domain.ApiModels
{
    public class GroupApiModel
    {
        public int GroupId { get; set; }

        [MaxLength(1)]
        [Required]
        public string Name { get; set; }
    }
}