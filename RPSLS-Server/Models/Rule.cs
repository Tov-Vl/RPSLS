using System.Reflection;

namespace RpslsServer.Models
{
    public record class Rule(Gesture WinnerGesture, Gesture LoserGesture, string Verb)
    {
        public Rule() : this(default, default, string.Empty) { }
    }
}