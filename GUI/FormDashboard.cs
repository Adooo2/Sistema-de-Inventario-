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
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
           
            lblTotalProductos.Text = "120";
            lblStockBajo.Text = "15";
            lblTotalCategorias.Text = "8";
            lblTotalProveedores.Text = "12";
        }

        private void panelTotalProductos_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
