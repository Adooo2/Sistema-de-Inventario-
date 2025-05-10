using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using EL;

namespace GUI
{
    public partial class FormEntradas : Form
    {
        private readonly EntradaInventarioBLL _entradaBLL;
        private readonly ProductoBLL _productoBLL;
        private readonly ProveedorBLL _proveedorBLL;
        private List<EntradaInventario> _entradas;

        public FormEntradas()
        {
            InitializeComponent();
            _entradaBLL = new EntradaInventarioBLL();
            _productoBLL = new ProductoBLL();
            _proveedorBLL = new ProveedorBLL();

            this.Load += new EventHandler(FormEntradas_Load);
            btnAgregar.Click += new EventHandler(btnAgregar_Click);
            btnEditar.Click += new EventHandler(btnEditar_Click);
            btnEliminar.Click += new EventHandler(btnEliminar_Click);
            txtBuscar.TextChanged += new EventHandler(txtBuscar_TextChanged);
        }

        private void FormEntradas_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarEntradas();
        }

        private void ConfigurarDataGridView()
        {
            dgvEntradas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEntradas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEntradas.MultiSelect = false;
            dgvEntradas.ReadOnly = true;

            // Limpiar columnas existentes
            dgvEntradas.Columns.Clear();

            // Agregar columnas
            dgvEntradas.Columns.Add("Id", "ID");
            dgvEntradas.Columns.Add("Fecha", "Fecha");
            dgvEntradas.Columns.Add("Producto", "Producto");
            dgvEntradas.Columns.Add("Proveedor", "Proveedor");
            dgvEntradas.Columns.Add("Cantidad", "Cantidad");
            dgvEntradas.Columns.Add("PrecioCompra", "Precio Compra");
            dgvEntradas.Columns.Add("Total", "Total");
            dgvEntradas.Columns.Add("Observaciones", "Observaciones");

            // Ocultar columna ID
            dgvEntradas.Columns["Id"].Visible = false;
        }

        private void CargarEntradas()
        {
            try
            {
                _entradas = _entradaBLL.ObtenerTodas();

                dgvEntradas.Rows.Clear();

                foreach (var entrada in _entradas)
                {
                    decimal total = entrada.Cantidad * entrada.PrecioCompra;
                    dgvEntradas.Rows.Add(
                        entrada.IdEntrada,
                        entrada.Fecha.ToString("dd/MM/yyyy HH:mm"),
                        entrada.Producto?.Nombre ?? "Producto no encontrado",
                        entrada.Proveedor?.Nombre ?? "Proveedor no encontrado",
                        entrada.Cantidad,
                        entrada.PrecioCompra.ToString("C"),
                        total.ToString("C"),
                        entrada.Observaciones
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar entradas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                FormEntradasDetalle formDetalle = new FormEntradasDetalle();
                if (formDetalle.ShowDialog() == DialogResult.OK)
                {
                    CargarEntradas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir formulario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEntradas.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt32(dgvEntradas.SelectedRows[0].Cells["Id"].Value);
                    EntradaInventario entrada = _entradaBLL.ObtenerPorId(id);

                    if (entrada != null)
                    {
                        FormEntradasDetalle formDetalle = new FormEntradasDetalle(entrada);
                        if (formDetalle.ShowDialog() == DialogResult.OK)
                        {
                            CargarEntradas();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la entrada seleccionada",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar entrada: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una entrada para editar",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEntradas.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt32(dgvEntradas.SelectedRows[0].Cells["Id"].Value);

                    DialogResult result = MessageBox.Show(
                        "¿Está seguro de eliminar esta entrada? Se actualizará el stock del producto.",
                        "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        bool eliminado = _entradaBLL.Eliminar(id);

                        if (eliminado)
                        {
                            MessageBox.Show("Entrada eliminada correctamente",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarEntradas();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar la entrada",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar entrada: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una entrada para eliminar",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarEntradas();
        }

        private void FiltrarEntradas()
        {
            try
            {
                string filtro = txtBuscar.Text.Trim().ToLower();

                dgvEntradas.Rows.Clear();

                var entradasFiltradas = _entradas;

                if (!string.IsNullOrEmpty(filtro))
                {
                    entradasFiltradas = _entradas.FindAll(e =>
                        (e.Producto?.Nombre?.ToLower() ?? "").Contains(filtro) ||
                        (e.Proveedor?.Nombre?.ToLower() ?? "").Contains(filtro) ||
                        (e.Observaciones?.ToLower() ?? "").Contains(filtro) ||
                        e.Fecha.ToString("dd/MM/yyyy").Contains(filtro));
                }

                foreach (var entrada in entradasFiltradas)
                {
                    decimal total = entrada.Cantidad * entrada.PrecioCompra;
                    dgvEntradas.Rows.Add(
                        entrada.IdEntrada,
                        entrada.Fecha.ToString("dd/MM/yyyy HH:mm"),
                        entrada.Producto?.Nombre ?? "Producto no encontrado",
                        entrada.Proveedor?.Nombre ?? "Proveedor no encontrado",
                        entrada.Cantidad,
                        entrada.PrecioCompra.ToString("C"),
                        total.ToString("C"),
                        entrada.Observaciones
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar entradas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelBotones_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}