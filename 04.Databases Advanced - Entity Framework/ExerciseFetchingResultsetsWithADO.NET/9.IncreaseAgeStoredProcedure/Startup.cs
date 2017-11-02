namespace _9.IncreaseAgeStoredProcedure
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main()
        {
            SqlConnection connection = new SqlConnection(@"Server = (localdb)\MSSQLLocalDB; Database = MinionsDB; Integrated Security = true;");
            connection.Open();

            int minionId = int.Parse(Console.ReadLine());
            string query = @"usp_GetOlder";
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType =CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@minionId", minionId);

            using (connection)
            {
                command.ExecuteNonQuery();

                string secondQuery = @"SELECT Name, Age, From WHERE Id = @MinionId";
                SqlCommand minion = new SqlCommand(secondQuery, connection);
                minion.Parameters.AddWithValue("@MinionId", minionId);

                SqlDataReader reader = minion.ExecuteReader();
                while(reader.Read())
                {
                    Console.WriteLine($"{reader[0]} {reader[1]}");
                }
            }
        }
    }
}
