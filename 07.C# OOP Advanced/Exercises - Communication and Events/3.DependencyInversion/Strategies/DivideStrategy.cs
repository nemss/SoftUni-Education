namespace _3.DependencyInversion.Strategies
{
    public class DivideStrategy : IStrategy
    {
        public int Calculate(int first, int second)
        {
            return first / second;
        }
    }
}