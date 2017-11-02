namespace _4.AddMinion
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class AddMinion
    {
        static void Main()
        {

            SqlConnection connection = new SqlConnection(@"Server = (localdb)\MSSQLLocalDB; Database = MinionsDB; Integrated Security = true;");
           
            string minion = Console.ReadLine();
            string villain = Console.ReadLine();

            string[] minionInformation = minion.Split(':')[1].Trim().Split(' ');
            string[] villainInformation = villain.Split(':')[1].Trim().Split(' ');

            string minionName = minionInformation[0];
            int minionAge = int.Parse(minionInformation[1]);
            string minionTownName = minionInformation[2];

            string villainName = villainInformation[0];

            using (connection)
            {
                connection.Open();
                if(!CheckIfTownExist(minionTownName, connection))
                {
                    AddTown(minionTownName, connection);
                }

                if(!CheckIfVillainName(villainName, connection))
                {
                    AddVillainName(villainName, connection);
                }

                int townId = GetTownIdByName(minionTownName, connection);
                AddMinionName(minionName,minionAge ,townId, connection);
                int minionId = GetMinionIdByName(minionName, connection);
                int villainId = GetVillainByName(villainName, connection);

                AddMinianToVillain(minionId, villainId, connection);
                Console.WriteLine($"Successfully added {minionName} to be minion of Gru.");
            }

        }

        private static int GetTownIdByName(string minionTownName, SqlConnection connection)
        {
            int townId = 0;
            string query = "SELECT Id FROM Towns WHERE TownName = @townName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@townName", minionTownName);
            townId = (int)command.ExecuteScalar();
            return townId;
        }

        private static void AddMinianToVillain(int minionId, int villainId, SqlConnection connection)
        {
            string query = "INSERT INTO VillainsMinions VALUES (@minionId, @villainId)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@minionId", minionId);
            command.Parameters.AddWithValue("@villainId", villainId);
            command.ExecuteNonQuery();
        }

        private static int GetVillainByName(string villainName, SqlConnection connection)
        {
            int villainId = 0;
            string query = "SELECT Id FROM Viliains WHERE Name = @villainName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@villainName", villainName);
            villainId = (int)command.ExecuteScalar();
            return villainId;
        }

        private static int GetMinionIdByName(string minionName, SqlConnection connection)
        {
            int minionId = 0;
            string query = "SELECT Id FROM Minions WHERE Name = @minionName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@minionName", minionName);
            minionId = (int)command.ExecuteScalar();
            return minionId;
        }

        private static void AddMinionName(string minionName,int age , int townId ,SqlConnection connection)
        {
            string query = "INSERT INTO Minions(Name, Age, TownId) VALUES (@minionName, @minionAge, @minionTownId)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@minionName", minionName);
            command.Parameters.AddWithValue("@minionAge", age);
            command.Parameters.AddWithValue("@minionTownId", townId);
            command.ExecuteNonQuery();
        }

        private static bool CheckIfVillainName(string villainName, SqlConnection connection)
        {
            string query = "SELECT COUNT(*) FROM Viliains WHERE Name = @villainName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@villainName", villainName);

            if ((int)command.ExecuteScalar() == 0)
            {
                return false;
            }
            return true;
        }

        private static void AddVillainName(string villainName, SqlConnection connection)
        {
            string query = "INSERT INTO Viliains (Name, EvilnessFactor) VALUES (@villainsName, 'evil')";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@villainsName", villainName);

            command.ExecuteNonQuery();

            Console.WriteLine($"Villain {villainName} was added to the database.");
        }

        private static void AddTown(string minionTownName, SqlConnection connection)
        {
            string query = "INSERT INTO Towns (TownName) VALUES (@townName)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@townName", minionTownName);

            command.ExecuteNonQuery();
            Console.WriteLine($"Town {minionTownName} was added to the database.");
        }

        private static bool CheckIfTownExist(string minionTownName, SqlConnection connection)
        {
            string query = "SELECT COUNT(*) FROM Towns WHERE TownName = @townName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@townName", minionTownName);

            if((int)command.ExecuteScalar() == 0)
            {
                return false;
            }
            return true;
        }
    }
}
