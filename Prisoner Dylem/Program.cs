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
            gameSession.GetNewCountOfRounds(); await gameSession.GameStart();
            Action action = () =>
            {
                foreach (var item in gameSession.HistoryOfDecisions)
                {
                    Console.WriteLine($"First player: {item.Item1}\tSecond player: {item.Item2}");
                }
            };
            action();
        }
    }
}
