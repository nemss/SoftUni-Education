namespace SystemSplit
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SystemSplit.Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var computer = new List<HardwareComponents>();
            var dump = new List<HardwareComponents>();

            string inputLine;
            while (!(inputLine = Console.ReadLine()).Equals("System Split"))
            {
                var tokens = inputLine.Split(new char[] {'(', ')'}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();
                var command = tokens[0];

                switch (command)
                {
                    case "RegisterPowerHardware":
                        Command.RegisterPowerHardware(computer, tokens[1]);
                        break;
                    case "RegisterHeavyHardware":
                        Command.RegisterHeavyHardware(computer, tokens[1]);
                        break;
                    case "RegisterExpressSoftware":
                        Command.RegisterExpressSoftware(computer, tokens[1]);
                        break;
                    case "RegisterLightSoftware":
                        Command.RegisterLightSoftware(computer, tokens[1]);
                        break;
                    case "ReleaseSoftwareComponent":
                        Command.ReleaseSoftwareComponent(computer, tokens[1]);
                        break;;
                    case "Analyze":
                        Command.Analyze(computer);
                        break;
                    case "Dump":
                        Command.Dump(dump, computer, tokens[1]);
                        break;
                    case "Restore":
                        Command.Restore(dump, computer, tokens[1]);
                        break;;
                    case "Destroy":
                        Command.Destroy(dump, tokens[1]);
                        break;
                    case "DumpAnalyze":
                        Command.DumpAnalyze(dump);
                        break;
                }
            }

            Command.SystemSplit(computer);
        }
    }
}
