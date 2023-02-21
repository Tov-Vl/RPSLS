using System.Reflection;

namespace RpslsServer.Models
{
    public record class GameResult(Player PlayerOne, Player PlayerTwo, GameOutcome Outcome)
    {
        public GameResult() : this(new(), new(), GameOutcome.Tie) { }
    }

    public enum GameOutcome
    {
        Win,
        Lose,
        Tie
    }
}