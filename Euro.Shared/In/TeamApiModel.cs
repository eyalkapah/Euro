using System.Text.Json.Serialization;

namespace Euro.Shared.In
{
    public class TeamApiModel
    {
        [JsonPropertyName("flag_image")]
        public string FlagImage { get; set; }

        [JsonPropertyName("group_id")]
        public int GroupId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}