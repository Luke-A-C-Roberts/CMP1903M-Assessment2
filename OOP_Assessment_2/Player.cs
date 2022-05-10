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
    }
    public class AIPlayer : Player
    {
        public AIPlayer()
        {
            Score = 0;
            Name = "Computer";
        }
    }
}