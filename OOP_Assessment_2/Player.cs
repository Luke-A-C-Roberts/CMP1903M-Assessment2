namespace OOP_Assessment_2
{
    /*
     * abstract class for human and AI players
     * which contains the name and current
     * score of the Player
     */
    public abstract class Player
    {
        //encapsulation of _score and _name
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
        public void CreateName(string tempName)
        {
            _name = tempName[0].ToString().ToUpper() + tempName[1..^0].ToLower();
        }
    }
    public class HumanPlayer : Player
    {
        //human player constructor
        public HumanPlayer()
        {
            Score = 0;
            Name = "";
        }
        /*
         * operation overload which adds a
         * number of points to the total score
         * and returns a new human player
         * with the updated score.
         */
        public static HumanPlayer operator +(HumanPlayer oldHumanPlayer, int i)
        {
            HumanPlayer newHumanPlayer = new HumanPlayer();
            newHumanPlayer.Name = oldHumanPlayer.Name;
            newHumanPlayer.Score = oldHumanPlayer.Score + i;
            return newHumanPlayer;
        }
    }
    public class AIPlayer : Player
    {
        // AI player constructor
        public AIPlayer()
        {
            Score = 0;
            Name = "";
        }
        /*
         * operation overload which adds a
         * number of points to the total score
         * and returns a new AI player with
         * the updated score.
         */
        public static AIPlayer operator +(AIPlayer oldAIPlayer, int i)
        {
            AIPlayer newAIPlayer = new AIPlayer();
            newAIPlayer.Score = oldAIPlayer.Score + i;
            return newAIPlayer;
        }

        public void CreateName()
        {
            Name = "Computer";
        }
    }
}