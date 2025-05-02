namespace GUI
{
    partial class FormProveedores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.flowBotones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.flowBusqueda = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTitulo.SuspendLayout();
            this.tableLayoutMain.SuspendLayout();
            this.flowBotones.SuspendLayout();
            this.flowBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelTitulo.Controls.Add(this.lblTitulo);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(800, 60);
            this.panelTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(259, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "GESTIÓN DE PROVEEDORES";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 2;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.625F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.375F));
            this.tableLayoutMain.Controls.Add(this.flowBotones, 0, 0);
            this.tableLayoutMain.Controls.Add(this.flowBusqueda, 1, 0);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 60);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 1;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMain.Size = new System.Drawing.Size(800, 100);
            this.tableLayoutMain.TabIndex = 1;
            // 
            // flowBotones
            // 
            this.flowBotones.Controls.Add(this.btnAgregar);
            this.flowBotones.Controls.Add(this.btnEditar);
            this.flowBotones.Controls.Add(this.btnEliminar);
            this.flowBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowBotones.Location = new System.Drawing.Point(3, 3);
            this.flowBotones.Name = "flowBotones";
            this.flowBotones.Padding = new System.Windows.Forms.Padding(10);
            this.flowBotones.Size = new System.Drawing.Size(415, 94);
            this.flowBotones.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(15, 15);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(5);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(120, 40);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(145, 15);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(5);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(120, 40);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(275, 15);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(5);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(120, 40);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // flowBusqueda
            // 
            this.flowBusqueda.Controls.Add(this.cmbFiltro);
            this.flowBusqueda.Controls.Add(this.txtBuscar);
            this.flowBusqueda.Controls.Add(this.lblBuscar);
            this.flowBusqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowBusqueda.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowBusqueda.Location = new System.Drawing.Point(424, 3);
            this.flowBusqueda.Name = "flowBusqueda";
            this.flowBusqueda.Padding = new System.Windows.Forms.Padding(10);
            this.flowBusqueda.Size = new System.Drawing.Size(373, 94);
            this.flowBusqueda.TabIndex = 1;
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Location = new System.Drawing.Point(198, 15);
            this.cmbFiltro.Margin = new System.Windows.Forms.Padding(5);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(150, 21);
            this.cmbFiltro.TabIndex = 0;
            this.cmbFiltro.Text = "Todos";
            this.cmbFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbFiltro_SelectedIndexChanged);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(148, 46);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(5);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(200, 20);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(100, 41);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(40, 13);
            this.lblBuscar.TabIndex = 2;
            this.lblBuscar.Text = "Buscar";
            this.lblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.AllowUserToAddRows = false;
            this.dgvProveedores.AllowUserToDeleteRows = false;
            this.dgvProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col,
            this.col2,
            this.col3,
            this.col4,
            this.col5,
            this.col6});
            this.dgvProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProveedores.Location = new System.Drawing.Point(0, 160);
            this.dgvProveedores.MultiSelect = false;
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.ReadOnly = true;
            this.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedores.Size = new System.Drawing.Size(800, 290);
            this.dgvProveedores.TabIndex = 2;
            this.dgvProveedores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedores_CellContentClick);
            // 
            // col
            // 
            this.col.HeaderText = "Id";
            this.col.Name = "col";
            this.col.ReadOnly = true;
            this.col.Visible = false;
            // 
            // col2
            // 
            this.col2.HeaderText = "Nombre";
            this.col2.Name = "col2";
            this.col2.ReadOnly = true;
            // 
            // col3
            // 
            this.col3.HeaderText = "Contacto";
            this.col3.Name = "col3";
            this.col3.ReadOnly = true;
            // 
            // col4
            // 
            this.col4.HeaderText = "Teléfono ";
            this.col4.Name = "col4";
            this.col4.ReadOnly = true;
            // 
            // col5
            // 
            this.col5.HeaderText = "Email";
            this.col5.Name = "col5";
            this.col5.ReadOnly = true;
            // 
            // col6
            // 
            this.col6.HeaderText = "Dirección";
            this.col6.Name = "col6";
            this.col6.ReadOnly = true;
            // 
            // FormProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvProveedores);
            this.Controls.Add(this.tableLayoutMain);
            this.Controls.Add(this.panelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormProveedores";
            this.Text = "Proveedores";
            this.Load += new System.EventHandler(this.FormProveedores_Load);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.tableLayoutMain.ResumeLayout(false);
            this.flowBotones.ResumeLayout(false);
            this.flowBusqueda.ResumeLayout(false);
            this.flowBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.FlowLayoutPanel flowBotones;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.FlowLayoutPanel flowBusqueda;
        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.DataGridViewTextBoxColumn col;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col3;
        private System.Windows.Forms.DataGridViewTextBoxColumn col4;
        private System.Windows.Forms.DataGridViewTextBoxColumn col5;
        private System.Windows.Forms.DataGridViewTextBoxColumn col6;
    }
}