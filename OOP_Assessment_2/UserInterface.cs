namespace OOP_Assessment_2
{
    public class GameUI
    {
        public string AskUserName()
        {
            string name;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("enter your name: ");
                name = Console.ReadLine();
                if (!String.IsNullOrEmpty(name))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect Input! ");
                }
            }
            return name;
        }
    }
}
