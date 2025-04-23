using System;
using System.Windows.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Mostrar el formulario de login primero
            FormLogin login = new FormLogin();

            // Si el login es exitoso, mostrar el formulario principal
            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FormPrincipal());
            }
        }
    }
}