using Prisoner_Dylem.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Prisoner_Dylem.Strategies
{
    internal abstract class Strategy
    {
        public abstract GameEngine.PlayerDecision Decision();
    }
    internal class PureChance : Strategy, InterfaceStrategies.IRandomChoiseModule
    {
        public int betrayChance { get; }
        public PureChance(int betrayalProbability) => betrayChance = betrayalProbability;
        public override GameEngine.PlayerDecision Decision() => ((InterfaceStrategies.IRandomChoiseModule)this).MakeRandomDecision();
    }
}
