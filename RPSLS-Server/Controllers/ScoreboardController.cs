using Microsoft.AspNetCore.Mvc;
using RPSLS_Server.Providers;
using RpslsServer.Mapper;
using RpslsServer.Models;
using RpslsServer.Models.Dto;

namespace RPSLS.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class ScoreboardController : ControllerBase
    {
        private readonly ILogger<ScoreboardController> _logger;
        private readonly IScoreboardProvider _scoreboardProvider;
        private readonly IMapper<ScoreboardEntry, ScoreboardEntryDto> _scoreboardEntryDtoMapper;

        public ScoreboardController(
            ILogger<ScoreboardController> logger,
            IScoreboardProvider scoreboardProvider,
            IMapper<ScoreboardEntry, ScoreboardEntryDto> scoreboardEntryDtoMapper)
        {
            _logger = logger ?? throw new ArgumentNullException();
            _scoreboardProvider = scoreboardProvider ?? throw new ArgumentNullException();
            _scoreboardEntryDtoMapper = scoreboardEntryDtoMapper ?? throw new ArgumentNullException();
        }

        [HttpGet]
        public ActionResult<IEnumerable<ScoreboardEntryDto>> GetScoreboard()
        {
            var scoreboardEntries = _scoreboardProvider.GetScoreboard();

            var res = scoreboardEntries.Select(_scoreboardEntryDtoMapper.Map).ToArray();

            _logger.LogInformation("Scoreboard requested");

            return res;
        }
    }
}