using RpslsServer.Models;
using RpslsServer.Models.Dto;

namespace RpslsServer.Mapper
{
    public class ScoreboardEntryDtoMapper : IMapper<ScoreboardEntry, ScoreboardEntryDto>
    {
        public ScoreboardEntryDto Map(ScoreboardEntry source)
        {
            return new()
            {
                PlayerOneName = source.PlayerOneName,
                PlayerOneGesture= source.PlayerOneGesture,
                PlayerTwoName = source.PlayerTwoName,
                PlayerTwoGesture= source.PlayerTwoGesture,
                Result = source.Result
            };
        }
    }
}
