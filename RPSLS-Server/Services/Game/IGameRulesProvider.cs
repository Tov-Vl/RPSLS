using RpslsServer.Models;

namespace RpslsServer.Services.Game
{
    public interface IGameRulesProvider
    {
        Rule? GetRuleFor(Gesture gestureOne, Gesture gestureTwo);
    }
}