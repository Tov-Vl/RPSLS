using RpslsServer.Models;
using System.Text.Json.Serialization;

namespace RpslsServer.Models.Dto
{
    public record class ScoreboardEntryDto
    {
        [JsonPropertyName("player_one_name")]
        public string PlayerOneName { get; init; } = string.Empty;

        [JsonPropertyName("player_one_gesture")]
        public Gesture PlayerOneGesture { get; init; }

        [JsonPropertyName("player_two_name")]
        public string PlayerTwoName { get; init; } = string.Empty;

        [JsonPropertyName("player_two_gesture")]
        public Gesture PlayerTwoGesture { get; init; }

        [JsonPropertyName("results")]
        public string Result { get; init; } = string.Empty;
    }
}
