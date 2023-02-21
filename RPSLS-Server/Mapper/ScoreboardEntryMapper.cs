using Microsoft.OpenApi.Extensions;
using RpslsServer.Models;
using RpslsServer.Models.Dto;

namespace RpslsServer.Mapper
{
    public class ScoreboardEntryMapper: IMapper<GameResult, ScoreboardEntry>
    {
        public ScoreboardEntry Map(GameResult source)
        {
            return new()
            {
                PlayerOneName = source.PlayerOne.Name,
                PlayerOneGesture = source.PlayerOne.Gesture,
                PlayerTwoName = source.PlayerTwo.Name,
                PlayerTwoGesture = source.PlayerTwo.Gesture,
                Result = source.Outcome.GetDisplayName().ToLower()
            };
        }
    }
}
