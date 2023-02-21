using Microsoft.Extensions.Options;
using RpslsServer.Models;
using RpslsServer.Options;
using System.Collections.Concurrent;

namespace RPSLS_Server.Providers
{
    public class ScoreboardProvider : IScoreboardProvider
    {
        private readonly ConcurrentQueue<ScoreboardEntry> _scoreboard = new();
        private readonly object _lockObject = new();
        private readonly int _limit;

        public ScoreboardProvider(IOptions<ScoreboardOptions> options)
        {
            _limit = options?.Value?.Limit ?? throw new ArgumentNullException();
        }

        public ScoreboardEntry[] GetScoreboard()
        {
            return _scoreboard.Reverse().ToArray();
        }

        public void AddEntry(ScoreboardEntry scoreboardEntry)
        {
            Enqueue(scoreboardEntry);
        }

        private void Enqueue(ScoreboardEntry entry)
        {
            _scoreboard.Enqueue(entry);

            lock (_lockObject)
            {
                while (_scoreboard.Count > _limit && _scoreboard.TryDequeue(out _)) ;
            }
        }
    }
}
