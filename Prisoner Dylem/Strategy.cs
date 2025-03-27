using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Prisoner_Dylem
{
    abstract public class Strategy
    {
        protected GameEngine.PlayerDecision decision;
        protected int chance;
        public Strategy(int betrayalProbability)
        {
            chance = betrayalProbability;
        }
        public abstract GameEngine.PlayerDecision Decision();

    }
    public class PureChance : Strategy
    {
        public PureChance(int betrayalProbability) : base(betrayalProbability) { }
        public override GameEngine.PlayerDecision Decision()
        {
            if (chance == 100) return GameEngine.PlayerDecision.Betraye;
            if (chance == 0) return GameEngine.PlayerDecision.Cooperate;
            return MakeRandomDecision();
        }
        private GameEngine.PlayerDecision MakeRandomDecision()
        {
            int someChance = GameEngine.GetShance();
            return someChance <= chance ? GameEngine.PlayerDecision.Cooperate : GameEngine.PlayerDecision.Betraye;
        }
    }
}
