using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var startUp = typeof(StartUp);
        var methods = startUp.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

        foreach (var method in methods)
        {
            if (method.CustomAttributes.Any(a => a.AttributeType == typeof(SoftUniAttribute)))
            {
                var attrs = method.GetCustomAttributes(false);
                foreach (SoftUniAttribute attr in attrs)
                {
                    Console.WriteLine($"{method.Name} is writen by {attr.Name}");
                }
            }
        }
    }
}