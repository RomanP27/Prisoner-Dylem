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
        StringBuilder message = new StringBuilder();
        
        public void LogInformation()
        {
            message.Clear();
            message.AppendFormat("Выбор первого игрока: {0}\tВыбор второго игрока: {1}\n",
                gameSession.firstPlayer.currentDecision, gameSession.secondPlayer.currentDecision);
            message.AppendFormat("Первый игрок получил {0}\tВторой игрок получил {1}\n",
                gameSession.rewardForFirstPlayer, gameSession.rewardForSecondPlayer);

            Console.WriteLine(message.ToString());
        }
        public void FinalMessage()
        {
            message.Clear();
            message.AppendFormat("Счёт первого игрока: {0}\tСчёт второго игрока: {1}\n",
                gameSession.firstPlayer.points, gameSession.secondPlayer.points);
            Console.WriteLine(message.ToString());
        }
    }
}
