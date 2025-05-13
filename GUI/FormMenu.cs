using BLL;
using EL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        private readonly ProductoBLL _productoBLL = new ProductoBLL();
        private readonly EntradaInventarioBLL _entradaBLL = new EntradaInventarioBLL();
        private readonly SalidaInventarioBLL _salidaBLL = new SalidaInventarioBLL();
        private Dictionary<string, Image> iconesPorCategoria;
        private Dictionary<string, Image> iconesPorProducto;

        public FormMenu()
        {
            InitializeComponent();
            InicializarDiccionariosIconos(); 
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            // Cargo todos los datos necesarios para el menú
            CargarDatosMenu();
        }
        private void MejorarAparienciaPaneles()
        {
            // Configurar el TableLayoutPanel
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            tableLayoutPanel1.BackColor = Color.FromArgb(240, 240, 240); // Color de fondo claro

            // Configurar cada panel
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is Panel panel)
                {
                    panel.Margin = new Padding(4); // Espacio entre paneles
                    panel.BorderStyle = BorderStyle.None; // Sin borde
                }
            }
        }
        private void CargarDatosMenu()
        {
            try
            {
                // Obtengo el total de proveedores y lo muestro
                int totalProveedores = _proveedorBLL.ObtenerTodos().Count;
                lblTotalProveedores.Text = totalProveedores.ToString();

                // Obtengo el total de productos y cuántos tienen stock bajo
                int totalProductos = _productoBLL.ObtenerTotalProductos();
                List<Producto> productosStockBajo = _productoBLL.ObtenerProductosStockBajo(10);
                lblTotalProductos.Text = totalProductos.ToString();
                lblStockBajo.Text = productosStockBajo.Count.ToString();

                // Valor estático hasta implementar CategoriaBLL
                lblTotalCategorias.Text = "8";

                // Calculo los ingresos del día (ventas)
                decimal ingresosHoy = CalcularIngresosHoy();
                lblIngresosHoy.Text = ingresosHoy.ToString("C2");
                dgvStockBajo.ClearSelection();

                // Calculo los gastos del día (compras)
                decimal gastosHoy = CalcularGastosHoy();
                lblGastosHoy.Text = gastosHoy.ToString("C2");
                CargarProductosBajoStock();
                CargarUltimosIngresos();
                dgvUltimosIngresos.ClearSelection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Metodo para calcular los ingresos del día (dinero que entra por ventas)
        private decimal CalcularIngresosHoy()
        {
            try
            {
                // Obtengo la fecha de hoy y de mañana para delimitar
                DateTime hoy = DateTime.Today;
                DateTime mañana = hoy.AddDays(1);

                // Obtengo todas las salidas (ventas) de hoy
                var salidasHoy = _salidaBLL.ObtenerPorFecha(hoy, mañana.AddSeconds(-1));

                // Si no hay salidas retorno 0
                if (salidasHoy == null || salidasHoy.Count == 0)
                    return 0;

                // Sumo el valor de todas las salidas (cantidad * precio venta)
                decimal totalIngresos = 0;
                foreach (var salida in salidasHoy)
                {
                    totalIngresos += salida.Cantidad * salida.PrecioVenta;
                }

                return totalIngresos;
            }
            catch (Exception)
            {
                // Si ocurre algún error retorno 0
                return 0;
            }
        }

        // Metodo para calcular los gastos del día (dinero que sale por compras)
        private decimal CalcularGastosHoy()
        {
            try
            {
                // la fecha de hoy y de mañana para delimitar
                DateTime hoy = DateTime.Today;
                DateTime mañana = hoy.AddDays(1);

                //  todas las entradas (compras) de hoy
                var entradasHoy = _entradaBLL.ObtenerPorFecha(hoy, mañana.AddSeconds(-1));

                // Si no hay entradas retorno 0
                if (entradasHoy == null || entradasHoy.Count == 0)
                    return 0;

                // Sumo el valor de todas las entradas (cantidad * precio compra)
                decimal totalGastos = 0;
                foreach (var entrada in entradasHoy)
                {
                    totalGastos += entrada.Cantidad * entrada.PrecioCompra;
                }

                return totalGastos;
            }
            catch (Exception)
            {
                // Si ocurre algún error retorno 0
                return 0;
            }
        }
        private void InicializarDiccionariosIconos()
        {
            iconesPorCategoria = new Dictionary<string, Image>();

            // iconos por categoría 
            iconesPorCategoria.Add("Alimentos", Properties.Resources.icons8_bread_32);
            iconesPorCategoria.Add("Bebidas", Properties.Resources.icons8_coca_cola_32);
            iconesPorCategoria.Add("Limpieza", Properties.Resources.icons8_bleach_bottle_64);
            iconesPorCategoria.Add("Lácteos", Properties.Resources.icons8_kawaii_milk_32);
            iconesPorCategoria.Add("Aceites", Properties.Resources.icons8_sunflower_oil_32);
            iconesPorCategoria.Add("Granos básicos", Properties.Resources.icons8_rice_32);
            iconesPorCategoria.Add("Aseo personal", Properties.Resources.icons8_soap_32);
            iconesPorCategoria.Add("Panadería", Properties.Resources.icons8_bread_32);
            iconesPorCategoria.Add("Alimentos secos", Properties.Resources.icons8_coffee_bag_32);
            iconesPorCategoria.Add("Aceites y grasas", Properties.Resources.icons8_sunflower_oil_32);
            iconesPorCategoria.Add("Condimentos", Properties.Resources.icons8_salt_50);
            iconesPorCategoria.Add("Huevos", Properties.Resources.icons8_egg_carton_32);
            iconesPorCategoria.Add("Endulzantes", Properties.Resources.azucar);
            iconesPorCategoria.Add("Enlatados", Properties.Resources.icons8_bread_32); 

            iconesPorProducto = new Dictionary<string, Image>();

            // iconos por producto específico 
            iconesPorProducto.Add("Azúcar", Properties.Resources.azucar);
            iconesPorProducto.Add("Arroz", Properties.Resources.icons8_rice_32);
            iconesPorProducto.Add("Arroz Blanco", Properties.Resources.icons8_rice_32);
            iconesPorProducto.Add("Leche", Properties.Resources.icons8_kawaii_milk_32);
            iconesPorProducto.Add("Leche Entera", Properties.Resources.icons8_kawaii_milk_32);
            iconesPorProducto.Add("Huevos", Properties.Resources.icons8_egg_carton_32);
            iconesPorProducto.Add("Café", Properties.Resources.icons8_coffee_bag_32);
            iconesPorProducto.Add("Café Molido", Properties.Resources.icons8_coffee_bag_32);
            iconesPorProducto.Add("Papel Higiénico", Properties.Resources.icons8_roll_of_paper_32);
            iconesPorProducto.Add("Sal", Properties.Resources.icons8_salt_50);
            iconesPorProducto.Add("Sal Refina", Properties.Resources.icons8_salt_50);
            iconesPorProducto.Add("Frijoles", Properties.Resources.icons8_beans_32);
            iconesPorProducto.Add("Frijoles Rojos", Properties.Resources.icons8_beans_32);
            iconesPorProducto.Add("Jabón", Properties.Resources.icons8_soap_32);
            iconesPorProducto.Add("Jabón Lux", Properties.Resources.icons8_soap_32);
            iconesPorProducto.Add("Remolacha", Properties.Resources.icons8_beet_32);
            iconesPorProducto.Add("Coca-Cola", Properties.Resources.icons8_coca_cola_32);
            iconesPorProducto.Add("Cloro", Properties.Resources.icons8_bleach_bottle_64);
            iconesPorProducto.Add("Cloro Poder Max", Properties.Resources.icons8_bleach_bottle_64);
            iconesPorProducto.Add("Pan Dulce", Properties.Resources.icons8_bread_32);
            iconesPorProducto.Add("Aceite", Properties.Resources.icons8_sunflower_oil_32);
            iconesPorProducto.Add("Aceite Ideal", Properties.Resources.icons8_sunflower_oil_32);
            iconesPorProducto.Add("Detergente", Properties.Resources.icons8_soap_32);
            iconesPorProducto.Add("Sardinas", Properties.Resources.icons8_bread_32); 
        }

        // metodo para cargar los productos con stock bajo
        private void CargarProductosBajoStock()
        {
            try
            {
                // limpio las filas existentes
                dgvStockBajo.Rows.Clear();
                dgvStockBajo.RowTemplate.Height = 40;
                if (dgvStockBajo.Columns["colIcono"] is DataGridViewImageColumn imgCol)
                {
                    imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imgCol.Width = 40;
                }

                // obtengo los productos con stock bajo
                List<Producto> productosStockBajo = _productoBLL.ObtenerProductosStockBajo(10);

                // lleno el datagrid
                foreach (var producto in productosStockBajo)
                {
                    // obtengo el icono adecuado para el producto
                    Image iconoProducto = ObtenerIconoProducto(producto.Nombre, producto.Categoria?.Nombre ?? "");

                    dgvStockBajo.Rows.Add(
                        iconoProducto,
                        "P" + producto.IdProducto.ToString("D3"),
                        producto.Nombre,
                        producto.Stock,
                        producto.Categoria?.Nombre ?? "Sin categoría"
                    );

                    // coloreo filas con stock muy bajo en rojo claro
                    if (producto.Stock < 5)
                    {
                        dgvStockBajo.Rows[dgvStockBajo.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos con stock bajo: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // metodo para cargar los últimos ingresos al inventario
        private void CargarUltimosIngresos()
        {
            try
            {
                // limpio las filas existentes
                dgvUltimosIngresos.Rows.Clear();
                dgvUltimosIngresos.RowTemplate.Height = 40;

                if (dgvUltimosIngresos.Columns.Count == 0)
                {
                    DataGridViewImageColumn colIcono = new DataGridViewImageColumn();
                    colIcono.Name = "colIcono";
                    colIcono.HeaderText = "";
                    colIcono.Width = 40;
                    colIcono.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    colIcono.AutoSizeMode = DataGridViewAutoSizeColumnMode.None; // Asegura ancho fijo

                    dgvUltimosIngresos.Columns.Add(colIcono);
                    dgvUltimosIngresos.Columns.Add("colProducto", "Producto");
                    dgvUltimosIngresos.Columns.Add("colCantidad", "Cantidad");
                    dgvUltimosIngresos.Columns.Add("colFecha", "Fecha");

                    dgvUltimosIngresos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    dgvUltimosIngresos.Columns["colProducto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvUltimosIngresos.Columns["colProducto"].FillWeight = 33;

                    dgvUltimosIngresos.Columns["colCantidad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvUltimosIngresos.Columns["colCantidad"].FillWeight = 33;

                    dgvUltimosIngresos.Columns["colFecha"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvUltimosIngresos.Columns["colFecha"].FillWeight = 33;

                    dgvUltimosIngresos.RowHeadersVisible = false;
                    dgvUltimosIngresos.AllowUserToAddRows = false;
                    dgvUltimosIngresos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvUltimosIngresos.ReadOnly = true;
                }

                // obtengo todas las entradas y limito a las últimas 10
                var todasEntradas = _entradaBLL.ObtenerTodas();
                var ultimasEntradas = todasEntradas.OrderByDescending(e => e.Fecha).Take(10).ToList();

                // lleno el datagrid
                foreach (var entrada in ultimasEntradas)
                {
                    // obtengo el producto asociado a la entrada
                    Producto producto = entrada.Producto;

                    if (producto != null)
                    {
                        // obtengo el icono adecuado para el producto
                        Image iconoProducto = ObtenerIconoProducto(producto.Nombre, producto.Categoria?.Nombre ?? "");

                        dgvUltimosIngresos.Rows.Add(
                            iconoProducto,
                            producto.Nombre,
                            entrada.Cantidad + " unidades",
                            entrada.Fecha.ToString("dd/MM/yyyy HH:mm")
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar últimos ingresos: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // metodo para obtener el icono según el producto o categoría
        private Image ObtenerIconoProducto(string nombreProducto, string categoria)
        {
            // busco si hay un icono específico para este producto
            if (iconesPorProducto.ContainsKey(nombreProducto))
            {
                return iconesPorProducto[nombreProducto];
            }

            // busco coincidencias parciales en el nombre
            foreach (var kvp in iconesPorProducto)
            {
                if (nombreProducto.ToLower().Contains(kvp.Key.ToLower()))
                {
                    return kvp.Value;
                }
            }

            // si no hay icono por producto, busco por categoría
            if (iconesPorCategoria.ContainsKey(categoria))
            {
                return iconesPorCategoria[categoria];
            }

            // busco por palabras clave en el nombre
            if (nombreProducto.ToLower().Contains("arroz"))
            {
                return Properties.Resources.icons8_rice_32;
            }
            else if (nombreProducto.ToLower().Contains("leche"))
            {
                return Properties.Resources.icons8_kawaii_milk_32;
            }
            else if (nombreProducto.ToLower().Contains("azúcar") || nombreProducto.ToLower().Contains("azucar"))
            {
                return Properties.Resources.azucar;
            }
            else if (nombreProducto.ToLower().Contains("huevo"))
            {
                return Properties.Resources.icons8_egg_carton_32;
            }
            else if (nombreProducto.ToLower().Contains("papel"))
            {
                return Properties.Resources.icons8_roll_of_paper_32;
            }
            else if (nombreProducto.ToLower().Contains("café") || nombreProducto.ToLower().Contains("cafe"))
            {
                return Properties.Resources.icons8_coffee_bag_32;
            }
            else if (nombreProducto.ToLower().Contains("jabón") || nombreProducto.ToLower().Contains("jabon") ||
                     nombreProducto.ToLower().Contains("detergente"))
            {
                return Properties.Resources.icons8_soap_32;
            }
            else if (nombreProducto.ToLower().Contains("frijol") || nombreProducto.ToLower().Contains("frijoles"))
            {
                return Properties.Resources.icons8_beans_32;
            }
            else if (nombreProducto.ToLower().Contains("coca") || nombreProducto.ToLower().Contains("gaseosa"))
            {
                return Properties.Resources.icons8_coca_cola_32;
            }
            else if (nombreProducto.ToLower().Contains("pan"))
            {
                return Properties.Resources.icons8_bread_32;
            }
            else if (nombreProducto.ToLower().Contains("aceite"))
            {
                return Properties.Resources.icons8_sunflower_oil_32;
            }
            else if (nombreProducto.ToLower().Contains("cloro") || nombreProducto.ToLower().Contains("lejía"))
            {
                return Properties.Resources.icons8_bleach_bottle_64;
            }

            // Si todo lo demás falla busco por categorias generales
            string catLower = categoria.ToLower();
            if (catLower.Contains("bebida"))
                return Properties.Resources.icons8_coca_cola_32;
            else if (catLower.Contains("limpieza"))
                return Properties.Resources.icons8_bleach_bottle_64;
            else if (catLower.Contains("lácteo") || catLower.Contains("lacteo"))
                return Properties.Resources.icons8_kawaii_milk_32;
            else if (catLower.Contains("aseo"))
                return Properties.Resources.icons8_soap_32;
            else if (catLower.Contains("grano"))
                return Properties.Resources.icons8_rice_32;
            else if (catLower.Contains("aceite"))
                return Properties.Resources.icons8_sunflower_oil_32;
            else if (catLower.Contains("pan"))
                return Properties.Resources.icons8_bread_32;

            // Si nada coincide uso un icono genérico en lugar del pan
            try
            {
                // icono del sistema
                return SystemIcons.Application.ToBitmap();
            }
            catch
            {
                // Si falla uso un icono generico de alimentos
                return Properties.Resources.icons8_bread_32;
            }

            
        }
        private void lblIngresosHoy_Click(object sender, EventArgs e)
        {

        }

        private void panelGridUltimosIngresos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblGastosHoy_Click(object sender, EventArgs e)
        {

        }
    }
}