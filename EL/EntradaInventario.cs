using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EL
{
    public class EntradaInventario
    {
        [Key]
        public int IdEntrada { get; set; }

        public int ProductoId { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Producto Producto { get; set; }

        public int ProveedorId { get; set; }

        [ForeignKey("ProveedorId")]
        public virtual Proveedor Proveedor { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal PrecioCompra { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public string Observaciones { get; set; }

        public bool Estado { get; set; } = true;

        public EntradaInventario()
        {
            Fecha = DateTime.Now;
            Observaciones = string.Empty;
        }
    }
}