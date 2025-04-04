using Prisoner_Dylem.GameLogic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Prisoner_Dylem.Strategies
{
    internal abstract class Strategy
    {

        private bool currentSessionIsGoing;

        private GameEngine.PlayerID playerID;
        public GameEngine.PlayerID PlayerID
        {
            get { return playerID; }
            set
            {
                if (!currentSessionIsGoing)
                {
                    playerID = value;
                    currentSessionIsGoing = true;
                }
            }
        }
        public void currentSessionStops(GameSession gamesession)
        {
            if (gamesession.roundsForThisSession == 0)
                currentSessionIsGoing = false;
        }
        public abstract GameEngine.PlayerDecision Decision();
    }
    internal class PureChance : Strategy, FirstLevelInterfacesOfStrategies.IRandomChoiseModule
    {
        public int betrayChance { get; private set; }
        public PureChance(int betrayalProbability) => betrayChance = betrayalProbability;
        public override GameEngine.PlayerDecision Decision() => ((FirstLevelInterfacesOfStrategies.IRandomChoiseModule)this).MakeRandomDecision();
    }
}
