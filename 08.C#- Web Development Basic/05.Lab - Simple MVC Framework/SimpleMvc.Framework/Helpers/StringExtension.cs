namespace SimpleMvc.Framework.Helpers
{
    using System.Linq;

    public static class StringExtension
    {
        public static string Capitialize(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            var firstLetter = input.First();
            var rest = input.Substring(1);

            return $"{firstLetter}{rest}";
        }
    }
}