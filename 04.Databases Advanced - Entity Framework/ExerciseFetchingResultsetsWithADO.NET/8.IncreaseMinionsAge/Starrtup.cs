namespace _8.IncreaseMinionsAge
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Starrtup
    {
        static void Main()
        {
            SqlConnection connection = new SqlConnection(@"Server = (localdb)\MSSQLLocalDB; Database = MinionsDB; Integrated Security = true;");
            connection.Open();

            var input = Console.ReadLine();
            int[] minionsId = input.Split(' ').Select(int.Parse).ToArray();

            string query = @"SELECT Id, Name, Age FROM Minions";
            SqlCommand allMinions = new SqlCommand(query, connection);
            using (connection)
            {

                for (int i = 0; i < minionsId.Length; i++)
                {
                string updateQuery = @"UPDATE Minions SET Age = Age + 1 WHERE Id = @minionIdd";
                SqlCommand update = new SqlCommand(updateQuery, connection);
                    update.Parameters.AddWithValue("@minionIdd", minionsId[i]);
                    update.ExecuteNonQuery();
                }
                

                var reader = allMinions.ExecuteReader();  
                while(reader.Read())
                {
                    Console.WriteLine($"{reader[0]} {reader[1]} {reader[2]}");
                }
            }
        }
    }
}
