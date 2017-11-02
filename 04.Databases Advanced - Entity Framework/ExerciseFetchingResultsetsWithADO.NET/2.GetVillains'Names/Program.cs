namespace _2.GetVillains_Names
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Program
    {
        static void Main()
        {
            SqlConnection connection = new SqlConnection(@"Server = (localdb)\MSSQLLocalDB; Database = MinionsDB; Integrated Security = true;");
            connection.Open();

           string query = @"SELECT v.Name, COUNT(vm.MinionId) AS 'MinionsCount' FROM Viliains AS v
                            INNER JOIN VillainsMinions AS vm
                            ON v.Id = vm.VillainId
                            GROUP BY v.Name
                            HAVING COUNT(vm.MinionId) > 3
                            ORDER BY MinionsCount DESC";
            SqlCommand command = new SqlCommand(query, connection);

            using (connection)
            {
               SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Console.WriteLine(reader[0] + " - " + reader[1]);
                }
            }
         
        }
    }
}
