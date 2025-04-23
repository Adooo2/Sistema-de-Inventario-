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
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            InitializeComponent();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            // esto sirve para responsive design
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbCategoria.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // configurar DataGridView
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //datos de prueba
            CargarDatosPrueba();
        }

        private void CargarDatosPrueba()
        {
            // Agregar filas de ejemplo
            dgvProductos.Rows.Add(1, "P001", "Arroz", "Arroz blanco 1kg", 25.50, 100, "Granos", "Proveedor A");
            dgvProductos.Rows.Add(2, "P002", "Frijol", "Frijol negro 1kg", 30.00, 80, "Granos", "Proveedor B");
            dgvProductos.Rows.Add(3, "P003", "Azúcar", "Azúcar refinada 1kg", 22.80, 120, "Endulzantes", "Proveedor C");
            dgvProductos.Rows.Add(4, "P004", "Aceite", "Aceite vegetal 1L", 45.50, 60, "Aceites", "Proveedor A");
            dgvProductos.Rows.Add(5, "P005", "Sal", "Sal refinada 1kg", 15.00, 150, "Condimentos", "Proveedor D");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad para agregar producto en desarrollo", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            // tengo que hacer un formulario para agregar producto
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                MessageBox.Show("Funcionalidad para editar producto en desarrollo", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Aquí igual pero para editar
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto para editar", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este producto?",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    MessageBox.Show("Funcionalidad para eliminar producto en desarrollo", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // aquí tengo que implementar la eliminación del producto seleccionado
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto para eliminar", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // aqui implementre la búsqueda dinámica pero cuando tengas la base de datos de momento no la tengo aun :( 
            string filtro = txtBuscar.Text.Trim().ToLower();

            // asi que ahora solo saldra un mensaje 
            // esto se usará para filtrar los resultados del datagridview
            if (filtro.Length > 2)
            {
                MessageBox.Show("Buscando: " + filtro, "Búsqueda",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Aquí implementare el filtrado por categoría cuando tengas la base de datos
            if (cmbCategoria.SelectedIndex > 0) 
            {
                string categoria = cmbCategoria.SelectedItem.ToString();
                MessageBox.Show("Filtrando por categoría: " + categoria, "Filtro",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }   } 
            private void FormProductos_Resize(object sender, EventArgs e)
        {
            // actualización del layout al redimensionar
            this.PerformLayout();
        }

       
    }
} 