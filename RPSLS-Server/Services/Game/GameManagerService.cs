using RpslsServer.Models;

namespace RpslsServer.Services.Game
{
    public class GameManagerService: IGameManagerService
    {
        private readonly IGameRulesProvider _gameRulesProvider;

        public GameManagerService(IGameRulesProvider gameRulesProvider)
        {
            _gameRulesProvider = gameRulesProvider ?? throw new ArgumentNullException();
        }

        public GameResult Play(Player playerOne, Player playerTwo)
        {
            var rule = _gameRulesProvider.GetRuleFor(playerOne.Gesture, playerTwo.Gesture);

            if (rule == null || playerOne.Gesture != rule.WinnerGesture && playerTwo.Gesture != rule.WinnerGesture)
                return new()
                {
                    PlayerOne = playerOne,
                    PlayerTwo = playerTwo,
                    Outcome = GameOutcome.Tie
                };

            if (playerOne.Gesture == rule.WinnerGesture)
            {
                return new()
                {
                    PlayerOne = playerOne,
                    PlayerTwo = playerTwo,
                    Outcome = GameOutcome.Win
                };
            }
            else
            {
                return new()
                {
                    PlayerOne = playerOne,
                    PlayerTwo = playerTwo,
                    Outcome = GameOutcome.Lose
                };
            }

            //Description = GetGameResultDescription(
            //    (playerTwo.Name, playerTwo.Gesture.ToString()),
            //    (playerOne.Name, playerOne.Gesture.ToString()),
            //    verb)

            //static string GetGameResultDescription((string Name, string Gesture) winner, (string Name, string Gesture) loser, string verb)
            //{
            //    var winReason = $"{winner.Gesture} {verb} {loser.Gesture}";
            //    return $"{winReason}! {winner.Name} wins {loser.Name}!";
            //}
        }
    }
}
