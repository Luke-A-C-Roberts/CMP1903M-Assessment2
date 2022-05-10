namespace OOP_Assessment_2
{
    public interface IDie
    {
        public void RollDie();
        public void ResetDie();
    }
    public abstract class AbsDie
    {
        private int _number;
        private int _sides;
        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }
        public int Sides
        {
            get { return _sides; }
            set
            {
                int[] validSideNumbers = { 4, 6, 8, 10, 12, 20 };
                _sides = validSideNumbers.Contains(value) ? value : 6;
            }
        }
    }
    public class Die : AbsDie, IDie
    {
        public Die(int tempSides)
        {
            Number = 0;
            Sides = tempSides;
        }
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
    public class Dice
    {
        private Die[] _dicearr = new Die[5];
        public readonly int NumberOfDice = 5;
        public Dice(int sides)
        {
            for (int i = 0; i < 5; i++)
            {
                _dicearr[i] = new Die(sides);
            }
        }
        public void RollDice()
        {
            for (int i = 0; i < 5; i++)
            {
                _dicearr[i].RollDie();
            }
        }
        public int[] ReturnDiceVals()
        {
            int[] vals = new int[5];
            for (int i = 0; i < 5; i++)
            {
                vals[i] = _dicearr[i].Number;
            }
            return vals;
        }
    }
}