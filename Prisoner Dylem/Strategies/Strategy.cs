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

        public int betrayChance { get; protected set; }

        protected int positionInSession { get; private set; }
        public abstract GameEngine.PlayerDecision Decision();

        public void SetPosition(int position) => positionInSession = position;

        public int GetPosition() => positionInSession;
    }
    internal class PureChance : Strategy, FirstLevelInterfacesOfStrategies.IRandomChoiseModule
    {
        public PureChance(int betrayalProbability) => betrayChance = betrayalProbability;
        public override GameEngine.PlayerDecision Decision() => ((FirstLevelInterfacesOfStrategies.IRandomChoiseModule)this).MakeRandomDecision();
    }
}
