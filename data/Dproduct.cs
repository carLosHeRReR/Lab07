using entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data
{
    public class Dproduct
    {
        public static string connectionString = "Data Source=LAPTOP-54SNKJH2\\SQLEXPRESS;Initial Catalog=FacturaDB;Integrated Security=true";
        public static List<Producto> ListarProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "ListarProductos";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add(new Producto
                            {
                                productid = (int)reader["product_id"],
                                Name = reader["name"].ToString(),
                                Stock = (int)reader["stock"],
                                Price = (decimal)reader["price"],
                                Active = (bool)reader["active"]
                            });
                        }
                    }
                }
            }
            return productos;
        }
    }
}
