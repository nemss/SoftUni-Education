namespace _6.RemoveVillain
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
            int villainId = int.Parse(Console.ReadLine());

            using (connection)
            {
                SqlTransaction delete = connection.BeginTransaction();

                string queryVillains = @"SELECT  Id, Name FROM Viliains WHERE Id = @villainId";
                SqlCommand villains = new SqlCommand(queryVillains, connection);
                villains.Parameters.AddWithValue("@villainId", villainId);

                string queryDeleteVillains = @"DELETE FROM Viliains WHERE Id = @villainId";
                SqlCommand deleteVillains = new SqlCommand(queryDeleteVillains, connection);
                deleteVillains.Parameters.AddWithValue("@villainId", villainId);

                string queryDeleteVillainsMinions = @"DELETE FROM VillainsMinions WHERE VillainId = @villainId";
                SqlCommand deleteVillainsMinions = new SqlCommand(queryDeleteVillainsMinions, connection);
                deleteVillainsMinions.Parameters.AddWithValue("@villainId", villainId);

                villains.Transaction = delete;
                SqlDataReader reader = villains.ExecuteReader();

                if(!reader.HasRows)
                {
                    reader.Close();
                    delete.Rollback();
                    Console.WriteLine("No suh villain was found");
                }
                else
                {
                    reader.Read();
                    var villainName = (string)reader["Name"];
                    reader.Close();

                    deleteVillainsMinions.Transaction = delete;
                    var deletedVillainsMinions = deleteVillainsMinions.ExecuteNonQuery();

                    deleteVillains.Transaction = delete;
                    var deletedVillains = deleteVillains.ExecuteNonQuery();

                    delete.Commit();

                    Console.WriteLine($"{villainName} was deleted");
                    Console.WriteLine($"{deletedVillainsMinions} were realeased");
                }
            }
        }
    }
}
