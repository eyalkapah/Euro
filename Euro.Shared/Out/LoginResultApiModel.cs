using System.Text.Json.Serialization;

namespace Euro.Shared.Out
{
    public class LoginResultApiModel
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
    }
}