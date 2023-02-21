using Microsoft.OpenApi.Extensions;
using RpslsServer.Models;
using RpslsServer.Models.Dto;

namespace RpslsServer.Mapper
{
    public class GameResultMapper: IMapper<GameResult, GameResultDto>
    {
        public GameResultDto Map(GameResult source)
        {
            var player = source.PlayerOne;
            var computer = source.PlayerTwo;

            return new()
            {
                Result = source.Outcome.GetDisplayName().ToLower(),
                PlayerGesture = player.Gesture,
                ComputerGesture = computer.Gesture
            };
        }
    }
}
