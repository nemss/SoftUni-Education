namespace _01HarestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    internal class HarvestingFieldsTest
    {
        private static void Main(string[] args)
        {
            var getClass = typeof(HarvestingFields);
            var getAllFields = getClass.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var isRunning = true;

            while (isRunning)
            {
                var inputLine = Console.ReadLine();
                switch (inputLine)
                {
                    case "private":
                        Console.WriteLine(PrintFields(getAllFields.Where(f => f.IsPrivate)));
                        break;

                    case "protected":
                        Console.WriteLine(PrintFields(getAllFields.Where(f => f.IsFamily)));
                        break;

                    case "public":
                        Console.WriteLine(PrintFields(getAllFields.Where(f => f.IsPublic)));
                        break;

                    case "all":
                        Console.WriteLine(PrintFields(getAllFields));
                        break;

                    case "HARVEST":
                        isRunning = false;
                        break;
                }
            }
        }

        private static string PrintFields(IEnumerable<FieldInfo> fields)
        {
            var sb = new StringBuilder();

            foreach (var field in fields)
            {
                var fieldAttribute = field.Attributes.ToString().ToLower();

                sb.AppendLine($"{fieldAttribute.Replace("family", "protected")} {field.FieldType.Name} {field.Name}");
            }

            return sb.ToString().Trim();
        }
    }
}