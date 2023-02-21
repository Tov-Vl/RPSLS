using RpslsServer.Models;

namespace RpslsServer.Services.Game
{
    public interface IGameManagerService
    {
        GameResult Play(Player playerOne, Player playerTwo);
    }
}