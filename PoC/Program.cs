using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace PoC
{
     class Program
    {
        static void Main(string[] args)
        {
            
            string connectionString = "Data Source=DESKTOP-FOFJDA6;Initial Catalog=PoCDB;Integrated Security=True";

            
            Console.WriteLine("Digite o item que deseja inserir:");
            string item = Console.ReadLine();

            string query = "INSERT INTO dbo.itens (Nome) VALUES (@Nome)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                
                command.Parameters.AddWithValue("@Nome", item);

                try
                {
                    
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Item inserido com sucesso!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro: " + ex.Message);
                }
            }

            
            Console.ReadLine();
        }
    }
}
