using System;
using System.Text.Json.Serialization;

namespace Towiccho.Types.Routes.Twitch
{
    public class StreamChanged
    {
        [JsonPropertyName("data")]
        public StreamChangedData[] Data { get; set; }
    }

    public class StreamChangedData
    {
        [JsonPropertyName("id")]
        public string ID { get; set; }

        [JsonPropertyName("user_id")]
        public string UserID { get; set; }

        [JsonPropertyName("user_name")]
        public string Username { get; set; }

        [JsonPropertyName("game_id")]
        public string GameID { get; set; }

        [JsonPropertyName("community_ids")]
        public string[] CommunityIDs { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("viewer_count")]
        public int? ViewerCount { get; set; }

        [JsonPropertyName("started_at")]
        public DateTime StartedAt { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("thumbnail_url")]
        public Uri ThumbnailUrl { get; set; }
    }
}