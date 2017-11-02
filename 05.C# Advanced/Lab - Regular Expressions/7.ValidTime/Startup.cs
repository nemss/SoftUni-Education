namespace _7.ValidTime
{
    using System;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var pattern = @"^((([0][0-9]|[1][0-1]):[0-5][0-9]:[0-5][0-9] [AP]M)|12:00:00 [PA]M)$";

            while (input != "END")
            {
                var regex = new Regex("^((([0][0-9]|[1][0-1]):[0-5][0-9]:[0-5][0-9] [AP]M)|12:00:00 [PA]M)$");
                var match = regex.Match(input);

                if (match.Success)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }

                input = Console.ReadLine();
            }
        }
    }
}
