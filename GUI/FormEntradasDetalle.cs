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
    public partial class FormEntradasDetalle : Form
    {
        private readonly EntradaInventarioBLL _entradaBLL;
        private readonly ProductoBLL _productoBLL;
        private readonly ProveedorBLL _proveedorBLL;
        private EntradaInventario _entrada;
        private bool _esEdicion;
        private int _cantidadOriginal;

        // Constructor para nueva entrada
        public FormEntradasDetalle()
        {
            InitializeComponent();
            _entradaBLL = new EntradaInventarioBLL();
            _productoBLL = new ProductoBLL();
            _proveedorBLL = new ProveedorBLL();
            _entrada = new EntradaInventario();
            _esEdicion = false;

            // Asociar eventos
            this.Load += new EventHandler(FormEntradasDetalle_Load);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnCancelar.Click += new EventHandler(btnCancelar_Click);
        }

        // Constructor para editar entrada existente
        public FormEntradasDetalle(EntradaInventario entrada)
        {
            InitializeComponent();
            _entradaBLL = new EntradaInventarioBLL();
            _productoBLL = new ProductoBLL();
            _proveedorBLL = new ProveedorBLL();
            _entrada = entrada;
            _esEdicion = true;
            _cantidadOriginal = entrada.Cantidad;

            // Asociar eventos
            this.Load += new EventHandler(FormEntradasDetalle_Load);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnCancelar.Click += new EventHandler(btnCancelar_Click);
        }

        private void FormEntradasDetalle_Load(object sender, EventArgs e)
        {
            // Cargar combos
            CargarProductos();
            CargarProveedores();

            if (_esEdicion)
            {
                lblTitulo.Text = "Editar Entrada de Inventario";

                // Seleccionar valores actuales
                SeleccionarProducto(_entrada.ProductoId);
                SeleccionarProveedor(_entrada.ProveedorId);

                // Mostrar datos actuales
                txtCantidad.Text = _entrada.Cantidad.ToString();
                txtPrecioCompra.Text = _entrada.PrecioCompra.ToString("0.00");
                dtpFecha.Value = _entrada.Fecha;
                txtObservaciones.Text = _entrada.Observaciones ?? "";
            }
            else
            {
                lblTitulo.Text = "Nueva Entrada de Inventario";
                dtpFecha.Value = DateTime.Now;
            }
        }

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

        private void CargarProveedores()
        {
            try
            {
                var proveedores = _proveedorBLL.ObtenerTodos();

                cmbProveedor.Items.Clear();
                cmbProveedor.Items.Add("-- Seleccione un proveedor --");

                foreach (var proveedor in proveedores)
                {
                    cmbProveedor.Items.Add(proveedor.Nombre);
                }

                cmbProveedor.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarProducto(int productoId)
        {
            try
            {
                var productos = _productoBLL.ObtenerTodos();
                for (int i = 0; i < productos.Count; i++)
                {
                    if (productos[i].IdProducto == productoId)
                    {
                        cmbProducto.SelectedIndex = i + 1; // +1 porque el índice 0 es "Seleccione"
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

        private void SeleccionarProveedor(int proveedorId)
        {
            try
            {
                var proveedores = _proveedorBLL.ObtenerTodos();
                for (int i = 0; i < proveedores.Count; i++)
                {
                    if (proveedores[i].Id == proveedorId)
                    {
                        cmbProveedor.SelectedIndex = i + 1; // +1 porque el índice 0 es "Seleccione"
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar proveedor: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones básicas
                if (cmbProducto.SelectedIndex <= 0)
                {
                    MessageBox.Show("Debe seleccionar un producto", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbProducto.Focus();
                    return;
                }

                if (cmbProveedor.SelectedIndex <= 0)
                {
                    MessageBox.Show("Debe seleccionar un proveedor", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbProveedor.Focus();
                    return;
                }

                int cantidad;
                if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser un número mayor que cero", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCantidad.Focus();
                    return;
                }

                decimal precioCompra;
                if (!decimal.TryParse(txtPrecioCompra.Text, out precioCompra) || precioCompra <= 0)
                {
                    MessageBox.Show("El precio de compra debe ser un número mayor que cero", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrecioCompra.Focus();
                    return;
                }

                // Obtener IDs de producto y proveedor seleccionados
                var productos = _productoBLL.ObtenerTodos();
                var producto = productos[cmbProducto.SelectedIndex - 1]; 

                var proveedores = _proveedorBLL.ObtenerTodos();
                var proveedor = proveedores[cmbProveedor.SelectedIndex - 1]; 

                // Asignar valores a la entrada
                _entrada.ProductoId = producto.IdProducto;
                _entrada.ProveedorId = proveedor.Id;
                _entrada.Cantidad = cantidad;
                _entrada.PrecioCompra = precioCompra;
                _entrada.Fecha = dtpFecha.Value;
                _entrada.Observaciones = txtObservaciones.Text;

                if (_esEdicion)
                {
                    // Actualizar entrada existente
                    bool resultado = _entradaBLL.Actualizar(_entrada, _cantidadOriginal);
                    if (resultado)
                    {
                        MessageBox.Show("Entrada actualizada correctamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar la entrada", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Insertar nueva entrada
                    int id = _entradaBLL.Insertar(_entrada);
                    if (id > 0)
                    {
                        MessageBox.Show("Entrada agregada correctamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar la entrada", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar entrada: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}