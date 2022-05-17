namespace OOP_Assessment_2
{
    /*
     * Dice interface so that all dice classes
     * must have roll and reset methods
     */
    public interface IDie
    {
        public void RollDie();
        public void ResetDie();
    }
    /*
     * Abstract dice class used to create the
     * declare the variables used in the main
     * dice class
     */
    public abstract class AbsDie
    {
        private int _number;
        private int _sides;
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }
        /*
         * private and public number sides
         * using getter and setter, prevents
         * invalid integers from being
         * assigned
         */
        public int Sides
        {
            get { return _sides; }
            set
            {
                int[] validSideNumbers = { 2, 4, 6, 8, 10, 12, 20 };
                _sides = validSideNumbers.Contains(value) ? value : 6;
            }
        }
    }
    /*
     * Die class (inherits the Die interface
     * and the abstract Die Class, is then
     * instantiated in a list of Dice in the
     * Dice class and encapsulates the
     * variable
     */
    public class Die : AbsDie, IDie
    {
        // Die class constructor 
        public Die(int tempSides)
        {
            Number = 0;
            Sides = tempSides;
        }
        /*
         * RollDie method randomly generates a
         * value between 1 and the number of
         * sides of the die while ResetDie
         * Method returns the die value to 0.
         */ 
        public void RollDie()
        {
            Random r = new Random();
            Number = r.Next(minValue: 1, maxValue: Sides + 1);
        }
        public void ResetDie()
        {
            Number = 0;
        }
    }
    /*
     * the dice class is used to execute
     * methods on an array of dice.
     */
    public class Dice
    {
        // initialization of array of dice
        private Die[] _dicearr = new Die[5];
        /*
         * private and public number sides
         * using getter and setter, prevents
         * invalid integers from being
         * assigned, and encapsulates the
         * variable
         */
        private int _sides;
        public int Sides
        {
            get { return _sides; }
            set
            {
                int[] validSideNumbers = { 2, 4, 6, 8, 10, 12, 20 };
                _sides = validSideNumbers.Contains(value) ? value : 6;
            }
        }
        /*
         * Dice initializer:
         *  moves through array of dice and
         *  initializes each individual die
         */
        public Dice(int tempSides)
        {
            Sides = tempSides;
            for (int i = 0; i < 5; i++)
            {
                _dicearr[i] = new Die(tempSides);
            }
        }
        /*
         * Roll/ResetDice method goes through
         * array of dice and calls each
         * individual die's Roll/ResetDie
         * Method.
         */
        public void RollDice()
        {
            foreach (Die d in _dicearr)
            {
                d.RollDie();
            }
        }
        public void ResetDice()
        {
            foreach (Die d in _dicearr)
            {
                d.ResetDie();
            }
        }
        /*
         * ReturnDiceVals method returns a
         * integer array of the die's
         * number.
         */
        public int[] ReturnDiceVals()
        {
            int[] vals = new int[5];
            for (int i = 0; i < 5; i++)
            {
                vals[i] = _dicearr[i].Number;
            }
            return vals;
        }
        /*
         * GenerateScore method creates a
         * score based on the list of die
         * values:
         *      3 of a kind = 3pts
         *      4 of a kind = 6pts
         *      5 of a kind = 12pts
         */
        public int GenerateScore()
        {
            /*
             * creates a list based on the
             * amount of a certain number
             * (between 1 and _sides) in the
             * dice.
             */
            int[] numAmmounts = new int[_sides + 1];
            for (int i = 0; i <= _sides; i++)
            {
                numAmmounts[i] = _dicearr.Count(s => s.Number == i);
            }
            /*
             * returns a number of associated
             * points based on the maximum
             * number of a single item.
             */
            if      (numAmmounts.Max() == 5) { return 12; }
            else if (numAmmounts.Max() == 4) { return 6; }
            else if (numAmmounts.Max() == 3) { return 3; }
            else                             { return 0; }
        }
        /*
         * rethrow query checks if a two of
         * a kind (and no more) has been
         * scored.
         */
        public bool RethrowQuery()
        {
            /*
             * creates a list based on the
             * amount of a certain number
             * (between 1 and _sides) in the
             * dice.
             */
            int[] numAmmounts = new int[_sides + 1];
            for (int i = 0; i <= _sides; i++)
            {
                numAmmounts[i] = _dicearr.Count(s => s.Number == i);
            }
            /*
             * returns true if the maximum
             * number of a single item is 2.
             */
            return numAmmounts.Max() == 2;
        }
    }
}