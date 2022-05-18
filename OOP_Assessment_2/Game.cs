namespace OOP_Assessment_2
{
    //Game setup and loop
    public class Game
    {
        public static void Play()
        {
            /*
             * object instantiation of game,
             * player, UI and Dice objects;
             */
            GameUI gameuiObj = new GameUI();
            HumanPlayer humanPlayerObj = new HumanPlayer();
            AIPlayer aiPlayerObj = new AIPlayer();
            //player names assigned
            humanPlayerObj.CreateName(gameuiObj.AskUserName());
            aiPlayerObj.CreateName();
            //number of dice asked for
            Dice diceObj = new Dice(gameuiObj.AskDiceNum());

            bool quitGame = false;

            //game loop
            while (humanPlayerObj.Score < 50
                   && aiPlayerObj.Score < 50)
            {
                // players go
                diceObj.ResetDice();
                /*
                 * player can either choose to
                 * roll the dice or quit the
                 * game.
                 */
                quitGame = gameuiObj.RollMessage(humanPlayerObj.Name,false);
                if (quitGame) { break; }
                diceObj.RollDice(); //rolls dice
                gameuiObj.DisplayDiceNums(diceObj.ReturnDiceVals(), diceObj.Sides);
                humanPlayerObj += diceObj.GenerateScore(); //generates score based on roll
                gameuiObj.DisplayScore(humanPlayerObj.Score, humanPlayerObj.Name);
                // second roll if double scored
                if (diceObj.RethrowQuery())
                {
                    diceObj.ResetDice();
                    /*
                     * player can either choose to
                     * roll the dice or quit the
                     * game.
                     */
                    quitGame = gameuiObj.RollMessage(humanPlayerObj.Name,true);
                    if (quitGame) { break; }
                    diceObj.RollDice(); //rolls dice
                    gameuiObj.DisplayDiceNums(diceObj.ReturnDiceVals(), diceObj.Sides);
                    humanPlayerObj += diceObj.GenerateScore(); //generates score based on roll
                    gameuiObj.DisplayScore(humanPlayerObj.Score, humanPlayerObj.Name);
                }
                
                //computer go
                diceObj.ResetDice();
                /*
                 * player can either choose to
                 * roll the dice or quit the
                 * game.
                 */
                quitGame = gameuiObj.RollMessage(aiPlayerObj.Name,false);
                if (quitGame) { break; }
                diceObj.RollDice(); //rolls dice
                gameuiObj.DisplayDiceNums(diceObj.ReturnDiceVals(), diceObj.Sides);
                aiPlayerObj += diceObj.GenerateScore(); //generates score based on roll
                gameuiObj.DisplayScore(aiPlayerObj.Score, aiPlayerObj.Name);
                // second roll if double scored
                if (diceObj.RethrowQuery())
                {
                    diceObj.ResetDice();
                    quitGame = gameuiObj.RollMessage(aiPlayerObj.Name,true);
                    /*
                     * player can either choose to
                     * roll the dice or quit the
                     * game.
                     */
                    if (quitGame) { break; }
                    diceObj.RollDice(); //rolls dice
                    gameuiObj.DisplayDiceNums(diceObj.ReturnDiceVals(), diceObj.Sides);
                    aiPlayerObj += diceObj.GenerateScore(); //generates score based on roll
                    gameuiObj.DisplayScore(aiPlayerObj.Score,aiPlayerObj.Name);
                }
            }
        }
    }
}