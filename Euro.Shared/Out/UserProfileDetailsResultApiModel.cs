using System.Text.Json.Serialization;

namespace Euro.Shared.Out
{
    public class UserProfileDetailsResultApiModel
    {
        [JsonPropertyName("bio")]
        public string Bio { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
    }
}