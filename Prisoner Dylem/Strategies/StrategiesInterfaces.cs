using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisoner_Dylem.Strategies
{
    interface InterfaceStrategies
    {
        interface IRandomChoiseModule
        {
            public int betrayChance { get; }
            public GameEngine.PlayerDecision Decision()
            {
                if (betrayChance == 100) return GameEngine.PlayerDecision.Betray;
                if (betrayChance == 0) return GameEngine.PlayerDecision.Cooperate;
                return MakeRandomDecision();
            }
            public GameEngine.PlayerDecision MakeRandomDecision()
            {
                int someChance = GameEngine.GetChance();
                return someChance <= betrayChance ? GameEngine.PlayerDecision.Betray : GameEngine.PlayerDecision.Cooperate;
            }
        }

    }
}