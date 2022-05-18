namespace OOP_Assessment_2
{
    /*
     * DiceRollCharacter class, used in
     * dice roll animation sequence.
     */
    public class DiceRollCharacter
    {
        //color list
        readonly ConsoleColor[] _consoleColorList =
        {
            ConsoleColor.Blue,
            ConsoleColor.Cyan,
            ConsoleColor.Green,
            ConsoleColor.Magenta,
            ConsoleColor.Red,
            ConsoleColor.Yellow,
            ConsoleColor.DarkBlue,
            ConsoleColor.DarkCyan,
            ConsoleColor.DarkGreen,
            ConsoleColor.DarkMagenta,
            ConsoleColor.DarkRed,
            ConsoleColor.DarkYellow
        };
        private string _numString;
        private int _sides;
        private ConsoleColor _numColor;
        /*
         * random class used for picking random
         * values.
         */
        private Random r = new Random();
        /*
         * multiple initializers for
         * DiceRollCharacters with and without
         * a predetermined value
         */
        public DiceRollCharacter(int tempSides)
        {
            _sides = tempSides;
            _numString = r.Next(minValue: 1, maxValue: _sides).ToString();
            _numColor = _consoleColorList[r.Next(minValue: 0, maxValue: 12)];
        }
        public DiceRollCharacter(int tempNum, int tempSides)
        {
            _sides = tempSides;
            _numString = tempNum.ToString();
            _numColor = _consoleColorList[r.Next(minValue: 0, maxValue: 12)];
        }
        //prints the character with colour
        public void Printchar()
        {
            Console.ForegroundColor = _numColor;
            Console.Write($"{_numString} ");
        }
    }
    /*
     * abstract UI class used for common
     * methods for the game and menu UIs.
     */
    public abstract class AbsUI
    {
        /*
         * methods for quickly changing text
         * colour.
         */
        protected static void Highlight()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        protected static void ErrorHighlight()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        protected static void Unhighlight()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        /*
         * Show Error method allows the user
         * to read error methods without the
         * program terminating ungracefully.
         */
        protected static void ShowError(Exception e)
        {
            ErrorHighlight();
            Console.WriteLine("Show Error message [y/n]");
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            while (true)
            {
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Y)
                {
                    Console.WriteLine($"\n{e}");
                    break;
                }
                if (cki.Key == ConsoleKey.N)
                {
                    Console.WriteLine("\n");
                    break;
                }
            }
            Unhighlight();
        }
    }
    /*
     * Game UI class, handles IO in the Play
     * method in the game class.
     */
    public class GameUI : AbsUI
    {
        /*
         * asks the user for a name for the
         * HumanPlayer object.
         */
        public string AskUserName()
        {
            string name;
            while (true)
            {
                Unhighlight();
                Console.Write("enter your name: ");
                Highlight();
                name = Console.ReadLine();
                Unhighlight();
                /*
                 * throws an error if the
                 * input is incorrect.
                 */
                try
                {
                    if (!String.IsNullOrEmpty(name))
                    {
                        break;
                    }
                    else
                    {
                        throw new UserDefinedException.NullOrEmptyInput();
                    }
                }
                catch (Exception e)
                {
                    ErrorHighlight();
                    Console.WriteLine("Incorrect Input!");
                    ShowError(e);
                }
            }
            return name;
        }
        /*
         * RollMessage method asks for the
         * user to either quit the game or
         * throw the dice.
         */
        public bool RollMessage(string name, bool doReroll)
        {
            // re-roll dice message
            if (doReroll)
            {
                Highlight();
                Console.Write($"{name} ");
                Unhighlight();
                Console.WriteLine("scored a double, so they are able to re-roll to up their score");
            }
            Highlight();
            Console.Write($"({name}) ");
            Unhighlight();
            Console.WriteLine("Press ENTER to roll or press q to quit");
            //loops until correct key is pressed
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            while (true)
            {
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Enter)
                {
                    return false;
                }

                if (cki.Key == ConsoleKey.Q)
                {
                    return true;
                }
            }
        }
        /*
         * DisplayDiceNums Method plays an
         * animation for dice rolls
         */
        public void DisplayDiceNums(int[] diceVals,int sides)
        {
            //plays a list of DiceChars to be displayed
            List<DiceRollCharacter> DiceChars = new List<DiceRollCharacter>();

            //initializes each dicechar
            foreach (int i in diceVals)
            {
                DiceRollCharacter d = new DiceRollCharacter(i,sides);
                DiceChars.Add(d);
            }
            
            //prints randomised dice characters
            for (int i = 0; i < 20; i++)
            {
                Console.Clear();
                foreach (int j in diceVals)
                {
                    DiceRollCharacter d = new DiceRollCharacter(sides);
                    d.Printchar();
                }
                Thread.Sleep(50);
            }
            Console.Clear();
            
            // prints the final diceroll.
            foreach (DiceRollCharacter d in DiceChars)
            {
                   d.Printchar();
            }
            Thread.Sleep(300);
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        // displays the score of a player
        public void DisplayScore(int score, string name)
        {
            Highlight();
            Console.Write($"{name}");
            Unhighlight();
            Console.Write("'s score = ");
            Highlight();
            Console.WriteLine($"{score}");
            Unhighlight();
        }
        //asks how many dice are wanted to play
        public int AskDiceNum()
        {
            string input = "";
            int num = default;
            while (true)
            {
                Unhighlight();
                Console.Write("how many sides of the dice would you like?\n" + 
                              "(Accepted Values 2, 4, 6, 8, 10, 12 and 20)\n");
                try
                {
                    Highlight();
                    input = Console.ReadLine();
                    Unhighlight();
                    // throws error if the input is empty
                    if (string.IsNullOrEmpty(input))
                    {
                        throw new UserDefinedException.NullOrEmptyInput();
                    }
                    /*
                     * converts the input to integer
                     * which additionally throws an
                     * error if the input is not a number
                     */
                    num = int.Parse(input);
                    /*
                     * throws an error if the value
                     * inputted is invalid
                     */
                    int[] allowedSides = { 2, 4, 6, 8, 10, 12, 20 };
                    if (allowedSides.Contains(num) == false)
                    {
                        throw new UserDefinedException.IncorrectDiceNumber();
                    }
                    break;
                }
                // error catch
                catch (Exception e)
                {
                    ErrorHighlight();
                    Console.WriteLine("Input Not valid");
                    ShowError(e);
                    Unhighlight();
                }
            }
            return num;
        }
    }
    class MenuUI : AbsUI
    {
        //asks the user to either play game or quit
        public bool PlayGame()
        {
            string input = default;
            while (true)
            {
                Console.Write("Please write ");
                Highlight();
                Console.Write("\"play\" ");
                Unhighlight();
                Console.Write("to begin game or ");
                Highlight();
                Console.Write("\"exit\" ");
                Unhighlight();
                Console.Write("to end the program. ");
                try
                {
                    Highlight();
                    input = Console.ReadLine().ToLower();
                    Unhighlight();
                    // throws error if the input is empty
                    if (string.IsNullOrEmpty(input))
                    {
                        throw new UserDefinedException.NullOrEmptyInput();
                    }
                    //throws an error if the input is incorrect
                    if (!(input == "play" 
                          || input == "exit"))
                    {
                        throw new UserDefinedException.IncorrectBeginGameInput();
                    }
                    break;
                }
                //error catch
                catch (Exception e)
                {
                    ErrorHighlight();
                    Console.WriteLine("Input not valid!");
                    ShowError(e);
                }
            }
            return input == "play";
        }
        //end message of program
        public static void EndMessage()
        {
            Highlight();
            Console.WriteLine("Have a good day!");
            Unhighlight();
        }
    }
}
