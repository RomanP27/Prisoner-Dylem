using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Prisoner_Dylem.Players;

namespace Prisoner_Dylem.GameLogic
{
    internal class Logger
    {
        private readonly GameSession gameSession;
        public Logger(GameSession gameSession)
        {
            this.gameSession = gameSession;
        }
        public void LogInformation()
        {
            string firstMessage = gameSession.firstPlayer.currentDecision.ToString();
            string secondMessage = gameSession.secondPlayer.currentDecision.ToString();
            string message = $"Выбор первого игрока: {firstMessage}\tВыбор второго игрока: {secondMessage}.\nПервый игрок получил {gameSession.rewardForFirstPlayer}\tВторой игрок получил {gameSession.rewardForSecondPlayer}";
            Console.WriteLine(message);
        }
    }
}
