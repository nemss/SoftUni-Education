using System;

class EqualPairs
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int currentSum = 0;
        int previousSum = 0;
        int maxDiff = 0;
        int currentDiff = 1;

        for (int i = 1; i <= n; i++)
        {
            previousSum = currentSum;
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            currentSum = a + b;
            currentDiff = Math.Abs(currentSum - previousSum);
            if (currentDiff > maxDiff && i >= 2)
            {
                maxDiff = currentDiff;
            }
        }
        if (maxDiff == 0)
        {
            Console.WriteLine("Yes value={0}" , currentSum);
        }
        else
        {
            Console.WriteLine("No, maxdiff={0}", currentDiff);
        }
    }

}