using Microsoft.OpenApi.Extensions;
using RpslsServer.Models;

namespace RpslsServer.Services.Game
{
    public class GameRulesProvider : IGameRulesProvider
    {
        private readonly IDictionary<Gesture, IList<Rule>> _rules;

        public GameRulesProvider()
        {
            _rules = InitRules();
        }

        private static Dictionary<Gesture, IList<Rule>> InitRules()
        {
            var res = new Dictionary<Gesture, IList<Rule>>();

            foreach (var gesture in Enum.GetValues<Gesture>())
                res.Add(gesture, InitRules(gesture));

            return res;

            static List<Rule> InitRules(Gesture winner)
            {
                return winner switch
                {
                    Gesture.Rock => new() { new(winner, Gesture.Lizard, "Crushes"), new(winner, Gesture.Scissors, "Crushes") },
                    Gesture.Paper => new() { new(winner, Gesture.Rock, "Covers"), new(winner, Gesture.Spock, "Disproves") },
                    Gesture.Scissors => new() { new(winner, Gesture.Paper, "Cuts"), new(winner, Gesture.Lizard, "Decapitates") },
                    Gesture.Lizard => new() { new(winner, Gesture.Spock, "Eats"), new(winner, Gesture.Paper, "Poisons") },
                    Gesture.Spock => new() { new(winner, Gesture.Scissors, "Smashes"), new(winner, Gesture.Rock, "Vaporizes") },
                    _ => new()
                };
            }
        }

        public Rule? GetRuleFor(Gesture gestureOne, Gesture gestureTwo)
        {
            if (!_rules.TryGetValue(gestureOne, out var losersOne))
                throw new NotImplementedException($"Can't get a rule for a {gestureOne.GetDisplayName} ({gestureOne}) gesture!");

            if (!_rules.TryGetValue(gestureTwo, out var losersTwo))
                throw new NotImplementedException($"Can't get a rule for a {gestureTwo.GetDisplayName} ({gestureTwo}) gesture!");

            return losersOne.SingleOrDefault(r => r.LoserGesture == gestureTwo) ?? losersTwo.SingleOrDefault(r => r.LoserGesture == gestureOne);
        }
    }
}