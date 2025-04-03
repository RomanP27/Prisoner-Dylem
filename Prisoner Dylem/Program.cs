using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Prisoner_Dylem.GameLogic;
using Prisoner_Dylem.Players;
using Prisoner_Dylem.Strategies;

namespace Prisoner_Dylem
{

    internal class Program
    {
        static async Task Main(string[] args)
        {
            StrategyBuilder.StrategyBuild.Add("AlwaysCooperate", chance => new PureChance(chance));
            Player firstPlayer = new Player(0, "AlwaysCooperate", "PureChance");
            Player secondPlayer = new Player(50, "Random", "PureChance");
            GameSession gameSession = new GameSession(firstPlayer, secondPlayer);
            GameEngine.GetNewCountOfRounds();
            await gameSession.GameStart();
        }
    }
}
