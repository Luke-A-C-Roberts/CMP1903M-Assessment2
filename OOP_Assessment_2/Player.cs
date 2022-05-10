namespace OOP_Assessment_2
{
    public abstract class Player
    {
        private int _score;
        private string _name;
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
    public class HumanPlayer : Player
    {
        public HumanPlayer()
        {
            Score = 0;
            Name = "";
        }
        public static HumanPlayer operator +(HumanPlayer oldHumanPlayer, int i)
        {
            HumanPlayer newHumanPlayer = new HumanPlayer();
            newHumanPlayer.Score = oldHumanPlayer.Score + i;
            return newHumanPlayer;
        }
    }

    public class AIPlayer : Player
    {
        public AIPlayer()
        {
            Score = 0;
            Name = "Computer";
        }

        public static AIPlayer operator +(AIPlayer oldAIPlayer, int i)
        {
            AIPlayer newAIPlayer = new AIPlayer();
            newAIPlayer.Score = oldAIPlayer.Score + i;
            return newAIPlayer;
        }
    }
}