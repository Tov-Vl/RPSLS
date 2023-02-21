using Microsoft.AspNetCore.Mvc;
using RPSLS_Server.Providers;
using RpslsServer.Mapper;
using RpslsServer.Models;
using RpslsServer.Models.Dto;

namespace RPSLS.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
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
        public ActionResult<IEnumerable<ScoreboardEntryDto>> Get()
        {
            var scoreboardEntries = _scoreboardProvider.GetScoreboard();

            var res = scoreboardEntries.Select(_scoreboardEntryDtoMapper.Map).ToArray();

            _logger.LogInformation("Scoreboard requested");

            return res;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult Reset()
        {
            var success = _scoreboardProvider.TryResetScoreboard();

            if (!success)
            {
                _logger.LogInformation("Can't reset the Scoreboard");
                return Conflict();
            }

            _logger.LogInformation("Scoreboard resetted");

            return Ok();
        }
    }
}