using System;

namespace OOP_Assessment_2
{
    class Program
    {
        static void Main()
        {
            /*
             * creates a menu object to allow the user
             * to either start the game or exit the program
             */
            MenuUI menuUIObj = new MenuUI();
            // loops until the program is exited
            while (menuUIObj.PlayGame())
            {
                // begins game
                Game.Play();
            }
            MenuUI.EndMessage();
        }
    }
}

