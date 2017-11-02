namespace Speed
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();
            var list = new HashSet<string>();
            for (int i = 0; i < 10000000; i++)
            {
                list.Add(i.ToString());
            }

            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

            watch = Stopwatch.StartNew();
            list.Contains("888888");
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
        }
    }
}
