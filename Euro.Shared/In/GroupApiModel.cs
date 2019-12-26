//using System.ComponentModel.DataAnnotations;

using System.Text.Json.Serialization;

namespace Euro.Shared.In
{
    public class GroupApiModel
    {
        [JsonPropertyName("is_group_level")]
        public bool IsGroupLevel { get; set; }

        //[MaxLength(1)]
        //[Required]

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}