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
    public partial class FormSalidas : Form
    {
        // Variable para acceder a la capa de negocio
        private readonly SalidaInventarioBLL _salidaBLL;
        private readonly ProductoBLL _productoBLL;
        private List<SalidaInventario> _salidas;

        public FormSalidas()
        {
            InitializeComponent();
            _salidaBLL = new SalidaInventarioBLL();
            _productoBLL = new ProductoBLL();

            // Asociar eventos
            this.Load += new EventHandler(FormSalidas_Load);
            btnAgregar.Click += new EventHandler(btnAgregar_Click);
            btnEditar.Click += new EventHandler(btnEditar_Click);
            btnEliminar.Click += new EventHandler(btnEliminar_Click);
            txtBuscar.TextChanged += new EventHandler(txtBuscar_TextChanged);
        }

        // Método que se ejecuta al cargar el formulario
        private void FormSalidas_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarSalidas();
        }

        // Método para configurar el DataGridView
        private void ConfigurarDataGridView()
        {
            dgvSalidas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSalidas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSalidas.MultiSelect = false;
            dgvSalidas.ReadOnly = true;
            dgvSalidas.Dock = DockStyle.Fill;

            // Limpiar columnas existentes
            dgvSalidas.Columns.Clear();

            // Agregar columnas
            dgvSalidas.Columns.Add("Id", "ID");
            dgvSalidas.Columns.Add("Fecha", "Fecha");
            dgvSalidas.Columns.Add("Producto", "Producto");
            dgvSalidas.Columns.Add("Cantidad", "Cantidad");
            dgvSalidas.Columns.Add("PrecioVenta", "Precio Venta");
            dgvSalidas.Columns.Add("Total", "Total");
            dgvSalidas.Columns.Add("Destino", "Destino");
            dgvSalidas.Columns.Add("Observaciones", "Observaciones");

            // Ocultar columna ID
            dgvSalidas.Columns["Id"].Visible = false;

            // Configurar formato de las columnas
            dgvSalidas.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvSalidas.Columns["PrecioVenta"].DefaultCellStyle.Format = "C2";
            dgvSalidas.Columns["Total"].DefaultCellStyle.Format = "C2";
        }

        //para cargar las salidas en el DataGridView
        private void CargarSalidas()
        {
            try
            {
                _salidas = _salidaBLL.ObtenerTodas();

                dgvSalidas.Rows.Clear();

                foreach (var salida in _salidas)
                {
                    decimal total = salida.Cantidad * salida.PrecioVenta;
                    string nombreProducto = "Producto no encontrado";

                    // Obtener el nombre del producto
                    if (salida.Producto != null)
                    {
                        nombreProducto = salida.Producto.Nombre;
                    }
                    else
                    {
                        var producto = _productoBLL.ObtenerPorId(salida.ProductoId);
                        if (producto != null)
                        {
                            nombreProducto = producto.Nombre;
                        }
                    }

                    dgvSalidas.Rows.Add(
                        salida.IdSalida,
                        salida.Fecha.ToString("dd/MM/yyyy HH:mm"),
                        nombreProducto,
                        salida.Cantidad,
                        salida.PrecioVenta.ToString("C2"),
                        total.ToString("C2"),
                        salida.Motivo,
                        salida.Observaciones
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar salidas: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para agregar una nueva salida
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                FormSalidasDetalle formDetalle = new FormSalidasDetalle();
                if (formDetalle.ShowDialog() == DialogResult.OK)
                {
                    CargarSalidas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir formulario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para editar una salida existente
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvSalidas.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt32(dgvSalidas.SelectedRows[0].Cells["Id"].Value);
                    SalidaInventario salida = _salidaBLL.ObtenerPorId(id);

                    if (salida != null)
                    {
                        FormSalidasDetalle formDetalle = new FormSalidasDetalle(salida);
                        if (formDetalle.ShowDialog() == DialogResult.OK)
                        {
                            CargarSalidas();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la salida seleccionada",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar salida: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una salida para editar",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Método para eliminar una salida
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvSalidas.SelectedRows.Count > 0)
            {
                try
                {
                    int id = Convert.ToInt32(dgvSalidas.SelectedRows[0].Cells["Id"].Value);

                    DialogResult result = MessageBox.Show(
                        "¿Está seguro de eliminar esta salida?",
                        "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        bool eliminado = _salidaBLL.Eliminar(id);

                        if (eliminado)
                        {
                            MessageBox.Show("Salida eliminada correctamente",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarSalidas();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar la salida",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar salida: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una salida para eliminar",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Método para filtrar las salidas según el texto de búsqueda
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarSalidas();
        }

        private void FiltrarSalidas()
        {
            try
            {
                string filtro = txtBuscar.Text.Trim().ToLower();

                dgvSalidas.Rows.Clear();

                var salidasFiltradas = _salidas;

                if (!string.IsNullOrEmpty(filtro))
                {
                    salidasFiltradas = _salidas.FindAll(s =>
                        (s.Producto?.Nombre?.ToLower() ?? "").Contains(filtro) ||
                        (s.Motivo?.ToLower() ?? "").Contains(filtro) ||
                        (s.Observaciones?.ToLower() ?? "").Contains(filtro) ||
                        s.Fecha.ToString("dd/MM/yyyy").Contains(filtro) ||
                        s.Cantidad.ToString().Contains(filtro) ||
                        s.PrecioVenta.ToString().Contains(filtro));
                }

                foreach (var salida in salidasFiltradas)
                {
                    decimal total = salida.Cantidad * salida.PrecioVenta;
                    string nombreProducto = "Producto no encontrado";

                    // Obtener el nombre del producto
                    if (salida.Producto != null)
                    {
                        nombreProducto = salida.Producto.Nombre;
                    }
                    else
                    {
                        var producto = _productoBLL.ObtenerPorId(salida.ProductoId);
                        if (producto != null)
                        {
                            nombreProducto = producto.Nombre;
                        }
                    }

                    dgvSalidas.Rows.Add(
                        salida.IdSalida,
                        salida.Fecha.ToString("dd/MM/yyyy HH:mm"),
                        nombreProducto,
                        salida.Cantidad,
                        salida.PrecioVenta.ToString("C2"),
                        total.ToString("C2"),
                        salida.Motivo,
                        salida.Observaciones
                    );
                }
            }
            catch (Exception ex)
            {
                // Ignorar errores menores en la búsqueda
                Console.WriteLine("Error en búsqueda: " + ex.Message);
            }
        }
    }
}