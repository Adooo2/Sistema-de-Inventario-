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
    public partial class FormSalidasDetalle : Form
    {
        // Variables para acceder a las capas de negocio
        private readonly SalidaInventarioBLL _salidaBLL;
        private readonly ProductoBLL _productoBLL;
        private SalidaInventario _salida;
        private bool _esEdicion;
        private int _cantidadOriginal;

        // Constructor para nueva salida
        public FormSalidasDetalle()
        {
            InitializeComponent();
            _salidaBLL = new SalidaInventarioBLL();
            _productoBLL = new ProductoBLL();
            _salida = new SalidaInventario();
            _esEdicion = false;

            // Asociar eventos
            this.Load += new EventHandler(FormSalidasDetalle_Load);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnCancelar.Click += new EventHandler(btnCancelar_Click);
            cmbProducto.SelectedIndexChanged += new EventHandler(cmbProducto_SelectedIndexChanged);
        }

        // Constructor para editar salida existente
        public FormSalidasDetalle(SalidaInventario salida)
        {
            InitializeComponent();
            _salidaBLL = new SalidaInventarioBLL();
            _productoBLL = new ProductoBLL();
            _salida = salida;
            _esEdicion = true;
            _cantidadOriginal = salida.Cantidad;

            // Asociar eventos
            this.Load += new EventHandler(FormSalidasDetalle_Load);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnCancelar.Click += new EventHandler(btnCancelar_Click);
            cmbProducto.SelectedIndexChanged += new EventHandler(cmbProducto_SelectedIndexChanged);
        }

        // Método que se ejecuta al cargar el formulario
        private void FormSalidasDetalle_Load(object sender, EventArgs e)
        {
            // Cargar productos
            CargarProductos();

            if (_esEdicion)
            {
                lblTitulo.Text = "Editar Salida de Inventario";

                // Seleccionar valores actuales
                SeleccionarProducto(_salida.ProductoId);

                // Mostrar datos actuales
                txtCantidad.Text = _salida.Cantidad.ToString();
                txtPrecioVenta.Text = _salida.PrecioVenta.ToString("0.00");
                dtpFecha.Value = _salida.Fecha;
                txtDestino.Text = _salida.Motivo ?? "";
                txtObservaciones.Text = _salida.Observaciones ?? "";
            }
            else
            {
                lblTitulo.Text = "Nueva Salida de Inventario";
                dtpFecha.Value = DateTime.Now;
            }
        }

        // Método para cargar los productos en el ComboBox
        private void CargarProductos()
        {
            try
            {
                var productos = _productoBLL.ObtenerTodos();

                cmbProducto.Items.Clear();
                cmbProducto.Items.Add("-- Seleccione un producto --");

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

        // Método para seleccionar un producto en el ComboBox
        private void SeleccionarProducto(int productoId)
        {
            try
            {
                var productos = _productoBLL.ObtenerTodos();
                for (int i = 0; i < productos.Count; i++)
                {
                    if (productos[i].IdProducto == productoId)
                    {
                        cmbProducto.SelectedIndex = i + 1; // +1 porque el índice 0 es "Seleccione..."
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar producto: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método que se ejecuta cuando cambia el producto seleccionado
        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cargar el precio de venta del producto seleccionado
            if (cmbProducto.SelectedIndex > 0)
            {
                try
                {
                    var productos = _productoBLL.ObtenerTodos();
                    var producto = productos[cmbProducto.SelectedIndex - 1]; // -1 porque el índice 0 es "Seleccione..."

                    // Mostrar el precio de venta del producto
                    txtPrecioVenta.Text = producto.Precio.ToString("0.00");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener precio: " + ex.Message);
                }
            }
        }

        // Método para validar los datos ingresados
        private bool ValidarDatos()
        {
            // Validar producto
            if (cmbProducto.SelectedIndex <= 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProducto.Focus();
                return false;
            }

            // Validar destino
            if (string.IsNullOrWhiteSpace(txtDestino.Text))
            {
                MessageBox.Show("Debe ingresar un destino o motivo para la salida", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDestino.Focus();
                return false;
            }

            // Validar cantidad
            int cantidad;
            if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número entero mayor que cero", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return false;
            }

            // Validar precio de venta
            decimal precioVenta;
            if (!decimal.TryParse(txtPrecioVenta.Text, out precioVenta) || precioVenta <= 0)
            {
                MessageBox.Show("El precio de venta debe ser un número mayor que cero", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioVenta.Focus();
                return false;
            }

            // Verificar stock disponible
            try
            {
                var productos = _productoBLL.ObtenerTodos();
                var producto = productos[cmbProducto.SelectedIndex - 1]; // -1 porque el índice 0 es "Seleccione..."

                // Si es una edición, verificar la diferencia
                if (_esEdicion)
                {
                    int diferencia = cantidad - _cantidadOriginal;
                    if (diferencia > 0 && producto.Stock < diferencia)
                    {
                        MessageBox.Show($"No hay suficiente stock disponible. Stock actual: {producto.Stock}", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCantidad.Focus();
                        return false;
                    }
                }
                else
                {
                    // Si es una nueva salida, verificar toda la cantidad
                    if (producto.Stock < cantidad)
                    {
                        MessageBox.Show($"No hay suficiente stock disponible. Stock actual: {producto.Stock}", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCantidad.Focus();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar stock: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validaciones correctas
            return true;
        }

        // Método para guardar la salida
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar los datos
                if (!ValidarDatos())
                {
                    return;
                }

                // Obtener el producto seleccionado
                var productos = _productoBLL.ObtenerTodos();
                var producto = productos[cmbProducto.SelectedIndex - 1]; // -1 porque el índice 0 es "Seleccione..."

                // Asignar valores a la salida
                _salida.ProductoId = producto.IdProducto;
                _salida.Cantidad = int.Parse(txtCantidad.Text);
                _salida.PrecioVenta = decimal.Parse(txtPrecioVenta.Text);
                _salida.Fecha = dtpFecha.Value;
                _salida.Motivo = txtDestino.Text;
                _salida.Observaciones = txtObservaciones.Text;
                _salida.Estado = true;

                if (_esEdicion)
                {
                    // Actualizar salida existente
                    bool resultado = _salidaBLL.Actualizar(_salida, _cantidadOriginal);
                    if (resultado)
                    {
                        MessageBox.Show("Salida actualizada correctamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar la salida", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Insertar nueva salida
                    int id = _salidaBLL.Insertar(_salida);
                    if (id > 0)
                    {
                        MessageBox.Show("Salida agregada correctamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar la salida", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar salida: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}