using System;
using System.Windows.Forms;
using DAL;
using System.Linq;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // Inicializa la base de datos
                using (var context = new ApplicationDbContext())
                {
                    context.Database.CreateIfNotExists();
                    if (!context.Proveedores.Any())
                    {
                        context.Proveedores.Add(new EL.Proveedor
                        {
                            Nombre = "Distribuidor Test",
                            Telefono = "555-1234",
                            Email = "test@ejemplo.com",
                            Direccion = "Calle Test 123",
                            Estado = true
                        });
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al inicializar la base de datos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Mostrar el formulario de login primero
            FormLogin login = new FormLogin();

            // Si el login es exitoso mostrar el formulario principal
            if (login.ShowDialog() == DialogResult.OK)
            {
                
                FormPrincipal principal = new FormPrincipal();
                Application.Run(principal);
            }
        }
    }
}