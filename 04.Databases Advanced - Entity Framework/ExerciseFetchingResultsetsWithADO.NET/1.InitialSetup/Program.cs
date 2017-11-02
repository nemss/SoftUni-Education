namespace _1.InitialSetup
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        public static object SQL { get; private set; }

        static void Main()
        {
            string query = File.ReadAllText(@"C:\Programs\vs\Databases Advanced - Entity Framework\ExerciseFetchingResultsetsWithADO.NET\1.InitialSetup\InitialSetup.sql");
            SqlConnection connection = new SqlConnection(@"Server= (localdb)\MSSQLLocalDB; Integrated Security = true;");

            connection.Open();
            string sqlCreateDB = "CREATE DATABASE MinionsDB";
            SqlCommand createDBCommand = new SqlCommand(sqlCreateDB, connection);
            SqlCommand createTablesCommand = new SqlCommand(query, connection);
           
            using (connection)
            {
                createDBCommand.ExecuteNonQuery();
                Console.WriteLine(createTablesCommand.ExecuteNonQuery());
            }
        }
    }
}
