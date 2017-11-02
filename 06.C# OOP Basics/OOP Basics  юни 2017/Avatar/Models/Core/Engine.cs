using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private NationsBuilder nationsBuilder;

    public Engine()
    {
        nationsBuilder = new NationsBuilder();
    }

    public void Run()
    {
        string inputLine;
        while (!(inputLine = Console.ReadLine()).Equals("Quit"))
        {
            var tokens = inputLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
            ExecuteCommand(tokens);
        }

        Console.WriteLine(this.nationsBuilder.GetWarsRecord());
    }

    public void ExecuteCommand(List<string> tokens)
    {
        var command = tokens[0];
        var info = tokens.Skip(1).ToList();
        switch (command)
        {
            case "Bender":
                this.nationsBuilder.AssignBender(info);
                break;
            case "Monument":
                this.nationsBuilder.AssignMonument(info);
                break;
            case "Status":
                Console.WriteLine(this.nationsBuilder.GetStatus(info[0]));
                break;
            case "War":
                this.nationsBuilder.IssueWar(info[0]);
                break;
        }
    }
}
