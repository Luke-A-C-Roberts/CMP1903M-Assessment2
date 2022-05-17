namespace OOP_Assessment_2
{
    public class DiceRollCharater
    {
        readonly ConsoleColor[] consoleColorList =
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
        private Random r = new Random();
        public DiceRollCharater(int tempSides)
        {
            _sides = tempSides;
            _numString = r.Next(minValue: 1, maxValue: _sides).ToString();
            _numColor = consoleColorList[r.Next(minValue: 0, maxValue: 12)];
        }
        public DiceRollCharater(int tempNum, int tempSides)
        {
            _sides = tempSides;
            _numString = tempNum.ToString();
            _numColor = consoleColorList[r.Next(minValue: 0, maxValue: 12)];
        }
        public void Randomise()
        {
            _numString = r.Next(minValue: 1, maxValue: _sides).ToString();
            _numColor = consoleColorList[r.Next(minValue: 0, maxValue: 12)];
        }
        public void Printchar()
        {
            Console.ForegroundColor = _numColor;
            Console.Write($"{_numString} ");
        }
    }

    public class GameUI
    {
        private static void Highlight()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        private static void ErrorHighlight()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        private static void Unhighlight()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private static void ShowError(Exception e)
        {
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
        }
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
                if (!String.IsNullOrEmpty(name))
                {
                    break;
                }
                else
                {
                    ErrorHighlight();
                    Console.WriteLine("Incorrect Input! ");
                }
            }
            return name;
        }
        public bool RollMessage(string name, bool doReroll)
        {
            if (doReroll)
            {
                Highlight();
                Console.WriteLine($"{name} ");
                Unhighlight();
                Console.WriteLine("scored a double, so are able to re roll to up their score");
            }
            Highlight();
            Console.WriteLine($"({name}) ");
            Unhighlight();
            Console.WriteLine("Press ENTER to roll or press q to quit");
            while (true)
            {
                ConsoleKeyInfo cki = new ConsoleKeyInfo();
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
        public void DisplayDiceNums(int[] diceVals,int sides)
        {

            List<DiceRollCharater> DiceChars = new List<DiceRollCharater>();
            List<DiceRollCharater> RandomDiceChars = new List<DiceRollCharater>();
            
            foreach (int i in diceVals)
            {
                DiceRollCharater d = new DiceRollCharater(i,sides);
                DiceChars.Add(d);
            }

            for (int i = 0; i < 20; i++)
            {
                Console.Clear();
                foreach (int j in diceVals)
                {
                    DiceRollCharater d = new DiceRollCharater(sides);
                    d.Printchar();
                }
                Thread.Sleep(50);
            }
            Console.Clear();
            foreach (DiceRollCharater d in DiceChars)
            {
                   d.Printchar();
            }
            Thread.Sleep(300);
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void DisplayScore(int score, string name)
        {
            Console.WriteLine($"{name}'s score = {score}");
        }
        public int AskDiceNum()
        {
            int num = default;
            while (true)
            {
                Unhighlight();
                Console.Write("how many sides of the dice would you like?\n" + 
                              "(Accepted Values 4, 6, 8, 10, 12 and 20)\n");
                try
                {
                    Highlight();
                    num = int.Parse(Console.ReadLine());
                    Unhighlight();
                    break;
                }
                catch (FormatException e)
                {
                    ErrorHighlight();
                    Console.WriteLine("Input Not valid");
                    ShowError(e);
                }
            }
            return num;
        }
    }
    class Menu
    {
        
    }
}
