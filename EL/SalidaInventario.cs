using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EL
{
    public class SalidaInventario
    {
        [Key]
        public int IdSalida { get; set; }

        public int ProductoId { get; set; }

        [ForeignKey("ProductoId")]
        public virtual Producto Producto { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public decimal PrecioVenta { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public string Motivo { get; set; }

        public bool Estado { get; set; } = true;

        public SalidaInventario()
        {
            Fecha = DateTime.Now;
            Motivo = string.Empty;
        }
        public string Observaciones { get; set; }
    }
}