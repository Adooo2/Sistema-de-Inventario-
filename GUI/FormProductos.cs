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
    public partial class FormProductos : Form
    {
        private readonly ProductoBLL _productoBLL;
        private readonly CategoriaBLL _categoriaBLL;
        private List<Producto> _productos;

        public FormProductos()
        {
            InitializeComponent();
            _productoBLL = new ProductoBLL();
            _categoriaBLL = new CategoriaBLL();

            // Asignación de eventos
            this.Load += new EventHandler(this.FormProductos_Load);
            btnAgregar.Click += new EventHandler(this.btnAgregar_Click);
            btnEditar.Click += new EventHandler(this.btnEditar_Click);
            btnEliminar.Click += new EventHandler(this.btnEliminar_Click);
            txtBuscar.TextChanged += new EventHandler(this.txtBuscar_TextChanged);
            cmbCategoria.SelectedIndexChanged += new EventHandler(this.cmbCategoria_SelectedIndexChanged);
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            // esto sirve para responsive
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbCategoria.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // configurar DataGridView
            ConfigurarDataGridView();

            // Configurar combo de categorías
            CargarCategorias();

            // Cargar productos
            CargarProductos();
        }

        private void ConfigurarDataGridView()
        {
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.MultiSelect = false;
            dgvProductos.ReadOnly = true;

            // Limpiar columnas existentes y definir nuevas
            dgvProductos.Columns.Clear();

            dgvProductos.Columns.Add("Id", "ID");
            dgvProductos.Columns.Add("Codigo", "Código");
            dgvProductos.Columns.Add("Nombre", "Nombre");
            dgvProductos.Columns.Add("Descripcion", "Descripción");
            dgvProductos.Columns.Add("Precio", "Precio");
            dgvProductos.Columns.Add("Stock", "Stock");
            dgvProductos.Columns.Add("Categoria", "Categoría");

            // Ocultar columna ID
            dgvProductos.Columns["Id"].Visible = false;
        }

        private void CargarCategorias()
        {
            try
            {
                // Limpiar y agregar opción por defecto
                cmbCategoria.Items.Clear();
                cmbCategoria.Items.Add("Todas las categorías");

                // Obtener categorías desde BLL
                var categorias = _categoriaBLL.ObtenerTodos();

                // Agregar cada categoría al combo
                foreach (var categoria in categorias)
                {
                    cmbCategoria.Items.Add(categoria.Nombre);
                }

                // Seleccionar primera opción
                cmbCategoria.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProductos()
        {
            try
            {
                // Obtener todos los productos
                _productos = _productoBLL.ObtenerTodos();

                // Limpiar filas existentes
                dgvProductos.Rows.Clear();

                // Agregar productos al DataGridView
                foreach (var producto in _productos)
                {
                    dgvProductos.Rows.Add(
                        producto.IdProducto,
                        "P" + producto.IdProducto.ToString("D3"), // Código generado
                        producto.Nombre,
                        producto.Descripcion,
                        producto.Precio,
                        producto.Stock,
                        producto.Categoria?.Nombre ?? "Sin categoría"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrir formulario de detalle para nuevo producto
                FormProductosDetalle formDetalle = new FormProductosDetalle();
                if (formDetalle.ShowDialog() == DialogResult.OK)
                {
                    // Recargar productos
                    CargarProductos();
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
            if (dgvProductos.SelectedRows.Count > 0)
            {
                try
                {
                    // Obtener ID del producto seleccionado
                    int id = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["Id"].Value);

                    // Obtener producto completo
                    Producto producto = _productoBLL.ObtenerPorId(id);

                    if (producto != null)
                    {
                        // Abrir formulario de detalle para editar
                        FormProductosDetalle formDetalle = new FormProductosDetalle(producto);
                        if (formDetalle.ShowDialog() == DialogResult.OK)
                        {
                            // Recargar productos
                            CargarProductos();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el producto seleccionado", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al editar producto: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                    try
                    {
                        // Obtener ID del producto seleccionado
                        int id = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["Id"].Value);

                        // Eliminar producto
                        bool exitoso = _productoBLL.Eliminar(id);

                        if (exitoso)
                        {
                            MessageBox.Show("Producto eliminado correctamente", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Recargar productos
                            CargarProductos();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el producto", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar producto: " + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
            FiltrarProductos();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarProductos();
        }

        private void FiltrarProductos()
        {
            try
            {
                string textoBusqueda = txtBuscar.Text.Trim().ToLower();
                string categoriaSeleccionada = cmbCategoria.SelectedItem?.ToString() ?? "Todas las categorías";

                // Limpiar filas existentes
                dgvProductos.Rows.Clear();

                // Si no hay productos cargados, cargarlos
                if (_productos == null || _productos.Count == 0)
                {
                    _productos = _productoBLL.ObtenerTodos();
                }

                // Filtrar productos
                var productosFiltrados = _productos;

                // Filtro por texto de búsqueda
                if (!string.IsNullOrEmpty(textoBusqueda))
                {
                    productosFiltrados = productosFiltrados.Where(p =>
                        (p.Nombre?.ToLower() ?? "").Contains(textoBusqueda) ||
                        (p.Descripcion?.ToLower() ?? "").Contains(textoBusqueda)).ToList();
                }

                // Filtro por categoría
                if (categoriaSeleccionada != "Todas las categorías")
                {
                    productosFiltrados = productosFiltrados.Where(p =>
                        p.Categoria != null && p.Categoria.Nombre == categoriaSeleccionada).ToList();
                }

                // Mostrar productos filtrados
                foreach (var producto in productosFiltrados)
                {
                    dgvProductos.Rows.Add(
                        producto.IdProducto,
                        "P" + producto.IdProducto.ToString("D3"),
                        producto.Nombre,
                        producto.Descripcion,
                        producto.Precio,
                        producto.Stock,
                        producto.Categoria?.Nombre ?? "Sin categoría"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar productos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormProductos_Resize(object sender, EventArgs e)
        {
            // actualización del layout al redimensionar
            this.PerformLayout();
        }
    }
}