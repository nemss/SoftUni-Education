using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] fields)
    {
        var getClass = Type.GetType(investigatedClass);
        var classFields = getClass.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
                                             BindingFlags.NonPublic);

        var sb = new StringBuilder();
        var classIstance = Activator.CreateInstance(getClass, new object[] { });

        sb.AppendLine($"Class under investigation: {investigatedClass}");

        foreach (var fied in classFields.Where(f => fields.Contains(f.Name)))
        {
            sb.AppendLine($"{fied.Name} = {fied.GetValue(classIstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        var getClass = Type.GetType(className);
        var getClassFields = getClass.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        var getPublicMethod = getClass.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        var getNonPublickMethod = getClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        var sb = new StringBuilder();

        foreach (var field in getClassFields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var method in getNonPublickMethod.Where(g => g.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in getPublicMethod.Where(g => g.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string investigatedClass)
    {
        var getClass = Type.GetType(investigatedClass);
        var getMethods = getClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        var sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {investigatedClass}");
        sb.AppendLine($"Base Class: {getClass.BaseType.Name}");

        foreach (var method in getMethods)
        {
            sb.AppendLine($"{method.Name}");
        }

        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string investigatedClass)
    {
        var getClass = Type.GetType(investigatedClass);
        var getMethods = getClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        var sb = new StringBuilder();

        foreach (var method in getMethods.Where(f => f.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in getMethods.Where(f => f.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return sb.ToString().Trim();
    }
}