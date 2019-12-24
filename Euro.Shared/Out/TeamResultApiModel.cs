using System.Text.Json.Serialization;

namespace Euro.Domain.ApiModels
{
    public class TeamResultApiModel
    {
        [JsonPropertyName("flag_image")]
        public string FlagImage { get; set; }

        [JsonPropertyName("group_id")]
        public int GroupId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("team_id")]
        public int TeamId { get; set; }
    }
}