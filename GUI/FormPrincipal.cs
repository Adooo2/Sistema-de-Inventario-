using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
                AbrirFormEnPanel(new FormMenu());
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
        // esto es cuando le dan click 
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormMenu());
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
            AbrirFormEnPanel(new FormProveedores());
        }

        private void btnEntradas_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormEntradas());
        }

        private void btnSalidas_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormSalidas());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new FormReportes());
        }

        private void panelContenido_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pbLogo_Click(object sender, EventArgs e)
        {
           
        }
            private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Pregunto al usuario si está seguro de cerrar sesión
            if (MessageBox.Show("¿Estás seguro que deseas cerrar sesión?",
                              "Confirmar",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FormLogin login = new FormLogin();
                // Muestro el login
                login.Show();
                // Cierro el formulario actual
                this.Hide();
                // Agrego un manejador para detectar cuando se cierre el formulario de login
                login.FormClosed += (s, args) => this.Close();
            }
        }
    }
    
}