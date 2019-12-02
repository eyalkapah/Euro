using System.Text.Json.Serialization;

namespace Euro.API.Base
{
    public class LoginApiResponse<T>
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("is_succeeded")]
        public bool IsSucceeded => Error == null;

        [JsonPropertyName("response")]
        public T Response { get; set; }
    }
}