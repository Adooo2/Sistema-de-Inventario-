using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class Producto
    {
        public int IdProducto { get; private set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public Producto(int idProducto, string nombre, decimal precio, int stock)
        {
            IdProducto = idProducto;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
            Descripcion = string.Empty;
        }

        public void ActualizarStock(int cantidad)
        {
            if (Stock + cantidad >= 0)
                Stock += cantidad;
            else
                throw new Exception("Stock no puede ser negativo.");
        }
    }
}