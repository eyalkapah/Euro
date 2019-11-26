using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Euro.Domain.ApiModels
{
    public class RegisterCredentialsResultApiModel
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}