using RPSLS_Server.Providers;
using RpslsServer.Mapper;
using RpslsServer.Models;
using RpslsServer.Services.Game;

namespace RPSLS_Server.Services.Scoreboard
{
    public class ScoreBoardGameManagerService : IGameManagerService
    {
        private readonly IGameManagerService _gameManagerService;
        private readonly IMapper<GameResult, ScoreboardEntry> _scoreboardEntryMapper;
        private readonly IScoreboardProvider _scoreboardProvider;

        public ScoreBoardGameManagerService(
            IGameManagerService gameManagerService,
            IMapper<GameResult, ScoreboardEntry> scoreboardEntryMapper,
            IScoreboardProvider scoreboardProvider)
        {
            _gameManagerService = gameManagerService ?? throw new ArgumentNullException();
            _scoreboardEntryMapper = scoreboardEntryMapper ?? throw new ArgumentNullException();
            _scoreboardProvider = scoreboardProvider ?? throw new ArgumentNullException();
        }

        public GameResult Play(Player playerOne, Player playerTwo)
        {
            var res = _gameManagerService.Play(playerOne, playerTwo);

            var scoreboardEntry = _scoreboardEntryMapper.Map(res);

            _scoreboardProvider.AddEntry(scoreboardEntry);

            return res;
        }
    }
}
