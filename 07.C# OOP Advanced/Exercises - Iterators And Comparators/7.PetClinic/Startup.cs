namespace _7.PetClinic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _7.PetClinic.Entities;

    public class Startup
    {
        private static Dictionary<string, Pet> allPets = new Dictionary<string, Pet>();
        private static Dictionary<string, Clinic> allClinics = new Dictionary<string, Clinic>();

        public static void Main(string[] args)
        {
            var commandCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandCount; i++)
            {
                var commandTokens = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var commandType = commandTokens[0];
                commandTokens.RemoveAt(0);
                switch (commandType)
                {
                    case "Create":
                        CreateEntity(commandTokens);
                        break;
                    case "Add":
                        AddPetToClinic(commandTokens[0], commandTokens[1]);
                        break;
                    case "Release":
                        ReleasePetFromClinic(commandTokens[0]);
                        break;
                    case "HasEmptyRooms":
                        CheckForEmptyRooms(commandTokens[0]);
                        break;
                    case "Print":
                        PrintInfo(commandTokens);
                        break;
                }
            }
        }

        private static void PrintInfo(List<string> commandTokens)
        {
            var currentClinic = allClinics[commandTokens[0]];
            var result = string.Empty;

            if (commandTokens.Count == 1)
            {
                result = currentClinic.Print();
            }
            else
            {
                var roomIndex = int.Parse(commandTokens[1]);
                result = currentClinic.Print(roomIndex);
            }

            Console.WriteLine(result);
        }

        private static void CheckForEmptyRooms(string clinicName)
        {
            var currentClinic = allClinics[clinicName];
            Console.WriteLine(currentClinic.HasEmptyRooms());
        }

        private static void ReleasePetFromClinic(string clinicName)
        {
            var currentClinic = allClinics[clinicName];

            Console.WriteLine(currentClinic.TryReleasePet());
        }

        private static void AddPetToClinic(string petName, string clinicName)
        {
            var currentPet = allPets[petName];
            var currentClinic = allClinics[clinicName];

            if (currentClinic.TryAddPet(currentPet))
            {
                Console.WriteLine(true);
                allPets.Remove(petName);
                return;
            }

            Console.WriteLine(false);

        }

        private static void CreateEntity(List<string> commandTokens)
        {
            var entityType = commandTokens[0];
            if (entityType == "Pet")
            {
                var name = commandTokens[1];
                var age = int.Parse(commandTokens[2]);
                var kind = commandTokens[3];
                allPets.Add(name, new Pet(name, age, kind));
            }
            else if (entityType == "Clinic")
            {
                var name = commandTokens[1];
                var roomsNumber = int.Parse(commandTokens[2]);
                try
                {
                    allClinics.Add(name, new Clinic(name, roomsNumber));
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);

                }
            }
        }
    }
}
