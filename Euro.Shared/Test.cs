using System.IO.MemoryMappedFiles;
using System.Text;
using System.Text.Json.Serialization;

namespace Euro.Shared
{
    public class Test
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
    }
}