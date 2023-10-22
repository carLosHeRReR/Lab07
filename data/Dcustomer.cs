using entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data
{
    public class Dcustomer
    {
        public static string connectionString = "Data Source=LAPTOP-54SNKJH2\\SQLEXPRESS;Initial Catalog=FacturaDB;Integrated Security=true";

        public static List<Cliente> ListarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();
                string query = "ListarClientes";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Verificar si hay filas
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Leer los datos de cada fila
                                clientes.Add(new Cliente
                                {
                                    CustomerID = (int)reader["Customer_id"],
                                    Name = reader["name"].ToString(),
                                    Address = reader["address"].ToString(),
                                    Phone = reader["phone"].ToString(),
                                    Active = (bool)reader["active"],
                                });

                            }
                        }
                    }
                }   

                // Cerrar la conexión
                connection.Close();


            }
            return clientes;

        }

    }
}
