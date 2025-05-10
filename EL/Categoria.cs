using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; } = true;

        // Constructor sin parámetros para Entity Framework
        public Categoria()
        {
            Nombre = string.Empty;
            Descripcion = string.Empty;
        }

        // Constructor con parámetros
        public Categoria(int idCategoria, string nombre, string descripcion)
        {
            IdCategoria = idCategoria;
            Nombre = nombre;
            Descripcion = descripcion;
            Estado = true;
        }
    }
} 