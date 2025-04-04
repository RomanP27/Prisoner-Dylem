using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prisoner_Dylem.Players;

namespace Prisoner_Dylem.GameLogic
{
    internal class SessionHistory
    {
        public Dictionary<GameEngine.PlayerID, List<GameEngine.PlayerDecision>> history { get; } = new Dictionary<GameEngine.PlayerID, List<GameEngine.PlayerDecision>>();
        
        public SessionHistory()
        {
            history.Add(GameEngine.PlayerID.FirstPlayer, new List<GameEngine.PlayerDecision>());
            history.Add(GameEngine.PlayerID.SecondPlayer, new List<GameEngine.PlayerDecision>());
        }
        public void AddDecision(GameEngine.PlayerID playerID, GameEngine.PlayerDecision decision)
        {
            if (history.ContainsKey(playerID))
            {
                history[playerID].Add(decision);
            }
            else
            {
                throw new ArgumentException("Invalid player ID");
            }
        }
    }
}
