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
//de momento funciona eliminar pero editar y agregar todavia no todavia no he creado el los formularios para hacer dicha accion
//para la opcion de eliminar no ocupo un formulario porque ya que solo se confirma y eso ya lo tengo


 

namespace GUI
{
    public partial class FormProveedores : Form
    {
        // esta es una variable para usar la capa BLL
        private readonly ProveedorBLL _proveedorBLL = new ProveedorBLL();

        public FormProveedores()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; //elimino los bordes para que se vea mejor en el panel
        }

        private void FormProveedores_Load(object sender, EventArgs e)
        {
            // preparo la tabla para mostrar datos
            ConfigurarDataGridView();

            // cargo los datos de proveedores desde la capa BLL
            CargarProveedores();

            // aca conecto los botones con sus funciones correspondientes
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
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
                List<Proveedor> proveedores = _proveedorBLL.ObtenerTodos();

                // con esto se limpia la tabla antes de cargar nuevos datos
                dgvProveedores.Rows.Clear();

                // agrego cada proveedor a la tabla
                foreach (var proveedor in proveedores)
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
                // nuevo proveedor con datos de ejemplo
                // estos datos se tomaran en el formulario que haré 
                Proveedor nuevoProveedor = new Proveedor
                {
                    Nombre = "Nuevo Proveedor",
                    Telefono = "555-1111",
                    Email = "nuevo@ejemplo.com",
                    Direccion = "Dirección de prueba"
                };

                // uso la capa BLL para insertar el proveedor en la base de datos
                int id = _proveedorBLL.Insertar(nuevoProveedor);

                // Muestro un mensaje de exito
                MessageBox.Show("Proveedor agregado con ID: " + id, "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // con esto actualizo la tabla con los datos nuevos
                CargarProveedores();
            }
            catch (Exception ex)
            {
                // se muestra un mensaje si hay algún error
                MessageBox.Show("Error al agregar proveedor: " + ex.Message, "Error",
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

                    // simulo un cambio en el nombre
                    proveedor.Nombre += " (Modificado)";

                    // actualizo el proveedor usando la capa BLL
                    bool resultado = _proveedorBLL.Actualizar(proveedor);

                    if (resultado)
                    {
                        // Muestro mensaje de éxito
                        MessageBox.Show("Proveedor actualizado correctamente", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Actualizo la tabla
                        CargarProveedores();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el proveedor", "Error",
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
            // Obtengo el texto de búsqueda
            string filtro = txtBuscar.Text.Trim().ToLower();

            // Solo busco si hay al menos 3 letras
            if (filtro.Length >= 3)
            {
                try
                {
                    // se busca proveedores que coincidan usando la capa BLL
                    List<Proveedor> proveedoresFiltrados = _proveedorBLL.BuscarPorNombre(filtro);

                    // para limpiar la tabla
                    dgvProveedores.Rows.Clear();

                    // agrego los proveedores encontrados
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
                    // se muestra yb mensaje si hay error
                    MessageBox.Show("Error al buscar proveedores: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (filtro.Length == 0)
            {
                // si se borró todo el texto cargo todos los proveedores
                CargarProveedores();
            }
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            //se usará más adelante para filtrar por diferentes campos
        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Esto se usará despues para las acciones al hacer clic en celdas
        }
    }
}