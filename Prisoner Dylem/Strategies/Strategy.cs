using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Prisoner_Dylem.Strategies
{
    public abstract class Strategy
    {
        public abstract GameEngine.PlayerDecision Decision();
    }
    public class PureChance : Strategy, InterfaceStrategies.IRandomChoiseModule
    {
        public int betrayChance { get; }
        public PureChance(int betrayalProbability) => betrayChance = betrayalProbability;
        public override GameEngine.PlayerDecision Decision() => ((InterfaceStrategies.IRandomChoiseModule)this).Decision();
        public GameEngine.PlayerDecision MakeRandomDecision() => ((InterfaceStrategies.IRandomChoiseModule)this).MakeRandomDecision();
    }
}
