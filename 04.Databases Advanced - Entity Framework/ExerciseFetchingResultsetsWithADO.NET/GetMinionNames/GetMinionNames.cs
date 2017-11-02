namespace GetMinionNames
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

            Console.Write("Enter vilainId: ");
            int vilainId = int.Parse(Console.ReadLine());
            string query = @"SELECT  v.Name,m.Name FROM Viliains AS v
                            INNER JOIN VillainsMinions AS vm
                            ON v.Id = vm.VillainId
                            INNER JOIN Minions AS m
                            ON vm.MinionId = m.Id
                            WHERE v.Id = @VilianId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@VilianId", vilainId);

            using (connection)
            {
                var reader = command.ExecuteReader();

                if(!reader.HasRows)
                {
                    Console.WriteLine($"No viliain with ID {vilainId} exist in the database.");
                    return;
                }
                else
                {
                    reader.Read();
                    string villainName = reader[0].ToString();
                    Console.WriteLine($"Villain: {villainName}");

                    while(reader.Read())
                    {
                        Console.WriteLine(reader[1]);
                    }
                }
              
                 }
            }
        }
    }

