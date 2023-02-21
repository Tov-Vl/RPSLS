using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using RpslsServer.Mapper;
using RpslsServer.Models;
using RpslsServer.Models.Dto;
using RpslsServer.Services.Game;
using RpslsServer.Services.RandomNumberService;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace RPSLS.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly IRandomNumberService _randomNumberService;
        private readonly IGameManagerService _gameManagerService;
        private readonly IMapper<GameResult, GameResultDto> _gameResultMapper;

        public GameController(
            ILogger<GameController> logger,
            IRandomNumberService randomNumberService,
            IGameManagerService gameManagerService,
            IMapper<GameResult, GameResultDto> gameResultMapper)
        {
            _logger = logger ?? throw new ArgumentNullException();
            _randomNumberService = randomNumberService ?? throw new ArgumentNullException();
            _gameManagerService = gameManagerService ?? throw new ArgumentNullException();
            _gameResultMapper = gameResultMapper ?? throw new ArgumentNullException();
        }

        [HttpPost]
        public async Task<ActionResult<GameResultDto>> Play([Required] Gesture player)
        {
            var playerOne = new Player() { Gesture = player, Id = new Random().Next(), Name = "DefaultName" };

            var computerGesture = await _randomNumberService.GetRandomNumberAsync();

            var computerPlayerTwo = new ComputerPlayer() { Gesture = computerGesture };

            var gameResult = _gameManagerService.Play(playerOne, computerPlayerTwo);

            var gameResultDto = _gameResultMapper.Map(gameResult);

            _logger.LogInformation($"Played game: Player 1: {playerOne}, Player 2: {computerPlayerTwo}. Result: {gameResultDto}");

            return gameResultDto;
        }
    }
}