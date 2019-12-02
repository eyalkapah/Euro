using Euro.Domain.ApiModels;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Euro.API.Base
{
    public class ApiResponse<T>
    {
        [JsonPropertyName("errors")]
        public List<ErrorApiModel> Errors { get; set; }

        [JsonPropertyName("is_succeeded")]
        public bool IsSucceeded => Errors == null;

        [JsonPropertyName("response")]
        public T Response { get; internal set; }
    }
}