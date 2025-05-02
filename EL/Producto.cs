using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EL
{
    public class Producto
    {
        // Constructor sin parámetros para entity framework
        public Producto()
        {
            Descripcion = string.Empty;
            Estado = true;
        }

        // constructor con parámetros
        public Producto(int idProducto, string nombre, decimal precio, int stock)
        {
            IdProducto = idProducto;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
            Descripcion = string.Empty;
            Estado = true;
        }

        [Key] // este atributo le dice a entity framework que esta es  clave primaria
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public bool Estado { get; set; } = true;

        public void ActualizarStock(int cantidad)
        {
            if (Stock + cantidad >= 0)
                Stock += cantidad;
            else
                throw new Exception("Stock no puede ser negativo.");
        }
    }
}