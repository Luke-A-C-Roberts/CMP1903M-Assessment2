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

            static int GenerateScore(int[] diceVals)
            {
                Array.Sort(diceVals);
                int[] numAmmounts = new int[6];
                for (int i = 0; i < 6; i++)
                {
                    numAmmounts[i] = diceVals.Count(s => s == i);
                }
                int tempScore = 0;
                if (numAmmounts.Max() == 5)
                {
                    tempScore = 12;
                }
                else if (numAmmounts.Max() == 4)
                {
                    tempScore = 6;
                }
                else if (numAmmounts.Max() == 3)
                {
                    tempScore = 3;
                }
                return tempScore;
            }
            
            
        }
    }
}