using Prisoner_Dylem.GameLogic;
using Prisoner_Dylem.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Prisoner_Dylem.Players
{
    internal class Player
    {
        public string Name { get; }
        public Strategy strategy { get; }
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
