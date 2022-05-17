namespace OOP_Assessment_2
{
    public class Game
    {
        public static void Play()
        {
            GameUI gameuiObj = new GameUI();
            HumanPlayer humanPlayerObj = new HumanPlayer();
            AIPlayer aiPlayerObj = new AIPlayer();
            Dice diceObj = new Dice(gameuiObj.AskDiceNum());

            humanPlayerObj.Name = gameuiObj.AskUserName();

            bool quitGame = false;

            //game loop
            while (humanPlayerObj.Score < 50
                   && aiPlayerObj.Score < 50)
            {
                // players go
                diceObj.ResetDice();
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
                    quitGame = gameuiObj.RollMessage(humanPlayerObj.Name,true);
                    if (quitGame) { break; }
                    diceObj.RollDice(); //rolls dice
                    gameuiObj.DisplayDiceNums(diceObj.ReturnDiceVals(), diceObj.Sides);
                    humanPlayerObj += diceObj.GenerateScore(); //generates score based on roll
                    gameuiObj.DisplayScore(humanPlayerObj.Score, humanPlayerObj.Name);
                }
                
                //computer go
                diceObj.ResetDice();
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