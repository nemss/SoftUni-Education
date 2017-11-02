namespace _11.ThePartyReservationFilterModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class Startup
    {
        public static void Main(string[] args)
        {
                List<string> invitationsList
                    = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                string command = Console.ReadLine();
                List<string> commandHistory = new List<string>();
                command = AgregateCommand(command, commandHistory);
                ExecuteCommand(invitationsList, commandHistory);
                PrintResult(invitationsList);

            }

            private static void ExecuteCommand(List<string> invitationsList, List<string> commandHistory)
            {
                foreach (var row in commandHistory)
                {
                    List<string> commands = row.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    string filter = commands[0];
                    string parameter = commands[1];

                    switch (filter)
                    {
                        //"Starts with", "Ends with", "Length" and "Contains". 
                        case "Starts with":
                            Predicate<string> start = x => x.StartsWith(parameter);
                            invitationsList.RemoveAll(start);
                            break;
                        case "Ends with":
                            Predicate<string> end = x => x.EndsWith(parameter);
                            invitationsList.RemoveAll(end);
                            break;
                        case "Length":
                            Predicate<string> len = x => x.Length == int.Parse(parameter);
                            invitationsList.RemoveAll(len);
                            break;
                        case "Contains":
                            Predicate<string> con = x => x.Contains(parameter);
                            invitationsList.RemoveAll(con);
                            break;
                    }
                }
            }

            private static string AgregateCommand(string command, List<string> commandHistory)
            {
                while (command != "Print")
                {
                    List<string> commands = command.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    string comm = commands[0];
                    string filter = commands[1];
                    string parameter = commands[2];

                    if (comm == "Add filter")
                    {
                        commandHistory.Add(filter + ";" + parameter);
                    }

                    if (comm == "Remove filter")
                    {
                        commandHistory.Remove(filter + ";" + parameter);
                    }

                    command = Console.ReadLine();
                }

                return command;
            }

            private static void PrintResult(List<string> invitationsList)
            {
                if (invitationsList.Count > 0)
                {
                    Console.WriteLine($"{string.Join(" ", invitationsList)}");
                }
            }
        }
    }
