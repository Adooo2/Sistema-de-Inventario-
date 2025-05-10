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
    public partial class FormReportes : Form
    {
        private readonly ProductoBLL _productoBLL;
        private readonly CategoriaBLL _categoriaBLL;
        private readonly EntradaInventarioBLL _entradaBLL;
        private readonly SalidaInventarioBLL _salidaBLL;

        public FormReportes()
        {
            InitializeComponent();

            // Inicializar instancias BLL
            _productoBLL = new ProductoBLL();
            _categoriaBLL = new CategoriaBLL();
            _entradaBLL = new EntradaInventarioBLL();
            _salidaBLL = new SalidaInventarioBLL();

            // Los eventos Click ya se asignan en InitializeComponent
            this.Load += new EventHandler(FormReportes_Load);
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            // Configurar fechas por defecto
            dtpFechaInicio.Value = DateTime.Now.AddMonths(-1);
            dtpFechaFin.Value = DateTime.Now;

            // Cargar combos
            CargarProductos();
            CargarCategorias();

            // Ocultar panel de filtros inicialmente
            panel1.Visible = false;

            // Mostrar reporte inicial
            MostrarReporteInventarioActual();
        }

        private void CargarProductos()
        {
            try
            {
                var productos = _productoBLL.ObtenerTodos();

                cmbProducto.Items.Clear();
                cmbProducto.Items.Add("-- Todos los productos --");

                foreach (var producto in productos)
                {
                    cmbProducto.Items.Add(producto.Nombre);
                }

                cmbProducto.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCategorias()
        {
            try
            {
                var categorias = _categoriaBLL.ObtenerTodos();

                cmbCategoria.Items.Clear();
                cmbCategoria.Items.Add("-- Todas las categorías --");

                foreach (var categoria in categorias)
                {
                    cmbCategoria.Items.Add(categoria.Nombre);
                }

                cmbCategoria.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInventarioActual_Click_1(object sender, EventArgs e)
        {
            // Ocultar panel de filtros
            panel1.Visible = false;

            MostrarReporteInventarioActual();
        }

        private void MostrarReporteInventarioActual()
        {
            try
            {
                // Actualizar título
                lblTituloReporte.Text = "Reporte: Inventario Actual";

                // Obtener productos
                var productos = _productoBLL.ObtenerTodos();

                // Configurar DataGridView
                dgvReporte.DataSource = null;
                dgvReporte.Columns.Clear();

                // Agregar columnas manualmente
                dgvReporte.Columns.Add("Codigo", "Código");
                dgvReporte.Columns.Add("Nombre", "Producto");
                dgvReporte.Columns.Add("Categoria", "Categoría");
                dgvReporte.Columns.Add("Stock", "Stock Actual");
                dgvReporte.Columns.Add("Precio", "Precio");
                dgvReporte.Columns.Add("ValorTotal", "Valor Total");

                // Formatear columnas
                dgvReporte.Columns["Precio"].DefaultCellStyle.Format = "C2";
                dgvReporte.Columns["ValorTotal"].DefaultCellStyle.Format = "C2";

                // Llenar datos
                 dgvReporte.Rows.Clear(); 
             
                decimal valorTotalInventario = 0;

                foreach (var producto in productos)
                {
                    decimal valorProducto = producto.Stock * producto.Precio;
                    valorTotalInventario += valorProducto;

                    dgvReporte.Rows.Add(
                        producto.IdProducto,
                        producto.Nombre,
                        producto.Categoria?.Nombre ?? "Sin categoría",
                        producto.Stock,
                        producto.Precio,
                        valorProducto
                    );
                }

                // Mostrar resumen
                lblResumen.Text = $"Total de productos: {productos.Count} | Valor total del inventario: {valorTotalInventario:C2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProductosStockBajo_Click_1(object sender, EventArgs e)
        {
            // Ocultar panel de filtros
            panel1.Visible = false;

            MostrarReporteProductosStockBajo();
        }

        private void MostrarReporteProductosStockBajo()
        {
            try
            {
                // Actualizar título
                lblTituloReporte.Text = "Reporte: Productos con Stock Bajo";

                // Obtener productos con stock bajo (menor o igual a 10)
                // Puedes ajustar este valor según tus necesidades
                int stockMinimo = 10;
                var productos = _productoBLL.ObtenerTodos().Where(p => p.Stock <= stockMinimo).ToList();

                // Configurar DataGridView
                dgvReporte.DataSource = null;
                dgvReporte.Columns.Clear();

                // Agregar columnas
                dgvReporte.Columns.Add("Codigo", "Código");
                dgvReporte.Columns.Add("Nombre", "Producto");
                dgvReporte.Columns.Add("Categoria", "Categoría");
                dgvReporte.Columns.Add("Stock", "Stock Actual");
                dgvReporte.Columns.Add("StockMinimo", "Stock Mínimo");
                dgvReporte.Columns.Add("Diferencia", "Diferencia");
                dgvReporte.Columns.Add("Precio", "Precio");

                dgvReporte.Columns["Precio"].DefaultCellStyle.Format = "C2";

                // Llenar datos
                dgvReporte.Rows.Clear();

                foreach (var producto in productos)
                {
                    int diferencia = stockMinimo - producto.Stock;

                    dgvReporte.Rows.Add(
                        producto.IdProducto,
                        producto.Nombre,
                        producto.Categoria?.Nombre ?? "Sin categoría",
                        producto.Stock,
                        stockMinimo,
                        diferencia,
                        producto.Precio
                    );

                    // Colorear filas según la diferencia
                    DataGridViewRow row = dgvReporte.Rows[dgvReporte.Rows.Count - 1];
                    if (diferencia > 5)
                        row.DefaultCellStyle.BackColor = Color.LightPink;
                    else if (diferencia > 0)
                        row.DefaultCellStyle.BackColor = Color.LightYellow;
                }

                // Mostrar resumen
                lblResumen.Text = $"Total de productos con stock bajo: {productos.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            // Mostrar panel de filtros
            panel1.Visible = true;

            // Actualizar el título sin mostrar datos aún
            lblTituloReporte.Text = "Reporte: Movimientos por Producto";

            // Limpiar el DataGridView
            dgvReporte.DataSource = null;
            dgvReporte.Columns.Clear();
            dgvReporte.Rows.Clear();

            // Actualizar el resumen con instrucciones
            lblResumen.Text = "Seleccione un producto y haga clic en 'Aplicar Filtro' para ver los movimientos";
        }

        private void MostrarReporteMovimientos()
        {
            try
            {
                // Verificar si se ha seleccionado un producto
                if (cmbProducto.SelectedIndex <= 0)
                {
                    MessageBox.Show("Debe seleccionar un producto específico para este reporte.",
                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string nombreProducto = cmbProducto.SelectedItem.ToString();
                var productos = _productoBLL.ObtenerTodos();
                var producto = productos.FirstOrDefault(p => p.Nombre == nombreProducto);

                if (producto == null)
                {
                    MessageBox.Show("No se encontró el producto seleccionado.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Actualizar título
                lblTituloReporte.Text = $"Reporte: Movimientos del Producto '{producto.Nombre}'";

                // Obtener fechas de filtro
                DateTime fechaInicio = dtpFechaInicio.Value;
                DateTime fechaFin = dtpFechaFin.Value;

                // Obtener entradas y salidas
                var entradas = _entradaBLL.ObtenerPorProducto(producto.IdProducto)
                    .Where(e => e.Fecha >= fechaInicio && e.Fecha <= fechaFin)
                    .ToList();

                var salidas = _salidaBLL.ObtenerPorProducto(producto.IdProducto)
                    .Where(s => s.Fecha >= fechaInicio && s.Fecha <= fechaFin)
                    .ToList();

                // Configurar DataGridView
                dgvReporte.DataSource = null;
                dgvReporte.Columns.Clear();

                dgvReporte.Columns.Add("Fecha", "Fecha");
                dgvReporte.Columns.Add("TipoMovimiento", "Tipo");
                dgvReporte.Columns.Add("Cantidad", "Cantidad");
                dgvReporte.Columns.Add("Precio", "Precio");
                dgvReporte.Columns.Add("Total", "Total");
                dgvReporte.Columns.Add("Origen", "Origen/Destino");
                dgvReporte.Columns.Add("Observaciones", "Observaciones");

                dgvReporte.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvReporte.Columns["Precio"].DefaultCellStyle.Format = "C2";
                dgvReporte.Columns["Total"].DefaultCellStyle.Format = "C2";

                // Llenar datos
                dgvReporte.Rows.Clear();

                // Agregar entradas
                foreach (var entrada in entradas)
                {
                    decimal total = entrada.Cantidad * entrada.PrecioCompra;

                    dgvReporte.Rows.Add(
                        entrada.Fecha,
                        "Entrada",
                        entrada.Cantidad,
                        entrada.PrecioCompra,
                        total,
                        entrada.Proveedor?.Nombre ?? "Proveedor no especificado",
                        entrada.Observaciones
                    );

                    // Colorear fila
                    DataGridViewRow row = dgvReporte.Rows[dgvReporte.Rows.Count - 1];
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }

                // Agregar salidas
                foreach (var salida in salidas)
                {
                    decimal total = salida.Cantidad * salida.PrecioVenta;

                    dgvReporte.Rows.Add(
                        salida.Fecha,
                        "Salida",
                        salida.Cantidad,
                        salida.PrecioVenta,
                        total,
                        salida.Motivo,
                        salida.Observaciones
                    );

                    // Colorear fila
                    DataGridViewRow row = dgvReporte.Rows[dgvReporte.Rows.Count - 1];
                    row.DefaultCellStyle.BackColor = Color.LightPink;
                }

                // Ordenar por fecha
                dgvReporte.Sort(dgvReporte.Columns["Fecha"], ListSortDirection.Ascending);

                // Calcular resumen
                int totalEntradas = entradas.Sum(e => e.Cantidad);
                int totalSalidas = salidas.Sum(s => s.Cantidad);
                decimal valorEntradas = entradas.Sum(e => e.Cantidad * e.PrecioCompra);
                decimal valorSalidas = salidas.Sum(s => s.Cantidad * s.PrecioVenta);

                // Mostrar resumen
                lblResumen.Text = $"Entradas: {totalEntradas} unidades (${valorEntradas:N2}) | Salidas: {totalSalidas} unidades (${valorSalidas:N2}) | Balance: {totalEntradas - totalSalidas} unidades";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEntradas_Click(object sender, EventArgs e)
        {
            // Mostrar panel de filtros
            panel1.Visible = true;

            // Actualizar el título sin mostrar datos aún
            lblTituloReporte.Text = "Reporte: Entradas de Inventario";

            // Limpiar el DataGridView
            dgvReporte.DataSource = null;
            dgvReporte.Columns.Clear();
            dgvReporte.Rows.Clear();

            // Actualizar el resumen con instrucciones
            lblResumen.Text = "Seleccione un rango de fechas y haga clic en 'Aplicar Filtro' para ver las entradas";
        }

        private void MostrarReporteEntradas()
        {
            try
            {
                // Obtener fechas de filtro
                DateTime fechaInicio = dtpFechaInicio.Value;
                DateTime fechaFin = dtpFechaFin.Value;

                // Actualizar título
                lblTituloReporte.Text = $"Reporte: Entradas de Inventario ({fechaInicio.ToShortDateString()} - {fechaFin.ToShortDateString()})";

                // Obtener entradas
                var entradas = _entradaBLL.ObtenerPorFecha(fechaInicio, fechaFin);

                // Aplicar filtro de producto si está seleccionado
                if (cmbProducto.SelectedIndex > 0)
                {
                    string productoSeleccionado = cmbProducto.SelectedItem.ToString();
                    var productos = _productoBLL.ObtenerTodos();
                    var producto = productos.FirstOrDefault(p => p.Nombre == productoSeleccionado);

                    if (producto != null)
                    {
                        entradas = entradas.Where(e => e.ProductoId == producto.IdProducto).ToList();
                    }
                }

                // Configurar DataGridView
                dgvReporte.DataSource = null;
                dgvReporte.Columns.Clear();

                dgvReporte.Columns.Add("Fecha", "Fecha");
                dgvReporte.Columns.Add("Producto", "Producto");
                dgvReporte.Columns.Add("Proveedor", "Proveedor");
                dgvReporte.Columns.Add("Cantidad", "Cantidad");
                dgvReporte.Columns.Add("PrecioCompra", "Precio Compra");
                dgvReporte.Columns.Add("Total", "Total");
                dgvReporte.Columns.Add("Observaciones", "Observaciones");

                dgvReporte.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvReporte.Columns["PrecioCompra"].DefaultCellStyle.Format = "C2";
                dgvReporte.Columns["Total"].DefaultCellStyle.Format = "C2";

                // Llenar datos
                dgvReporte.Rows.Clear();
                decimal valorTotalEntradas = 0;
                int cantidadTotalEntradas = 0;

                foreach (var entrada in entradas)
                {
                    decimal total = entrada.Cantidad * entrada.PrecioCompra;
                    valorTotalEntradas += total;
                    cantidadTotalEntradas += entrada.Cantidad;

                    dgvReporte.Rows.Add(
                        entrada.Fecha,
                        entrada.Producto?.Nombre ?? "Producto no encontrado",
                        entrada.Proveedor?.Nombre ?? "Proveedor no especificado",
                        entrada.Cantidad,
                        entrada.PrecioCompra,
                        total,
                        entrada.Observaciones
                    );
                }

                // Mostrar resumen
                lblResumen.Text = $"Total de entradas: {entradas.Count} | Cantidad total: {cantidadTotalEntradas} unidades | Valor total: {valorTotalEntradas:C2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalidas_Click(object sender, EventArgs e)
        {
            // Mostrar panel de filtros
            panel1.Visible = true;

            // Actualizar el título sin mostrar datos aún
            lblTituloReporte.Text = "Reporte: Salidas de Inventario";

            // Limpiar el DataGridView
            dgvReporte.DataSource = null;
            dgvReporte.Columns.Clear();
            dgvReporte.Rows.Clear();

            // Actualizar el resumen con instrucciones
            lblResumen.Text = "Seleccione un rango de fechas y haga clic en 'Aplicar Filtro' para ver las salidas";
        }

        private void MostrarReporteSalidas()
        {
            try
            {
                // Obtener fechas de filtro
                DateTime fechaInicio = dtpFechaInicio.Value;
                DateTime fechaFin = dtpFechaFin.Value;

                // Actualizar título
                lblTituloReporte.Text = $"Reporte: Salidas de Inventario ({fechaInicio.ToShortDateString()} - {fechaFin.ToShortDateString()})";

                // Obtener salidas
                var salidas = _salidaBLL.ObtenerPorFecha(fechaInicio, fechaFin);

                // Aplicar filtro de producto si está seleccionado
                if (cmbProducto.SelectedIndex > 0)
                {
                    string productoSeleccionado = cmbProducto.SelectedItem.ToString();
                    var productos = _productoBLL.ObtenerTodos();
                    var producto = productos.FirstOrDefault(p => p.Nombre == productoSeleccionado);

                    if (producto != null)
                    {
                        salidas = salidas.Where(s => s.ProductoId == producto.IdProducto).ToList();
                    }
                }

                // Configurar DataGridView
                dgvReporte.DataSource = null;
                dgvReporte.Columns.Clear();

                dgvReporte.Columns.Add("Fecha", "Fecha");
                dgvReporte.Columns.Add("Producto", "Producto");
                dgvReporte.Columns.Add("Cantidad", "Cantidad");
                dgvReporte.Columns.Add("PrecioVenta", "Precio Venta");
                dgvReporte.Columns.Add("Total", "Total");
                dgvReporte.Columns.Add("Destino", "Destino/Motivo");
                dgvReporte.Columns.Add("Observaciones", "Observaciones");

                dgvReporte.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgvReporte.Columns["PrecioVenta"].DefaultCellStyle.Format = "C2";
                dgvReporte.Columns["Total"].DefaultCellStyle.Format = "C2";

                // Llenar datos
                dgvReporte.Rows.Clear();
                decimal valorTotalSalidas = 0;
                int cantidadTotalSalidas = 0;

                foreach (var salida in salidas)
                {
                    decimal total = salida.Cantidad * salida.PrecioVenta;
                    valorTotalSalidas += total;
                    cantidadTotalSalidas += salida.Cantidad;

                    dgvReporte.Rows.Add(
                        salida.Fecha,
                        salida.Producto?.Nombre ?? "Producto no encontrado",
                        salida.Cantidad,
                        salida.PrecioVenta,
                        total,
                        salida.Motivo,
                        salida.Observaciones
                    );
                }

                // Mostrar resumen
                lblResumen.Text = $"Total de salidas: {salidas.Count} | Cantidad total: {cantidadTotalSalidas} unidades | Valor total: {valorTotalSalidas:C2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAplicarFiltro_Click(object sender, EventArgs e)
        {
            // Determinar qué reporte está activo y refrescarlo
            if (lblTituloReporte.Text.Contains("Movimientos"))
                MostrarReporteMovimientos();
            else if (lblTituloReporte.Text.Contains("Entradas"))
                MostrarReporteEntradas();
            else if (lblTituloReporte.Text.Contains("Salidas"))
                MostrarReporteSalidas();
        }
    }
}