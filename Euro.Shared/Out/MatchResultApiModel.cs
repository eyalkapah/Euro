using System;
using System.Text.Json.Serialization;

namespace Euro.Shared.Out
{
    public class MatchResultApiModel
    {
        [JsonPropertyName("group_id")]
        public int GroupId { get; set; }

        [JsonPropertyName("guest_scored")]
        public int GuestScored { get; set; }

        [JsonPropertyName("guest_team_id")]
        public int GuestTeamId { get; set; }

        [JsonPropertyName("host_scored")]
        public int HostScored { get; set; }

        [JsonPropertyName("host_team_id")]
        public int HostTeamId { get; set; }

        [JsonPropertyName("match_id")]
        public int MatchId { get; set; }

        [JsonPropertyName("play_date_time")]
        public DateTime PlayDateTime { get; set; }
    }
}