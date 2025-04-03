using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Prisoner_Dylem.Players;
using Prisoner_Dylem.Strategies;

namespace Prisoner_Dylem.GameLogic
{
    internal static class GameEngine
    {
        public static readonly ThreadLocal<Random> random = new ThreadLocal<Random>(() => new Random());
        public const byte RewardForCooperation = 3;
        public const byte PunishmentForDefection = 1;
        public const byte TemptationToDefect = 5;
        public static uint rounds { get; private set; }

        public enum PlayerDecision
        {
            Betray,
            Cooperate
        };
        public enum PlayerID
        {
            FirstPlayer,
            SecondPlayer
        };
        public static int GetChance() => random?.Value?.Next(0, 101) ?? 0;

        public static void PayoffMatrix(GameSession gameSession)
        {
            byte rewardForFirstPlayer, rewardForSecondPlayer;
            (rewardForFirstPlayer, rewardForSecondPlayer) = (gameSession.firstPlayer.currentDecision, gameSession.secondPlayer.currentDecision) switch
            {
                (PlayerDecision.Cooperate, PlayerDecision.Cooperate) => (RewardForCooperation, RewardForCooperation),
                (PlayerDecision.Betray, PlayerDecision.Betray) => (PunishmentForDefection, PunishmentForDefection),
                (PlayerDecision.Cooperate, PlayerDecision.Betray) => (PunishmentForDefection, TemptationToDefect),
                (PlayerDecision.Betray, PlayerDecision.Cooperate) => (TemptationToDefect, PunishmentForDefection),
                _ => throw new InvalidOperationException("Invalid decision")
            };
            SetPointsForCurrentRound(gameSession, rewardForFirstPlayer, rewardForSecondPlayer);
        }
        private static void SetPointsForCurrentRound(GameSession gameSession, byte rewardForFirstPlayer, byte rewardForSecondPlayer)
        {
            gameSession.SetRewards(rewardForFirstPlayer, rewardForSecondPlayer);
            gameSession.firstPlayer.ChangePointsForCurrentRound(rewardForFirstPlayer);
            gameSession.secondPlayer.ChangePointsForCurrentRound(rewardForSecondPlayer);
            
        }
        public static void SetPoints(Player firstPlayer, Player secondPlayer)
        {
            firstPlayer.ChangePoints();
            secondPlayer.ChangePoints();
        }
        public static void GetNewCountOfRounds()
        {
            rounds = 10;
        }
    }
}
