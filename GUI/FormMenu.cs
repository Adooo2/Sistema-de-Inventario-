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
        private readonly ProductoBLL _productoBLL = new ProductoBLL();
        private readonly EntradaInventarioBLL _entradaBLL = new EntradaInventarioBLL();
        private readonly SalidaInventarioBLL _salidaBLL = new SalidaInventarioBLL();

        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            // Cargo todos los datos necesarios para el menú
            CargarDatosMenu();
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

                // Calculo los gastos del día (compras)
                decimal gastosHoy = CalcularGastosHoy();
                lblGastosHoy.Text = gastosHoy.ToString("C2");
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

        private void lblIngresosHoy_Click(object sender, EventArgs e)
        {

        }
    }
}