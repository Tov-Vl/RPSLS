namespace RpslsServer.Models
{
    public class ScoreboardEntry
    {
        public string PlayerOneName { get; set; } = string.Empty;

        public Gesture PlayerOneGesture { get; set; }

        public string PlayerTwoName { get; set; } = string.Empty;

        public Gesture PlayerTwoGesture { get; set; }

        public string Result { get; set; } = string.Empty;
    }
}