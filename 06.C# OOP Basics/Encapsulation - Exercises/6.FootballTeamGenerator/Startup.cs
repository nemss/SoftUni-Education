namespace _6.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            List<Team> listTeams = new List<Team>();
            string inputLine;
            while (!(inputLine = Console.ReadLine()).Equals("END"))
            {
                var tokens = inputLine.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Team":
                        listTeams.Add(new Team(tokens[1]));
                        break;
                    case "Add":
                        var teamName = tokens[1];
                        var playerName = tokens[2];
                        var endurance = int.Parse(tokens[3]);
                        var sprint = int.Parse(tokens[4]);
                        var dribble = int.Parse(tokens[5]);
                        var passing = int.Parse(tokens[6]);
                        var shooting = int.Parse(tokens[7]);

                        var teamExisting = listTeams.Any(t => t.Name == teamName);
                        Team team;
                        if (!teamExisting)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            break;
                        }

                        try
                        {
                            team = listTeams.FirstOrDefault(t => t.Name == teamName);
                            var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                            team.AddPlayer(player);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "Remove":
                        teamName = tokens[1];
                        playerName = tokens[2];
                        team = listTeams.FirstOrDefault(t => t.Name == teamName);

                        try
                        {
                            team.RemovePlayer(playerName);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case "Rating":
                        teamName = tokens[1];
                        teamExisting = listTeams.Any(t => t.Name == teamName);
                        if (!teamExisting)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            break;
                        }

                        team = listTeams.FirstOrDefault(t => t.Name == teamName);
                        Console.WriteLine($"{team.Name} - {team.CalculatingRaiting()}");
                        break;
                }

            }
        }
    }
}
