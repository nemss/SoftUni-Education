namespace _02BlackBoxInteger
{
    using System;
    using System.Reflection;

    internal class BlackBoxIntegerTests
    {
        private static void Main(string[] args)
        {
            var getClass = typeof(BlackBoxInt);
            var blackBoxCtror = getClass.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
            var number = (BlackBoxInt)blackBoxCtror.Invoke(new object[] { });
            var getField = getClass.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);

            var inputLine = string.Empty;
            while (!(inputLine = Console.ReadLine()).Equals("END"))
            {
                var tokens = inputLine.Split('_');
                var operation = tokens[0];
                var num = int.Parse(tokens[1]);

                var getMethod = getClass.GetMethod(operation, BindingFlags.Instance | BindingFlags.NonPublic);
                getMethod.Invoke(number, new object[] { num });

                Console.WriteLine(getField.GetValue(number));
            }
        }
    }
}