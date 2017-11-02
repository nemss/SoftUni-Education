namespace _3.DependencyInversion
{
    using _3.DependencyInversion.Strategies;
    using System.Collections.Generic;

    public class PrimitiveCalculator
    {
        private IStrategy strategy;

        private Dictionary<char, IStrategy> strategies = new Dictionary<char, IStrategy>()
        {
            {'+', new AdditionStrategy() },
            {'-', new SubtractionStrategy() },
            {'/', new DivideStrategy() },
            {'*', new MultiplyStrategy() }
        };

        public PrimitiveCalculator()
        {
            this.strategy = strategies['+'];
        }

        public void ChangeStrategy(char @operator)
        {
            this.strategy = this.strategies[@operator];
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.strategy.Calculate(firstOperand, secondOperand);
        }
    }
}