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
    public partial class FormProductosDetalle : Form
    {
        private readonly ProductoBLL _productoBLL;
        private readonly CategoriaBLL _categoriaBLL;
        private Producto _producto;
        private bool _esEdicion;

        // Constructor para nuevo producto
        public FormProductosDetalle()
        {
            InitializeComponent();
            _productoBLL = new ProductoBLL();
            _categoriaBLL = new CategoriaBLL();
            _producto = new Producto();
            _esEdicion = false;

            // Asociar eventos
            this.Load += new EventHandler(FormProductosDetalle_Load);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnCancelar.Click += new EventHandler(btnCancelar_Click);
        }

        // Constructor para editar producto existente
        public FormProductosDetalle(Producto producto)
        {
            InitializeComponent();
            _productoBLL = new ProductoBLL();
            _categoriaBLL = new CategoriaBLL();
            _producto = producto;
            _esEdicion = true;

            // Asociar eventos
            this.Load += new EventHandler(FormProductosDetalle_Load);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnCancelar.Click += new EventHandler(btnCancelar_Click);
        }

        private void FormProductosDetalle_Load(object sender, EventArgs e)
        {
            // Cargar categorías
            CargarCategorias();

            if (_esEdicion)
            {
                lblTitulo.Text = "Editar Producto";
                txtNombre.Text = _producto.Nombre;
                txtDescripcion.Text = _producto.Descripcion;
                txtPrecio.Text = _producto.Precio.ToString();
                txtStock.Text = _producto.Stock.ToString();

                // Seleccionar categoría
                if (_producto.Categoria != null)
                {
                    for (int i = 0; i < cmbCategoria.Items.Count; i++)
                    {
                        if (cmbCategoria.Items[i].ToString() == _producto.Categoria.Nombre)
                        {
                            cmbCategoria.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            else
            {
                lblTitulo.Text = "Nuevo Producto";
                // Valores por defecto
                txtPrecio.Text = "0.00";
                txtStock.Text = "0";
                cmbCategoria.SelectedIndex = 0;
            }
        }

        private void CargarCategorias()
        {
            try
            {
                // Limpiar y agregar elemento por defecto
                cmbCategoria.Items.Clear();
                cmbCategoria.Items.Add("-- Seleccione una categoría --");

                // Obtener categorías
                var categorias = _categoriaBLL.ObtenerTodos();

                // Agregar al combo
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

                if (cmbCategoria.SelectedIndex <= 0)
                {
                    MessageBox.Show("Debe seleccionar una categoría", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbCategoria.Focus();
                    return;
                }

                decimal precio;
                if (!decimal.TryParse(txtPrecio.Text, out precio) || precio <= 0)
                {
                    MessageBox.Show("El precio debe ser un número mayor que cero", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrecio.Focus();
                    return;
                }

                int stock;
                if (!int.TryParse(txtStock.Text, out stock) || stock < 0)
                {
                    MessageBox.Show("El stock debe ser un número positivo", "Validación",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtStock.Focus();
                    return;
                }

                // Obtener categoría seleccionada
                string categoriaNombre = cmbCategoria.SelectedItem.ToString();
                var categorias = _categoriaBLL.ObtenerTodos();
                var categoria = categorias.FirstOrDefault(c => c.Nombre == categoriaNombre);

                if (categoria == null)
                {
                    MessageBox.Show("Categoría no encontrada", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Asignar valores
                _producto.Nombre = txtNombre.Text;
                _producto.Descripcion = txtDescripcion.Text;
                _producto.Precio = precio;
                _producto.Stock = stock;
                _producto.CategoriaId = categoria.IdCategoria;

                if (_esEdicion)
                {
                    // Actualizar producto existente
                    bool resultado = _productoBLL.Actualizar(_producto);
                    if (resultado)
                    {
                        MessageBox.Show("Producto actualizado correctamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el producto", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Insertar nuevo producto
                    int id = _productoBLL.Insertar(_producto);
                    if (id > 0)
                    {
                        MessageBox.Show("Producto agregado correctamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el producto", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar producto: " + ex.Message, "Error",
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