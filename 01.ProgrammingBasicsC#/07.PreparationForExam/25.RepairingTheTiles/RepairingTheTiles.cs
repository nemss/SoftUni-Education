using System;

class RepairingTheTiles
{
    static void Main()
    {
        var lengthFloor = int.Parse(Console.ReadLine());
        var widthTiles = double.Parse(Console.ReadLine());
        var lengthTiles = double.Parse(Console.ReadLine());
        var widthBench = byte.Parse(Console.ReadLine());
        var lengthBench = byte.Parse(Console.ReadLine());

        var allFloor = lengthFloor * lengthFloor;
        var allBench = widthBench * lengthBench;
        var allPlace = allFloor - allBench;
        var allTiles = widthTiles * lengthTiles;
        var neededTiles = allPlace / allTiles;
        var neededTime = neededTiles * 0.2;
        Console.WriteLine(neededTiles);
        Console.WriteLine(neededTime);
    }
}

