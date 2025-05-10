using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        // Constructor con parámetros
        public Producto(int idProducto, string nombre, decimal precio, int stock)
        {
            IdProducto = idProducto;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
            Descripcion = string.Empty;
            Estado = true;
        }

        [Key] // este atributo le dice a entity framework que esta es clave primaria
        public int IdProducto { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }

        [Required]
        
        public decimal Precio { get; set; }

        [Required]
        public int Stock { get; set; }

        public bool Estado { get; set; } = true;

        // Relación con Categoría
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }

        // Metodo para actualizar el stock
        public void ActualizarStock(int cantidad)
        {
            if (Stock + cantidad >= 0)
                Stock += cantidad;
            else
                throw new Exception("Stock no puede ser negativo.");
        }
    }
}