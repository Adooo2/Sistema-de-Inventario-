using System;
using System.Windows.Forms;
using BLL;
using EL;

namespace GUI
{
    public partial class FormProveedoresDetalle : Form
    {
        private readonly ProveedorBLL _proveedorBLL;
        private Proveedor _proveedor;
        private bool _esEdicion;

        // Constructor para nuevo proveedor
        public FormProveedoresDetalle()
        {
            InitializeComponent();
            _proveedorBLL = new ProveedorBLL();
            _proveedor = new Proveedor();
            _esEdicion = false;

            // Asociar eventos
            this.Load += new EventHandler(FormProveedoresDetalle_Load);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnCancelar.Click += new EventHandler(btnCancelar_Click);
        }

        // Constructor para editar proveedor existente
        public FormProveedoresDetalle(Proveedor proveedor)
        {
            InitializeComponent();
            _proveedorBLL = new ProveedorBLL();
            _proveedor = proveedor;
            _esEdicion = true;

            // Asociar eventos
            this.Load += new EventHandler(FormProveedoresDetalle_Load);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnCancelar.Click += new EventHandler(btnCancelar_Click);
        }

        private void FormProveedoresDetalle_Load(object sender, EventArgs e)
        {
            if (_esEdicion)
            {
                lblTitulo.Text = "Editar Proveedor";
                txtNombre.Text = _proveedor.Nombre;
                txtTelefono.Text = _proveedor.Telefono;
                txtEmail.Text = _proveedor.Email;
                txtDireccion.Text = _proveedor.Direccion;
            }
            else
            {
                lblTitulo.Text = "Nuevo Proveedor";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    MessageBox.Show("El nombre es obligatorio", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtTelefono.Text))
                {
                    MessageBox.Show("El teléfono es obligatorio", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTelefono.Focus();
                    return;
                }

                // Asignar valores
                _proveedor.Nombre = txtNombre.Text;
                _proveedor.Telefono = txtTelefono.Text;
                _proveedor.Email = txtEmail.Text;
                _proveedor.Direccion = txtDireccion.Text;

                if (_esEdicion)
                {
                    // Actualizar proveedor existente
                    bool resultado = _proveedorBLL.Actualizar(_proveedor);
                    if (resultado)
                    {
                        MessageBox.Show("Proveedor actualizado correctamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el proveedor", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Insertar nuevo proveedor
                    int id = _proveedorBLL.Insertar(_proveedor);
                    if (id > 0)
                    {
                        MessageBox.Show("Proveedor agregado correctamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el proveedor", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar proveedor: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}