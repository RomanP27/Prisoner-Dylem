using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Prisoner_Dylem.Players;
using Prisoner_Dylem.Strategies;

namespace Prisoner_Dylem
{
    public class GameEngine
    {
        public static readonly ThreadLocal<Random> random = new ThreadLocal<Random>(() => new Random());
        private const byte RewardForCooperation = 3;
        private const byte PunishmentForDefection = 1;
        private const byte TemptationToDefect = 5;
        private byte rewardForFirstPlayer;
        private byte rewardForSecondPlayer;
        Players.Player firstPlayer {get;set;}
        Players.Player secondPlayer {get;set;}

        public GameEngine(Players.Player firstPlayer, Players.Player secondPlayer)
        {
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
        }

        public enum PlayerDecision
        {
            Betray,
            Cooperate
        };

        private static int rounds;
        public static void GetNewCountOfRounds()
        {
            rounds = 100;
        }
        public static int GetChance() => random.Value.Next(0, 100);
        public void PayoffMatrix()
        {
            (rewardForFirstPlayer, rewardForSecondPlayer) = (firstPlayer.currentDecision, secondPlayer.currentDecision) switch
            { 
                (PlayerDecision.Cooperate, PlayerDecision.Cooperate) => (RewardForCooperation, RewardForCooperation),
                (PlayerDecision.Betray,  PlayerDecision.Betray) => (PunishmentForDefection, PunishmentForDefection),
                (PlayerDecision.Cooperate, PlayerDecision.Betray) => (PunishmentForDefection, TemptationToDefect),
                (PlayerDecision.Betray, PlayerDecision.Cooperate) => (TemptationToDefect, PunishmentForDefection)
            };
            firstPlayer.ChangePoints(rewardForFirstPlayer);
            secondPlayer.ChangePoints(rewardForSecondPlayer);

        }
        public void GameSession()
        {
            while (rounds > 0)
            {
                firstPlayer.MakeDecision();
                secondPlayer.MakeDecision();
                PayoffMatrix();
                ConsoleInformation();
                rounds--;
            }
            Console.WriteLine($"Счёт первого игрока: {firstPlayer._points}\tСчёт второго игрока: {secondPlayer._points}");
        }
        public void ConsoleInformation()
        {
            string firstMessage = firstPlayer.currentDecision.ToString();
            string secondMessage = secondPlayer.currentDecision.ToString();
            string message = $"Выбор первого игрока: {firstMessage}\tВыбор второго игрока: {secondMessage}.\nПервый игрок получил {rewardForFirstPlayer}\tВторой игрок получил {rewardForSecondPlayer}";
            Console.WriteLine(message);
        }
    }
}
