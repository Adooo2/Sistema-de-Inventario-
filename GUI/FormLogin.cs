using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Ocultar mensaje de error 
            if (lblError != null)
                lblError.Visible = false;

            // validar campos
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (lblError != null)
                {
                    lblError.Text = "Por favor ingrese su email";
                    lblError.Visible = true;
                }
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                if (lblError != null)
                {
                    lblError.Text = "Por favor ingrese su contraseña";
                    lblError.Visible = true;
                }
                txtPassword.Focus();
                return;
            }

            try
            {
               
                if (txtEmail.Text == "admin" && txtPassword.Text == "admin123")
                {
                    // Aquí después se establecería el usuario actual
                    // Program.UsuarioActual = usuario;

                    // Cerrar el formulario con resultado OK
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    if (lblError != null)
                    {
                        lblError.Text = "Email o contraseña incorrectos";
                        lblError.Visible = true;
                    }
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
