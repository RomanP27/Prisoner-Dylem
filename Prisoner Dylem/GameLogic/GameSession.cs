using Prisoner_Dylem.Players;
using Prisoner_Dylem.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Prisoner_Dylem.GameLogic.GameEngine;

namespace Prisoner_Dylem.GameLogic
{
    internal class GameSession
    {
        public List<PlayerDecision>? HistoryOfFirstPlayer { get; private set; }
        public List<PlayerDecision>? HistoryOfSecondPlayer { get; private set; }
        public Logger Logger { get; private set; }
        public uint roundsForThisSession { get; private set; }
        public static uint rounds { get; private set; }
        public byte rewardForFirstPlayer { get; private set; }
        public byte rewardForSecondPlayer { get; private set; }
        public Player firstPlayer { get; private set; }
        public Player secondPlayer { get; private set; }
        public GameSession(Player firstPlayer, Player secondPlayer)
        {
            this.firstPlayer = firstPlayer;
            this.firstPlayer.strategy.SetPosition(0);
            this.secondPlayer = secondPlayer;
            this.secondPlayer.strategy.SetPosition(1);
            Logger = new Logger(this);
            HistoryOfSecondPlayer = firstPlayer.strategy is ZeroLevelInterfacesOfStrategies.IRememberOpponentDecisionsModule ? new List<PlayerDecision>() : null;
            HistoryOfFirstPlayer = secondPlayer.strategy is ZeroLevelInterfacesOfStrategies.IRememberOpponentDecisionsModule ? new List<PlayerDecision>() : null;
        }
        private void WriteDownInHistory()
        {
            HistoryOfFirstPlayer?.Add(firstPlayer.currentDecision);
            HistoryOfSecondPlayer?.Add(secondPlayer.currentDecision);
        }
        public void GetNewCountOfRounds()
        {
            rounds = 10;
        }
        public void PayoffMatrix()
        {
            (rewardForFirstPlayer, rewardForSecondPlayer) = (firstPlayer.currentDecision, secondPlayer.currentDecision) switch
            {
                (PlayerDecision.Cooperate, PlayerDecision.Cooperate) => (RewardForCooperation, RewardForCooperation),
                (PlayerDecision.Betray, PlayerDecision.Betray) => (PunishmentForDefection, PunishmentForDefection),
                (PlayerDecision.Cooperate, PlayerDecision.Betray) => (PunishmentForDefection, TemptationToDefect),
                (PlayerDecision.Betray, PlayerDecision.Cooperate) => (TemptationToDefect, PunishmentForDefection),
                _ => throw new InvalidOperationException("Invalid decision")
            };
            firstPlayer.ChangePoints(rewardForFirstPlayer);
            secondPlayer.ChangePoints(rewardForSecondPlayer);
        }
        public async Task GameStart()
        {
            await Task.Run(() =>
            {
                roundsForThisSession = rounds;
                while (roundsForThisSession > 0)
                {
                    firstPlayer.MakeDecision();
                    secondPlayer.MakeDecision();
                    PayoffMatrix();
                    WriteDownInHistory();
                    Logger.LogInformation();
                    roundsForThisSession--;
                }
                Console.WriteLine($"Счёт первого игрока: {firstPlayer._points}\tСчёт второго игрока: {secondPlayer._points}");
            });
        }
    }
}
