using System;

class PipeInPool
{
    static void Main()
    {
        var volume = int.Parse(Console.ReadLine());
        var flowFirstPipe = int.Parse(Console.ReadLine());
        var flowSecondPipe = int.Parse(Console.ReadLine());
        var hour = double.Parse(Console.ReadLine());
        var firstPipe = flowFirstPipe * hour;
        var secondPipe = flowSecondPipe * hour;
        var allSum = firstPipe + secondPipe;

        var firstPipeProcent = Math.Truncate((firstPipe / allSum) * 100);
        var secondPipeProcent = Math.Truncate((secondPipe / allSum) * 100);
        var totalProcent = Math.Truncate((allSum / volume) * 100);

        if (allSum<=volume)
        {
            Console.WriteLine("The pool is {0}% full. Pipe 1: {1}%. Pipe 2: {2}%.", totalProcent, firstPipeProcent, secondPipeProcent);
        }
        else
        {
            Console.WriteLine("For {0} hours the pool overflows with {1} liters.", hour, allSum-volume);
        }
    }
}

