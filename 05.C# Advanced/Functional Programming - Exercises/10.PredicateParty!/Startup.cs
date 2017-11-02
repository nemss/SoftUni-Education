namespace Problem_10.Predicate_Party_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {

        public static void Main(string[] args)
        {
            List<string> invitationsList
                = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            invitationsList = GetInput(invitationsList);

            PrintResul(invitationsList);

        }

        private static List<string> GetInput(List<string> invitationsList)
        {
            string command = Console.ReadLine();

            while (command != "Party!")
            {
                List<string> commands = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string action = commands[0];
                string criteria = commands[1];
                string parameter = commands[2];


                switch (action)
                {
                    case "Double":
                        invitationsList.AddRange(MakeItDouble(invitationsList, criteria, parameter));

                        break;
                    case "Remove":
                        List<string> temp =
                            invitationsList.Except(SendOut(invitationsList, criteria, parameter)).ToList();

                        invitationsList = temp;
                        break;
                }
                command = Console.ReadLine();
            }

            return invitationsList;
        }

        private static void PrintResul(List<string> invitationsList)
        {
            if (invitationsList.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", invitationsList)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static List<string> SendOut(List<string> invitationsList, string criteria, string parameter)
        {
            List<string> tempList = new List<string>();

            switch (criteria)
            {
                case "StartsWith":
                    tempList = StartWith(invitationsList, parameter);
                    break;
                case "Length":

                    tempList = Lenght(invitationsList, parameter);
                    break;
                case "EndsWith":
                    tempList = EndtWith(invitationsList, parameter);
                    break;
            }

            return tempList;
        }


        private static List<string> MakeItDouble(List<string> invitationsList, string criteria, string parameter)
        {
            List<string> tempList = new List<string>();

            switch (criteria)
            {
                case "StartsWith":
                    tempList = StartWith(invitationsList, parameter);
                    break;
                case "Length":

                    tempList = Lenght(invitationsList, parameter);
                    break;
                case "EndsWith":
                    tempList = EndtWith(invitationsList, parameter);
                    break;
            }

            return tempList;
        }


        static List<string> StartWith(List<string> list, string param)
        {
            Predicate<string> start = x => x.StartsWith(param);
            List<string> tempList = list.FindAll(start);
            return tempList;
        }

        static List<string> EndtWith(List<string> list, string param)
        {
            Predicate<string> end = x => x.EndsWith(param);
            List<string> tempList = list.FindAll(end);
            return tempList;
        }

        static List<string> Lenght(List<string> list, string param)
        {
            Predicate<string> len = x => x.Length == int.Parse(param);
            List<string> tempList = list.FindAll(len);
            return tempList;
        }

    }
}