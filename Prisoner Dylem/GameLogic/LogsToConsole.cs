using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prisoner_Dylem.Players;

namespace Prisoner_Dylem.GameLogic
{
    public class LogsToConsole
    {
        public static async Task ConsoleInformation(Player firstPlayer, Player secondPlayer, byte rewardForFirstPlayer, byte rewardForSecondPlayer)
        {
            await Task.Run(() =>
            {
                string firstMessage = firstPlayer.currentDecision.ToString();
                string secondMessage = secondPlayer.currentDecision.ToString();
                string message = $"Выбор первого игрока: {firstMessage}\tВыбор второго игрока: {secondMessage}.\nПервый игрок получил {rewardForFirstPlayer}\tВторой игрок получил {rewardForSecondPlayer}";
                Console.WriteLine(message);
            });
        }
    }
}
