namespace _3.DependencyInversion
{
    using _3.DependencyInversion.Strategies;

    public class SubtractionStrategy : IStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand - secondOperand;
        }
    }
}