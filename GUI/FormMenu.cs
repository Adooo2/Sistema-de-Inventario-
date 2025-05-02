using BLL;
using EL;
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
    public partial class FormMenu : Form
    {
        // Instancias de las capas BLL
        private readonly ProveedorBLL _proveedorBLL = new ProveedorBLL();
        // Descomenta esta línea cuando ProductoBLL esté sin errores
        private readonly ProductoBLL _productoBLL = new ProductoBLL();
        // private readonly CategoriaBLL _categoriaBLL = new CategoriaBLL();

        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

            CargarDatosMenu();

        }

        private void CargarDatosMenu()
        {
            try
            {
                
                int totalProveedores = _proveedorBLL.ObtenerTodos().Count;
                lblTotalProveedores.Text = totalProveedores.ToString();

                
                int totalProductos = _productoBLL.ObtenerTotalProductos();
                List<Producto> productosStockBajo = _productoBLL.ObtenerProductosStockBajo(10);

                lblTotalProductos.Text = totalProductos.ToString();
                lblStockBajo.Text = productosStockBajo.Count.ToString();

                // valor estático hasta implementar CategoriaBLL
                lblTotalCategorias.Text = "8";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Pregunto al usuario si está seguro de cerrar sesión
            if (MessageBox.Show("¿Estás seguro que deseas cerrar sesión?",
                              "Confirmar",
                              MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Creo una nueva instancia del formulario de login
                FormLogin login = new FormLogin();

                // Muestro el login
                login.Show();

                // Cierro el formulario actual
                this.Hide(); // En lugar de Close(), uso Hide() para mantener el formulario activo

                // Agrego un manejador para detectar cuando se cierre el formulario de login
                login.FormClosed += (s, args) => this.Close();
            }
        }
    }
}