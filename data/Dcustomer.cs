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
    internal class Dcustomer
    {
        private static string connectionString = "Data Source=LAPTOP-54SNKJH2\\SQLEXPRESS;Initial Catalog=FacturaDB;Integrated Security=true";

        private static List<Cliente> ListarClientes(string ciudad, string region)
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
                                    Customer_ID = int.Parse(reader["IdCliente"].ToString()),
                                    Name = reader["NombreContacto"].ToString(),
                                    Address = reader["Ciudad"].ToString(),
                                    Phone = reader["Pais"].ToString(),
                                    Active = bool.Parse(reader["active"].ToString())
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
