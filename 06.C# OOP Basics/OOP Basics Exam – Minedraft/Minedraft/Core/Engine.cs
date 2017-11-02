using System;
using System.Linq;

public class Engine
{
    private DraftManager draftManager;

    public Engine()
    {
        this.draftManager = new DraftManager();
    }

    public void Run()
    {
        bool isRunning = true;
        while (isRunning)
        {
            var inputLine = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var command = inputLine[0];
            inputLine = inputLine.Skip(1).ToList();

            switch (command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(draftManager.RegisterHarvester(inputLine));
                    break;

                case "RegisterProvider":
                    Console.WriteLine(draftManager.RegisterProvider(inputLine));
                    break;

                case "Day":
                    Console.WriteLine(draftManager.Day());
                    break;

                case "Mode":
                    Console.WriteLine(draftManager.Mode(inputLine));
                    break;

                case "Check":
                    Console.WriteLine(draftManager.Check(inputLine));
                    break;

                case "Shutdown":
                    isRunning = false;
                    Console.WriteLine(draftManager.ShutDown());
                    break;
            }
        }
    }
}