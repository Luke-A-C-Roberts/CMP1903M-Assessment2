namespace UserDefinedExceptions
{
    public class NullOrEmptyInput : Exception
    {
        public NullOrEmptyInput() :
            base("Input is null or empty."){}
    }

    public class IncorrectDiceNumber : Exception
    {
        public IncorrectDiceNumber() :
            base("The number of dice inputted is not a valid integer."){}
    }
}