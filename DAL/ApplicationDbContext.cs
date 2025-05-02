using System;
using System.Data.Entity;
using EL;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        //  cadena de conexión directamente
        public ApplicationDbContext()
            : base("Data Source=.\\SQLEXPRESS;Initial Catalog=SistemaInventario;Integrated Security=True")
        {
            // Para crear la base de datos si no existe
            Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }

        public DbSet<Proveedor> Proveedores { get; set; }

        public DbSet<Producto> Productos { get; set; }


        // Configuración adicional si es necesaria
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}