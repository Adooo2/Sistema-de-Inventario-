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
    public partial class FormProveedores : Form
    {
        // esta es una variable para usar la capa BLL
        private readonly ProveedorBLL _proveedorBLL = new ProveedorBLL();
        // agrego una lista para almacenar todos los proveedores
        private List<Proveedor> _proveedores;

        public FormProveedores()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; //elimino los bordes para que se vea mejor en el panel
        }

        private void FormProveedores_Load(object sender, EventArgs e)
        {
            // preparo la tabla para mostrar datos
            ConfigurarDataGridView();

            // configuro el combo de filtro
            ConfigurarComboFiltro();

            // cargo los datos de proveedores desde la capa BLL
            CargarProveedores();

            // aca conecto los botones con sus funciones correspondientes
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
        }

        private void ConfigurarComboFiltro()
        {
            cmbFiltro.Items.Clear();
            cmbFiltro.Items.Add("Todos los proveedores");
            cmbFiltro.Items.Add("Por nombre");
            cmbFiltro.Items.Add("Por teléfono");
            cmbFiltro.Items.Add("Por email");
            cmbFiltro.Items.Add("Por dirección");
            cmbFiltro.SelectedIndex = 0;
        }

        private void ConfigurarDataGridView()
        {   //si me queda tiempo investigar como personalizar el datagridview 
            //propiedades de las columnas para que se vean mejor
            dgvProveedores.Columns["col"].Visible = false;  // Oculto el ID
            dgvProveedores.Columns["col2"].Width = 150;     // Ajusto ancho de Nombre
            dgvProveedores.Columns["col3"].Width = 120;     // Ajusto ancho de Contacto
            dgvProveedores.Columns["col4"].Width = 100;     // Ajusto ancho de Teléfono
            dgvProveedores.Columns["col5"].Width = 150;     // Ajusto ancho de Email
            dgvProveedores.Columns["col6"].Width = 200;     // Ajusto ancho de Dirección
        }

        private void CargarProveedores()
        {
            try
            {
                // aca obtengo todos los proveedores usando la capa BLL
                _proveedores = _proveedorBLL.ObtenerTodos();

                // con esto se limpia la tabla antes de cargar nuevos datos
                dgvProveedores.Rows.Clear();

                // agrego cada proveedor a la tabla
                foreach (var proveedor in _proveedores)
                {
                    dgvProveedores.Rows.Add(
                        proveedor.Id,
                        proveedor.Nombre,
                        "", // No tengo contacto en mi entidad Proveedor
                        proveedor.Telefono,
                        proveedor.Email,
                        proveedor.Direccion
                    );
                }
            }
            catch (Exception ex)
            {
                // Muestro un mensaje si hay algún error
                MessageBox.Show("Error al cargar proveedores: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                FormProveedoresDetalle formDetalle = new FormProveedoresDetalle();
                if (formDetalle.ShowDialog() == DialogResult.OK)
                {
                    // Si el usuario guardó un proveedor, actualizo la tabla
                    CargarProveedores();
                }
            }
            catch (Exception ex)
            {
                // se muestra un mensaje si hay algún error
                MessageBox.Show("Error al abrir formulario: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // se verifica si el usuario seleccionó algún proveedor
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                try
                {
                    // se obtiene el ID del proveedor seleccionado
                    int id = Convert.ToInt32(dgvProveedores.SelectedRows[0].Cells["col"].Value);

                    // obtengo el proveedor completo usando la capa BLL
                    Proveedor proveedor = _proveedorBLL.ObtenerPorId(id);

                    if (proveedor != null)
                    {
                        FormProveedoresDetalle formDetalle = new FormProveedoresDetalle(proveedor);
                        if (formDetalle.ShowDialog() == DialogResult.OK)
                        {
                            // Actualizo la tabla
                            CargarProveedores();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el proveedor seleccionado", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Muestro mensaje si hay error
                    MessageBox.Show("Error al editar proveedor: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Aviso al usuario que debe seleccionar un proveedor
                MessageBox.Show("Debe seleccionar un proveedor para editar", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //si el usuario seleccionó algún proveedor
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                //confirmación antes de eliminar
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este proveedor?",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Si el usuario confirma, procedo con la eliminación
                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        // Obtengo el ID del proveedor seleccionado
                        int id = Convert.ToInt32(dgvProveedores.SelectedRows[0].Cells["col"].Value);

                        // Elimino el proveedor usando la capa BLL
                        bool exitoso = _proveedorBLL.Eliminar(id);

                        if (exitoso)
                        {
                            //mensaje de éxito
                            MessageBox.Show("Proveedor eliminado correctamente", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // actualizo la tabla
                            CargarProveedores();
                        }
                        else
                        {
                            //mensaje si no se pudo eliminar
                            MessageBox.Show("No se pudo eliminar el proveedor", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        //mensaje si hay error
                        MessageBox.Show("Error al eliminar proveedor: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // aviso al usuario que debe seleccionar un proveedor
                MessageBox.Show("Debe seleccionar un proveedor para eliminar", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // ahora llamo al método para filtrar proveedores
            FiltrarProveedores();
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cuando cambia el filtro, actualizo la lista
            FiltrarProveedores();
        }

        private void FiltrarProveedores()
        {
            try
            {
                // Obtengo el texto de búsqueda
                string filtro = txtBuscar.Text.Trim().ToLower();
                string filtroSeleccionado = cmbFiltro.SelectedItem?.ToString() ?? "Todos los proveedores";

                // para limpiar la tabla
                dgvProveedores.Rows.Clear();

                // si no hay proveedores cargados, los cargo
                if (_proveedores == null || _proveedores.Count == 0)
                {
                    _proveedores = _proveedorBLL.ObtenerTodos();
                }

                // empiezo con todos los proveedores
                var proveedoresFiltrados = _proveedores;

                // solo aplico filtro si hay texto
                if (!string.IsNullOrEmpty(filtro))
                {
                    // filtro según el criterio seleccionado
                    switch (filtroSeleccionado)
                    {
                        case "Por nombre":
                            proveedoresFiltrados = proveedoresFiltrados.Where(p =>
                                (p.Nombre?.ToLower() ?? "").Contains(filtro)).ToList();
                            break;

                        case "Por teléfono":
                            proveedoresFiltrados = proveedoresFiltrados.Where(p =>
                                (p.Telefono?.ToLower() ?? "").Contains(filtro)).ToList();
                            break;

                        case "Por email":
                            proveedoresFiltrados = proveedoresFiltrados.Where(p =>
                                (p.Email?.ToLower() ?? "").Contains(filtro)).ToList();
                            break;

                        case "Por dirección":
                            proveedoresFiltrados = proveedoresFiltrados.Where(p =>
                                (p.Direccion?.ToLower() ?? "").Contains(filtro)).ToList();
                            break;

                        default: // "Todos los proveedores"
                            proveedoresFiltrados = proveedoresFiltrados.Where(p =>
                                (p.Nombre?.ToLower() ?? "").Contains(filtro) ||
                                (p.Telefono?.ToLower() ?? "").Contains(filtro) ||
                                (p.Email?.ToLower() ?? "").Contains(filtro) ||
                                (p.Direccion?.ToLower() ?? "").Contains(filtro)).ToList();
                            break;
                    }
                }

                // agrego los proveedores filtrados a la tabla
                foreach (var proveedor in proveedoresFiltrados)
                {
                    dgvProveedores.Rows.Add(
                        proveedor.Id,
                        proveedor.Nombre,
                        "", //aca no hay conecto en proveedor 
                        proveedor.Telefono,
                        proveedor.Email,
                        proveedor.Direccion
                    );
                }
            }
            catch (Exception ex)
            {
                // se muestra un mensaje si hay error
                MessageBox.Show("Error al filtrar proveedores: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Esto se usará despues para las acciones al hacer clic en celdas
        }
    }
}