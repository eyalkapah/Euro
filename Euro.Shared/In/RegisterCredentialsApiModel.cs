using System.Text.Json.Serialization;

namespace Euro.Shared.In
{
    public class RegisterCredentialsApiModel
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}