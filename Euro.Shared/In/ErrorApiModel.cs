using System.Text.Json.Serialization;

namespace Euro.Shared.In
{
    public class ErrorApiModel
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}