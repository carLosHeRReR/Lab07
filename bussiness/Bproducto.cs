using data;
using entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bussiness
{
    public class Bproducto
    {
        public List<Producto> ListarProducto()
        {
            List<Producto> productos = new List<Producto>();
            return productos;
        }
        public List<Producto> BuscarPorNombre(string name)
        {
            List<Producto> products = new List<Producto>();
            products = Dproduct.ListarProductos();

            var resul = products.Where(x => x.Name.Contains(name)).ToList();

            return resul;
        }
    }
}
