using System.Text.Json.Serialization;

namespace Euro.Domain.ApiModels
{
    public class RegisterCredentialsApiModel
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}