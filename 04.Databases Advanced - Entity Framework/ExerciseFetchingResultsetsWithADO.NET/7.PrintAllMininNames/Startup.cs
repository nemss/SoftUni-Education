namespace _7.PrintAllMininNames
{
    using System;
    using System.Collections.Generic;
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

            string query = @"SELECT Name FROM Minions";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
                var reader = command.ExecuteReader();
                List<string> names = new List<string>();
                while(reader.Read())
                {
                    names.Add((string)reader[0]);
                }

                PrintNames(names);
            }
        }

        private static void PrintNames(List<string> names)
        {
            int firstIndex = 0;
            int lastIndex = names.Count - 1;

            for (int i = 0; i < names.Count; i++)
            {
                int currentIndex;

                if (i % 2 == 0)
                {
                    currentIndex = firstIndex;
                    firstIndex++;
                }
                else
                {
                    currentIndex = lastIndex;
                    lastIndex--;
                }

                Console.WriteLine(names[currentIndex]);
            }
        }
    }
}
