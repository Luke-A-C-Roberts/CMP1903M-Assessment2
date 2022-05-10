namespace OOP_Assessment_2
{
    public class Game
    {
        public static void Play()
        {
            GameUI gameuiObj = new GameUI();
            HumanPlayer humanPlayerObj = new HumanPlayer();
            AIPlayer aiPlayerObj = new AIPlayer();
            Dice diceObj = new Dice(6);

            humanPlayerObj.Name = gameuiObj.AskUserName();
        }
    }
}