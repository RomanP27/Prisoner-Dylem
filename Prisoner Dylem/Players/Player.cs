using Prisoner_Dylem.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisoner_Dylem.Players
{
    public class Player
    {
        public string Name { get; }
        private Strategy strategy;
        public int _points { get; private set; } = 0;
        public GameEngine.PlayerDecision currentDecision { get; private set; }
        public Player(int betrayalProbability, string name, string getStrategy)
        {
            Name = name;
            strategy = StrategyBuilder.StrategyBuild[getStrategy](betrayalProbability);
        }

        public void ChangePoints(int points) => _points += points;

        public void MakeDecision()
        {
            currentDecision = strategy.Decision();
        }
    }
}
