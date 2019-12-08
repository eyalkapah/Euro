using System.Text.Json.Serialization;

namespace Euro.Shared.In
{
    public class LoginCredentialsApiModel
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}