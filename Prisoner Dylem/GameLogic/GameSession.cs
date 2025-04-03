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
        /*
         * Короче будет весело. 
        3. Создать общий dictionary, где ключ - ключ игрока, а значение - лист его выборов.
        4. В GameSession создать метод, который будет записывать в dictionary выборы игроков.
        5. Передавать в методы\интерфейсы this GameSession для работы с dictionary.
        6. В стратегии создать новое поле, MyID, EnemyID. Передаются значения из GameSession.
        Вроде все. Ебать копать меня сосали я ебал меня ебали.
         */
        public List<PlayerDecision>? HistoryOfFirstPlayer { get; private set; } //перенести в Стратегию. Второй лист тоже. 
        //Иницииализировать в конструкторе стратегии в зависимости от наличия интерфейса IRememberOpponentDecisionsModule.
        //Создать dictionary, где ключ - игрок, значение - его выбор. Сделать возможность получать это через интерфейс.
        public List<PlayerDecision>? HistoryOfSecondPlayer { get; private set; }
        public Logger Logger { get; private set; }
        public uint roundsForThisSession { get; private set; }
        public byte rewardForFirstPlayer { get; private set; }
        public byte rewardForSecondPlayer { get; private set; }
        public Player firstPlayer { get; private set; }
        public Player secondPlayer { get; private set; }
        public GameSession(Player firstPlayer, Player secondPlayer)
        {
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
            Logger = new Logger(this);
            HistoryOfSecondPlayer = firstPlayer.strategy is ZeroLevelInterfacesOfStrategies.IRememberOpponentDecisionsModule ? new List<PlayerDecision>() : null;
            HistoryOfFirstPlayer = secondPlayer.strategy is ZeroLevelInterfacesOfStrategies.IRememberOpponentDecisionsModule ? new List<PlayerDecision>() : null;
        }
        public void SetRewards(byte rewardForFirstPlayer, byte rewardForSecondPlayer)
        {
            this.rewardForFirstPlayer = rewardForFirstPlayer;
            this.rewardForSecondPlayer = rewardForSecondPlayer;
        }
        private void WriteDownInHistory()
        {
            HistoryOfFirstPlayer?.Add(firstPlayer.currentDecision);
            HistoryOfSecondPlayer?.Add(secondPlayer.currentDecision);
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
                    PayoffMatrix(this);
                    WriteDownInHistory();
                    Logger.LogInformation();
                    roundsForThisSession--;
                }
                SetPoints(firstPlayer, secondPlayer);
                Console.WriteLine($"Счёт первого игрока: {firstPlayer.points}\tСчёт второго игрока: {secondPlayer.points}");
            });
        }
    }
}
