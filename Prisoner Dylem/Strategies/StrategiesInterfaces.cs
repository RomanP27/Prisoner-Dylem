using Prisoner_Dylem.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prisoner_Dylem.Strategies
{
    interface ZeroLevelInterfacesOfStrategies
    {
        interface BetrayChanceModule
        {
            public int betrayChance { get; }
        }
    }
    interface FirstLevelInterfacesOfStrategies
    {
        interface IRandomChoiseModule : ZeroLevelInterfacesOfStrategies.BetrayChanceModule
        { 
            public GameEngine.PlayerDecision MakeRandomDecision()
            {
                if (betrayChance == 100) return GameEngine.PlayerDecision.Betray;
                if (betrayChance == 0) return GameEngine.PlayerDecision.Cooperate;
                int someChance = GameEngine.GetChance();
                return someChance <= betrayChance ? GameEngine.PlayerDecision.Betray : GameEngine.PlayerDecision.Cooperate;
            }
        }
    }
    interface SecondLevelInterfacesOfStrategies
    {
        interface IZAGOTOVKA
        {
            
        }
    }
}