using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class Inventario
    {
        public int IdInventario { get; private set; }
        public List<Producto> Productos { get; private set; }
        public DateTime FechaUltimaActualizacion { get; set; }

        public Inventario(int idInventario)
        {
            IdInventario = idInventario;
            Productos = new List<Producto>();
            FechaUltimaActualizacion = DateTime.Now;
        }

        public void AgregarProducto(Producto producto)
        {
            Productos.Add(producto);
            FechaUltimaActualizacion = DateTime.Now;
        }
    }
}