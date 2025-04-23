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
    public partial class FormCategorias : Form
    {
        public FormCategorias()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.FormCategorias_Load); // Asocia el evento Load
        }
        private void FormCategorias_Load(object sender, EventArgs e)
        {
            // Agregar columnas
            dgvCategorias.Columns.Add("Id", "ID");
            dgvCategorias.Columns.Add("Nombre", "Nombre");
            dgvCategorias.Columns.Add("Descripcion", "Descripción");

            // Configuración del DataGridView
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajustar columnas automáticamente
            dgvCategorias.AllowUserToAddRows = false; // Evitar filas vacías

            // Datos de prueba
            dgvCategorias.Rows.Add(1, "Granos", "Arroz, frijol, maíz");
            dgvCategorias.Rows.Add(2, "Lácteos", "Leche, queso, yogur");
            dgvCategorias.Rows.Add(3, "Bebidas", "Jugos, gaseosas, café");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Agregar categoría (en desarrollo)");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Editar categoría (en desarrollo)");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Eliminar categoría (en desarrollo)");
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}