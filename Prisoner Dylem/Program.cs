using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Prisoner_Dylem
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Player firstPlayer = new Player(0, "AlwaysCooperate", "PureChance");
            Player secondPlayer = new Player(50, "Random", "PureChance");
            GameEngine gameEngine = new GameEngine(firstPlayer, secondPlayer);
            GameEngine.GetNewCountOfRounds();
            gameEngine.GameSession();
        }
    }
}
