using System.Text.Json.Serialization;

namespace Euro.Domain.ApiModels
{
    public class UserProfileDetailsApiModel
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("bio")]
        public string Bio { get; set; }
    }
}