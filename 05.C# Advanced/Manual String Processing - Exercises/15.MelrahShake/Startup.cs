namespace _15.MelrahShake
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var text = Console.ReadLine();
            var pattern = Console.ReadLine();

            while (true)
            {
                var firstIndex = text.IndexOf(pattern);
                var secondIndex = text.LastIndexOf(pattern);

                if (firstIndex == -1 || firstIndex == secondIndex)
                {
                    break;;
                }

                text = text.Remove(secondIndex, pattern.Length);
                text = text.Remove(firstIndex, pattern.Length);
                Console.WriteLine("Shaked it.");
                if (pattern.Length <= 1)
                {
                    break;
                }
                pattern = pattern.Remove(pattern.Length / 2, 1);
            }

            Console.WriteLine("No shake." + Environment.NewLine + text);
        }
    }
}
