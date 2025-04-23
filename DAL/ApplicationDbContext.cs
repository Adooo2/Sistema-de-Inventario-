using System;
using System.Data.Entity;
using System.Collections.Generic;
using EL;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        // este es un constructor que nos permite trabajar sin una base de datos real
        public ApplicationDbContext() : base("name=ConexionBD")
        {
            // esto es para que no intente crear la base de datos
            Database.SetInitializer<ApplicationDbContext>(null);
        }

        public DbSet<Proveedor> Proveedores { get; set; }
    }
}