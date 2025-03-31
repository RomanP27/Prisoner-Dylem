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
    internal class GameEngine
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
        public static int GetChance() => random?.Value?.Next(0, 101) ?? 0;
        public static void SetPoints(Player firstPlayer, Player secondPlayer, byte rewardForFirstPlayer, byte rewardForSecondPlayer)
        {
            firstPlayer.ChangePoints(rewardForFirstPlayer);
            secondPlayer.ChangePoints(rewardForSecondPlayer);
        }
        public void GetNewCountOfRounds()
        {
            rounds = 10;
        }
    }
}
