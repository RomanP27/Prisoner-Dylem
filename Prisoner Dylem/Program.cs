using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Prisoner_Dylem.Players;
using Prisoner_Dylem.Strategies;

namespace Prisoner_Dylem
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Players.Player firstPlayer = new Players.Player(0, "AlwaysCooperate", "PureChance");
            Players.Player secondPlayer = new Players.Player(50, "Random", "PureChance");
            GameEngine gameEngine = new GameEngine(firstPlayer, secondPlayer);
            GameEngine.GetNewCountOfRounds();
            gameEngine.GameSession();
        }
    }
}
