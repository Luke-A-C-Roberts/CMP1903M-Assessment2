//exceptions used in UI
namespace UserDefinedException
{
    //exception if input is empty
    public class NullOrEmptyInput : Exception
    {
        public NullOrEmptyInput() :
            base("Input is null or empty."){}
    }
    //exception for incorrect number of dice selected
    public class IncorrectDiceNumber : Exception
    {
        public IncorrectDiceNumber() :
            base("The number of dice inputted is not a valid integer."){}
    }
    //exception for incorrect input in MenuUI.PlayGame method
    public class IncorrectBeginGameInput : Exception
    {
        public IncorrectBeginGameInput() :
            base("The input was not \"play\" or \"exit\""){}
    }
}