using Prisoner_Dylem.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prisoner_Dylem.Players;

namespace Prisoner_Dylem.Strategies
{
    interface ZeroLevelInterfacesOfStrategies
    {
        interface IBetrayChanceModule
        {
            protected int betrayChance { get; }
        }
        interface IRememberOpponentDecisionsModule
        {
            protected List<GameEngine.PlayerDecision> rememberedDecisions { get; }

            protected int positionInSession { get; }
        }
    }
    interface FirstLevelInterfacesOfStrategies
    {
        interface IRandomChoiseModule : ZeroLevelInterfacesOfStrategies.IBetrayChanceModule
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
    interface SecondLevelInterfacesOfStrategies : ZeroLevelInterfacesOfStrategies.IBetrayChanceModule
    {
        interface IRevengeModule
        {

        }
    }
}