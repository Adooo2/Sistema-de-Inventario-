using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EL
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(200)]
        public string Direccion { get; set; }

        [StringLength(15)]
        public string Telefono { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        public bool Estado { get; set; } = true; 


    }
}