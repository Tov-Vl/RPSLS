using RpslsServer.Models;
using System.Text.Json.Serialization;

namespace RpslsServer.Models.Dto
{
    public record class GameResultDto
    {
        [JsonPropertyName("results")]
        public string Result { get; init; } = string.Empty;

        [JsonPropertyName("player")]
        public Gesture PlayerGesture { get; init; }

        [JsonPropertyName("computer")]
        public Gesture ComputerGesture { get; init; }

        public override string ToString()
        {
            return $"{Result}. Player gesture: {PlayerGesture} (Id = {PlayerGesture:d}). " +
                $"Computer gesture: {ComputerGesture} (Id = {ComputerGesture:d})";
        }
    }
}
