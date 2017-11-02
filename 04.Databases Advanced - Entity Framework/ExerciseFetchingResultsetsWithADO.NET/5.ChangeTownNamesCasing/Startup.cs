namespace _5.ChangeTownNamesCasing
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Startup
    {
        public static object Sqlconnection { get; private set; }

        static void Main()
        {
            SqlConnection connection = new SqlConnection(@"Server = (localdb)\MSSQLLocalDB; Database = MinionsDB; Integrated Security = true;");
            connection.Open();
            
            string countryName = Console.ReadLine();
            string query = @"SELECT TownName FROM Towns WHERE CountryName = @country";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@country", countryName);

            using (connection)
            {
                SqlDataReader reader = command.ExecuteReader();
                List<string> towns = new List<string>();
                while(reader.Read())
                {
                    towns.Add((string)reader[0]);
                }
                reader.Close();

                List<string> townsChanges = new List<string>();
                foreach (var town in towns)
                {
                    if(town != town.ToUpper())
                    {
                        townsChanges.Add(town.ToUpper());
                        string update = @"UPDATE Towns SET TownName = @upperName WHERE TownName = @townName";
                        SqlCommand commandUpdate = new SqlCommand(update, connection);
                        commandUpdate.Parameters.AddWithValue("@upperName", town.ToUpper());
                        commandUpdate.Parameters.AddWithValue("@townName", town);
                        commandUpdate.ExecuteNonQuery();
                    }
                }

                if(townsChanges.Count != 0)
                {
                    Console.WriteLine($"{townsChanges.Count} towns were affected");
                    Console.WriteLine($"[{string.Join(",",townsChanges)}]");
                }
                else
                {
                    Console.WriteLine("No town names were affected.");
                }
            }
        }
    }
}
