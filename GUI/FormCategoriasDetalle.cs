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
    public partial class FormCategoriasDetalle : Form
    {
        private readonly CategoriaBLL _categoriaBLL;
        private Categoria _categoria;
        private bool _esEdicion;

        // Constructor para nueva categoría
        public FormCategoriasDetalle()
        {
            InitializeComponent();
            _categoriaBLL = new CategoriaBLL();
            _categoria = new Categoria();
            _esEdicion = false;

            // Asociar eventos
            this.Load += new EventHandler(FormCategoriasDetalle_Load);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnCancelar.Click += new EventHandler(btnCancelar_Click);
        }

        // Constructor para editar categoría existente
        public FormCategoriasDetalle(Categoria categoria)
        {
            InitializeComponent();
            _categoriaBLL = new CategoriaBLL();
            _categoria = categoria;
            _esEdicion = true;

            // Asociar eventos
            this.Load += new EventHandler(FormCategoriasDetalle_Load);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnCancelar.Click += new EventHandler(btnCancelar_Click);
        }

        private void FormCategoriasDetalle_Load(object sender, EventArgs e)
        {
            if (_esEdicion)
            {
                lblTitulo.Text = "Editar Categoría";
                txtNombre.Text = _categoria.Nombre;
                txtDescripcion.Text = _categoria.Descripcion;
            }
            else
            {
                lblTitulo.Text = "Nueva Categoría";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    MessageBox.Show("El nombre es obligatorio",
                                   "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                // Asignar valores
                _categoria.Nombre = txtNombre.Text;
                _categoria.Descripcion = txtDescripcion.Text;

                bool resultado;

                if (_esEdicion)
                {
                    // Actualizar categoría existente
                    resultado = _categoriaBLL.Actualizar(_categoria);
                    if (resultado)
                    {
                        MessageBox.Show("Categoría actualizada correctamente",
                                       "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar la categoría",
                                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Insertar nueva categoría
                    resultado = _categoriaBLL.Insertar(_categoria);
                    if (resultado)
                    {
                        MessageBox.Show("Categoría agregada correctamente",
                                       "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar la categoría",
                                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar categoría: " + ex.Message,
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