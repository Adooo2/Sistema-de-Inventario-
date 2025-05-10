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
    public partial class FormCategorias : Form
    {
        private readonly CategoriaBLL _categoriaBLL;
        private List<Categoria> _categorias;
        private int? _idCategoriaSeleccionada;

        public FormCategorias()
        {
            InitializeComponent();
            _categoriaBLL = new CategoriaBLL();

            this.Load += new System.EventHandler(this.FormCategorias_Load);
            txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
        }

        private void ConfigurarComboFiltro()
        {
            cmbFiltro.Items.Clear();
            cmbFiltro.Items.Add("Todas las categorías");

            //  las categorías para extraer tipos únicos
            if (_categorias == null || _categorias.Count == 0)
            {
                _categorias = _categoriaBLL.ObtenerTodos();
            }

            // Obtenemos tipos únicos de las descripciones
            var tiposUnicos = new HashSet<string>();
            foreach (var categoria in _categorias)
            {
                if (!string.IsNullOrEmpty(categoria.Descripcion))
                {
                    string primeraPalabra = categoria.Descripcion.Split(' ')[0];
                    if (!string.IsNullOrEmpty(primeraPalabra))
                    {
                        tiposUnicos.Add(primeraPalabra);
                    }
                }
            }

            // Agrego los tipos al combo
            foreach (var tipo in tiposUnicos)
            {
                cmbFiltro.Items.Add(tipo);
            }

            cmbFiltro.SelectedIndex = 0;
            cmbFiltro.SelectedIndexChanged += new EventHandler(cmbFiltro_SelectedIndexChanged);
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            ConfigurarComboFiltro();
            CargarCategorias();
        }

        private void ConfigurarDataGridView()
        {
            dgvCategorias.Columns.Clear();

            dgvCategorias.Columns.Add("IdCategoria", "ID");
            dgvCategorias.Columns.Add("Nombre", "Nombre");
            dgvCategorias.Columns.Add("Descripcion", "Descripción");

            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategorias.AllowUserToAddRows = false;
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.MultiSelect = false;

            dgvCategorias.CellClick += new DataGridViewCellEventHandler(dgvCategorias_CellClick);
        }

        private void CargarCategorias()
        {
            try
            {
                dgvCategorias.Rows.Clear();

                _categorias = _categoriaBLL.ObtenerTodos();

                foreach (var categoria in _categorias)
                {
                    dgvCategorias.Rows.Add(
                        categoria.IdCategoria,
                        categoria.Nombre,
                        categoria.Descripcion
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message,
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _idCategoriaSeleccionada = Convert.ToInt32(dgvCategorias.Rows[e.RowIndex].Cells["IdCategoria"].Value);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                FormCategoriasDetalle formDetalle = new FormCategoriasDetalle();
                if (formDetalle.ShowDialog() == DialogResult.OK)
                {
                    CargarCategorias();
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
            if (_idCategoriaSeleccionada.HasValue)
            {
                try
                {
                    Categoria categoria = _categoriaBLL.ObtenerPorId(_idCategoriaSeleccionada.Value);
                    if (categoria != null)
                    {
                        FormCategoriasDetalle formDetalle = new FormCategoriasDetalle(categoria);
                        if (formDetalle.ShowDialog() == DialogResult.OK)
                        {
                            CargarCategorias();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la categoría seleccionada",
                                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir formulario: " + ex.Message,
                                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una categoría",
                               "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idCategoriaSeleccionada.HasValue)
            {
                try
                {
                    if (MessageBox.Show("¿Está seguro que desea eliminar esta categoría?",
                                       "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (_categoriaBLL.Eliminar(_idCategoriaSeleccionada.Value))
                        {
                            MessageBox.Show("Categoría eliminada correctamente",
                                           "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarCategorias();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar la categoría",
                                           "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar categoría: " + ex.Message,
                                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una categoría",
                               "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarCategorias();
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarCategorias();
        }

        private void FiltrarCategorias()
        {
            try
            {
                string textoBusqueda = txtBuscar.Text.ToLower();
                string filtroSeleccionado = cmbFiltro.SelectedItem?.ToString() ?? "Todas las categorías";

                dgvCategorias.Rows.Clear();

                if (_categorias == null || _categorias.Count == 0)
                {
                    _categorias = _categoriaBLL.ObtenerTodos();
                }

                var categoriasFiltradas = _categorias;

                // Filtro por texto de búsqueda
                if (!string.IsNullOrEmpty(textoBusqueda))
                {
                    categoriasFiltradas = categoriasFiltradas.Where(c =>
                        (c.Nombre?.ToLower() ?? "").Contains(textoBusqueda) ||
                        (c.Descripcion?.ToLower() ?? "").Contains(textoBusqueda)).ToList();
                }

                // Filtro por tipo
                if (filtroSeleccionado != "Todas las categorías")
                {
                    categoriasFiltradas = categoriasFiltradas.Where(c =>
                        !string.IsNullOrEmpty(c.Descripcion) &&
                        c.Descripcion.StartsWith(filtroSeleccionado, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                foreach (var categoria in categoriasFiltradas)
                {
                    dgvCategorias.Rows.Add(
                        categoria.IdCategoria,
                        categoria.Nombre,
                        categoria.Descripcion
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar categorías: " + ex.Message,
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}