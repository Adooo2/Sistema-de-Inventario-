using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class Categoria
    {
        public int IdCategoria { get; private set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Categoria(int idCategoria, string nombre)
        {
            IdCategoria = idCategoria;
            Nombre = nombre;
            Descripcion = string.Empty;
        }
    }
}
