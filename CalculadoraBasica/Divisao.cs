namespace CalculadoraBasica 
{
    public class Divisao : IOperacao
    {
        public double Calcular(double x, double y)
        {
            if(y == 0)
            {
                throw new DivideByZeroException("O divisor não pode ser zero.");
            }
            return x / y;
        }
    }
}