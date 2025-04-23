using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormPrincipal : Form
    {
       

        private Form formActivo = null;

        public FormPrincipal()
        {
            InitializeComponent();
            PersonalizarDiseno();
        }

        private void PersonalizarDiseno()
        {

            this.Text = "Sistema de Inventario - Tienda de Abarrotes";
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            try
            {

                AbrirFormEnPanel(new FormDashboard());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el dashboard: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirFormEnPanel(Form formHijo)
        {

            if (formActivo != null)
                formActivo.Close();


            formActivo = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;


            panelContenido.Controls.Add(formHijo);
            panelContenido.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }


        private void btnDashboard_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormDashboard());
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormProductos());

        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormCategorias());
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            {
                // Abrimos el formulario de proveedores dentro del panel principal
                AbrirFormEnPanel(new FormProveedores());
            }

        }

        private void btnEntradas_Click(object sender, EventArgs e)
        {
            // esto muestra temporalmente  un mensaje en lugar de abrir el formulario
            MessageBox.Show("Módulo de Entradas en desarrollo", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnSalidas_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Módulo de Salidas en desarrollo", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnReportes_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Módulo de Reportes en desarrollo", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void panelContenido_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnDashboard_Click_1(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormDashboard());
        }

        private void FormPrincipal_Load_1(object sender, EventArgs e)
        {

        }

        private void btnProveedores_Click_1(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormProveedores());
        }
    }
}