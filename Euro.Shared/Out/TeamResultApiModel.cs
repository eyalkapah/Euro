using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Euro.Shared.Out
{
    public class TeamResultApiModel
    {
        [JsonPropertyName("flag_image")]
        public string FlagImage { get; set; }

        [JsonPropertyName("group_id")]
        public int GroupId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("team_id")]
        public int TeamId { get; set; }
    }
}