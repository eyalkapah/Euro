using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Euro.Shared.Out
{
    public class UploadImageResultApiModel
    {
        [JsonPropertyName("image_path")]
        public string ImagePath { get; set; }
    }
}