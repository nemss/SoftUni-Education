using System;

class CubeProperties
{
    static void Main()
    {
        var side = double.Parse(Console.ReadLine());
        var parameter = Console.ReadLine();

        GetResultFromCalculate(side, parameter);
    }

    static void GetResultFromCalculate(double side, string parameter)
    {
        var result = 0.0;
        if (parameter == "face")
        {
            result = GetFace(side);
            Console.WriteLine("{0:F2}", result);
        }
        else if (parameter == "space")
        {
            result = GetSpace(side);
            Console.WriteLine("{0:F2}", result);
        }
        else if (parameter == "volume")
        {
            result = GetVolume(side);
            Console.WriteLine("{0:F2}", result);
        }
        else if (parameter == "area")
        {
            result = GetSurfaceArea(side);
            Console.WriteLine("{0:F2}", result);
        }
    }

    static double GetSurfaceArea(double side)
    {
        var cubeArea = 6 * Math.Pow(side, 2);
        return cubeArea;
    }

    static double GetVolume(double side)
    {
        double cubeVolume = Math.Pow(side, 3);
        return cubeVolume;
    }

    static double GetSpace(double side)
    {
        var cubeSpace = Math.Sqrt(3 * Math.Pow(side, 2));
        return cubeSpace;
    }

    static double GetFace(double side)
    {
        var cubeFace = Math.Sqrt(2 * Math.Pow(side, 2));
        return cubeFace;
    }
}