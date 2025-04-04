using Prisoner_Dylem.Players;

namespace Prisoner_Dylem.GameLogic
{
    internal class GameSession
    {
        /*
         * Короче будет весело. 
        5. Передавать в методы\интерфейсы this GameSession для работы с dictionary.
        6. В стратегии создать новое поле, MyID, EnemyID. Передаются значения из GameSession.
        Вроде все. Ебать копать меня сосали я ебал меня ебали.
         */
        public SessionHistory sessionHistory = new SessionHistory();
        public Logger Logger { get; private set; }
        public uint roundsForThisSession { get; private set; } = 0;
        public byte rewardForFirstPlayer { get; private set; }
        public byte rewardForSecondPlayer { get; private set; }
        public Player firstPlayer { get; private set; }
        public Player secondPlayer { get; private set; }
        public GameSession(Player firstPlayer, Player secondPlayer)
        {
            this.firstPlayer = firstPlayer;
            firstPlayer.strategy.PlayerID = GameEngine.PlayerID.FirstPlayer;
            this.secondPlayer = secondPlayer;
            secondPlayer.strategy.PlayerID = GameEngine.PlayerID.SecondPlayer;
            Logger = new Logger(this);
            SessionHistory sessionHistory = new SessionHistory();
        }
        public void SetRewards(byte rewardForFirstPlayer, byte rewardForSecondPlayer)
        {
            this.rewardForFirstPlayer = rewardForFirstPlayer;
            this.rewardForSecondPlayer = rewardForSecondPlayer;
        }
        private void WriteDownInHistory()
        {
            sessionHistory.AddDecision(firstPlayer.strategy.PlayerID, firstPlayer.currentDecision);
            sessionHistory.AddDecision(secondPlayer.strategy.PlayerID, secondPlayer.currentDecision);
        }

        public async Task GameStart()
        {
            await Task.Run(() =>
            {
                roundsForThisSession = GameEngine.rounds;
                while (roundsForThisSession > 0)
                {
                    firstPlayer.MakeDecision();
                    secondPlayer.MakeDecision();
                    GameEngine.PayoffMatrix(this);
                    WriteDownInHistory();
                    Logger.LogInformation();
                    roundsForThisSession--;
                }
                GameEngine.SetPoints(firstPlayer, secondPlayer);
                Logger.FinalMessage();
            });
        }
    }
}
