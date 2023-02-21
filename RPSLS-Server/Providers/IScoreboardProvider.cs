using RpslsServer.Models;

namespace RPSLS_Server.Providers
{
    public interface IScoreboardProvider
    {
        void AddEntry(ScoreboardEntry scoreboardEntry);

        ScoreboardEntry[] GetScoreboard();
    }
}
