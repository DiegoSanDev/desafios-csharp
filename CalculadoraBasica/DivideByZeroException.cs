namespace CalculadoraBasica
{
    public class DivideByZeroException : Exception
    {
        public DivideByZeroException()
        {
        }

        public DivideByZeroException(string message) : base(message)
        {
        }
    }
}
