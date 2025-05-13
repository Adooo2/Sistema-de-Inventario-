namespace GUI
{
    partial class FormMenu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTituloDashboard = new System.Windows.Forms.Label();
            this.panelGridStockBajo = new System.Windows.Forms.Panel();
            this.dgvStockBajo = new System.Windows.Forms.DataGridView();
            this.colIcono = new System.Windows.Forms.DataGridViewImageColumn();
            this.colCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblGridStockBajo = new System.Windows.Forms.Label();
            this.panelGridUltimosIngresos = new System.Windows.Forms.Panel();
            this.dgvUltimosIngresos = new System.Windows.Forms.DataGridView();
            this.lblGridUltimosIngresos = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblGastos = new System.Windows.Forms.Label();
            this.lblGastosHoy = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblIngresos = new System.Windows.Forms.Label();
            this.lblIngresosHoy = new System.Windows.Forms.Label();
            this.panelTotalCategorias = new System.Windows.Forms.Panel();
            this.lblTotalCategorias = new System.Windows.Forms.Label();
            this.lblTituloCategorias = new System.Windows.Forms.Label();
            this.panelTotalProveedores = new System.Windows.Forms.Panel();
            this.lblTotalProveedores = new System.Windows.Forms.Label();
            this.lblTituloProveedores = new System.Windows.Forms.Label();
            this.panelStockBajo = new System.Windows.Forms.Panel();
            this.lblStockBajo = new System.Windows.Forms.Label();
            this.lblTituloStockBajo = new System.Windows.Forms.Label();
            this.panelTotalProductos = new System.Windows.Forms.Panel();
            this.lblTotalProductos = new System.Windows.Forms.Label();
            this.lblTituloProductos = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelGridStockBajo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockBajo)).BeginInit();
            this.panelGridUltimosIngresos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUltimosIngresos)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelTotalCategorias.SuspendLayout();
            this.panelTotalProveedores.SuspendLayout();
            this.panelStockBajo.SuspendLayout();
            this.panelTotalProductos.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloDashboard
            // 
            this.lblTituloDashboard.AutoSize = true;
            this.lblTituloDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloDashboard.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloDashboard.Location = new System.Drawing.Point(0, 0);
            this.lblTituloDashboard.Name = "lblTituloDashboard";
            this.lblTituloDashboard.Size = new System.Drawing.Size(345, 32);
            this.lblTituloDashboard.TabIndex = 0;
            this.lblTituloDashboard.Text = "Menú- Sistema de Inventario";
            this.lblTituloDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelGridStockBajo
            // 
            this.panelGridStockBajo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGridStockBajo.AutoSize = true;
            this.panelGridStockBajo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(219)))));
            this.panelGridStockBajo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGridStockBajo.Controls.Add(this.dgvStockBajo);
            this.panelGridStockBajo.Controls.Add(this.lblGridStockBajo);
            this.panelGridStockBajo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panelGridStockBajo.Location = new System.Drawing.Point(6, 389);
            this.panelGridStockBajo.Name = "panelGridStockBajo";
            this.panelGridStockBajo.Size = new System.Drawing.Size(1414, 235);
            this.panelGridStockBajo.TabIndex = 10;
            // 
            // dgvStockBajo
            // 
            this.dgvStockBajo.AllowUserToAddRows = false;
            this.dgvStockBajo.AllowUserToDeleteRows = false;
            this.dgvStockBajo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStockBajo.BackgroundColor = System.Drawing.Color.Salmon;
            this.dgvStockBajo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStockBajo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStockBajo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStockBajo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStockBajo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIcono,
            this.colCodigo,
            this.colNombre,
            this.colStock,
            this.colCategoria});
            this.dgvStockBajo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStockBajo.Location = new System.Drawing.Point(0, 25);
            this.dgvStockBajo.Name = "dgvStockBajo";
            this.dgvStockBajo.ReadOnly = true;
            this.dgvStockBajo.RowHeadersVisible = false;
            this.dgvStockBajo.Size = new System.Drawing.Size(1412, 208);
            this.dgvStockBajo.TabIndex = 1;
            // 
            // colIcono
            // 
            this.colIcono.FillWeight = 141.5431F;
            this.colIcono.HeaderText = "";
            this.colIcono.Name = "colIcono";
            this.colIcono.ReadOnly = true;
            // 
            // colCodigo
            // 
            this.colCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCodigo.FillWeight = 100.4802F;
            this.colCodigo.HeaderText = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.ReadOnly = true;
            // 
            // colNombre
            // 
            this.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNombre.FillWeight = 96.01386F;
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            // 
            // colStock
            // 
            this.colStock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStock.FillWeight = 98.51115F;
            this.colStock.HeaderText = "Stock ";
            this.colStock.Name = "colStock";
            this.colStock.ReadOnly = true;
            // 
            // colCategoria
            // 
            this.colCategoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCategoria.FillWeight = 63.45179F;
            this.colCategoria.HeaderText = "Categoría";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.ReadOnly = true;
            // 
            // lblGridStockBajo
            // 
            this.lblGridStockBajo.AutoSize = true;
            this.lblGridStockBajo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGridStockBajo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGridStockBajo.ForeColor = System.Drawing.Color.Salmon;
            this.lblGridStockBajo.Location = new System.Drawing.Point(0, 0);
            this.lblGridStockBajo.Name = "lblGridStockBajo";
            this.lblGridStockBajo.Size = new System.Drawing.Size(238, 25);
            this.lblGridStockBajo.TabIndex = 0;
            this.lblGridStockBajo.Text = "Productos con stock bajo";
            // 
            // panelGridUltimosIngresos
            // 
            this.panelGridUltimosIngresos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGridUltimosIngresos.AutoSize = true;
            this.panelGridUltimosIngresos.BackColor = System.Drawing.Color.ForestGreen;
            this.panelGridUltimosIngresos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGridUltimosIngresos.Controls.Add(this.dgvUltimosIngresos);
            this.panelGridUltimosIngresos.Controls.Add(this.lblGridUltimosIngresos);
            this.panelGridUltimosIngresos.Location = new System.Drawing.Point(7, 627);
            this.panelGridUltimosIngresos.Name = "panelGridUltimosIngresos";
            this.panelGridUltimosIngresos.Size = new System.Drawing.Size(1413, 257);
            this.panelGridUltimosIngresos.TabIndex = 11;
            this.panelGridUltimosIngresos.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGridUltimosIngresos_Paint);
            // 
            // dgvUltimosIngresos
            // 
            this.dgvUltimosIngresos.AllowUserToAddRows = false;
            this.dgvUltimosIngresos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.dgvUltimosIngresos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUltimosIngresos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUltimosIngresos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dgvUltimosIngresos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUltimosIngresos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUltimosIngresos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUltimosIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUltimosIngresos.Cursor = System.Windows.Forms.Cursors.Arrow;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUltimosIngresos.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUltimosIngresos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUltimosIngresos.Location = new System.Drawing.Point(0, 25);
            this.dgvUltimosIngresos.Name = "dgvUltimosIngresos";
            this.dgvUltimosIngresos.RowHeadersVisible = false;
            this.dgvUltimosIngresos.Size = new System.Drawing.Size(1411, 230);
            this.dgvUltimosIngresos.TabIndex = 1;
            // 
            // lblGridUltimosIngresos
            // 
            this.lblGridUltimosIngresos.AutoSize = true;
            this.lblGridUltimosIngresos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGridUltimosIngresos.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGridUltimosIngresos.ForeColor = System.Drawing.Color.Black;
            this.lblGridUltimosIngresos.Location = new System.Drawing.Point(0, 0);
            this.lblGridUltimosIngresos.Name = "lblGridUltimosIngresos";
            this.lblGridUltimosIngresos.Size = new System.Drawing.Size(279, 25);
            this.lblGridUltimosIngresos.TabIndex = 0;
            this.lblGridUltimosIngresos.Text = "Últimos productos ingresados";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Controls.Add(this.lblGastos);
            this.panel2.Controls.Add(this.lblGastosHoy);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 153);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(464, 142);
            this.panel2.TabIndex = 9;
            // 
            // lblGastos
            // 
            this.lblGastos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGastos.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGastos.Location = new System.Drawing.Point(0, 0);
            this.lblGastos.Name = "lblGastos";
            this.lblGastos.Size = new System.Drawing.Size(464, 25);
            this.lblGastos.TabIndex = 8;
            this.lblGastos.Text = "Total Gastos hoy ";
            this.lblGastos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGastosHoy
            // 
            this.lblGastosHoy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGastosHoy.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGastosHoy.Location = new System.Drawing.Point(0, 0);
            this.lblGastosHoy.Name = "lblGastosHoy";
            this.lblGastosHoy.Size = new System.Drawing.Size(464, 142);
            this.lblGastosHoy.TabIndex = 7;
            this.lblGastosHoy.Text = "0";
            this.lblGastosHoy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGastosHoy.Click += new System.EventHandler(this.lblGastosHoy_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Controls.Add(this.lblIngresos);
            this.panel1.Controls.Add(this.lblIngresosHoy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(476, 153);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 142);
            this.panel1.TabIndex = 8;
            // 
            // lblIngresos
            // 
            this.lblIngresos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIngresos.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresos.Location = new System.Drawing.Point(0, 0);
            this.lblIngresos.Name = "lblIngresos";
            this.lblIngresos.Size = new System.Drawing.Size(465, 25);
            this.lblIngresos.TabIndex = 7;
            this.lblIngresos.Text = "Total Ingresos hoy ";
            this.lblIngresos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblIngresosHoy
            // 
            this.lblIngresosHoy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIngresosHoy.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngresosHoy.Location = new System.Drawing.Point(0, 0);
            this.lblIngresosHoy.Name = "lblIngresosHoy";
            this.lblIngresosHoy.Size = new System.Drawing.Size(465, 142);
            this.lblIngresosHoy.TabIndex = 6;
            this.lblIngresosHoy.Text = "0";
            this.lblIngresosHoy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIngresosHoy.Click += new System.EventHandler(this.lblIngresosHoy_Click);
            // 
            // panelTotalCategorias
            // 
            this.panelTotalCategorias.BackColor = System.Drawing.Color.LightGreen;
            this.panelTotalCategorias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTotalCategorias.Controls.Add(this.lblTotalCategorias);
            this.panelTotalCategorias.Controls.Add(this.lblTituloCategorias);
            this.panelTotalCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTotalCategorias.Location = new System.Drawing.Point(949, 153);
            this.panelTotalCategorias.Margin = new System.Windows.Forms.Padding(4);
            this.panelTotalCategorias.Name = "panelTotalCategorias";
            this.panelTotalCategorias.Size = new System.Drawing.Size(466, 142);
            this.panelTotalCategorias.TabIndex = 3;
            // 
            // lblTotalCategorias
            // 
            this.lblTotalCategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalCategorias.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCategorias.Location = new System.Drawing.Point(0, 24);
            this.lblTotalCategorias.Name = "lblTotalCategorias";
            this.lblTotalCategorias.Size = new System.Drawing.Size(464, 116);
            this.lblTotalCategorias.TabIndex = 1;
            this.lblTotalCategorias.Text = "0";
            this.lblTotalCategorias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloCategorias
            // 
            this.lblTituloCategorias.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloCategorias.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloCategorias.Location = new System.Drawing.Point(0, 0);
            this.lblTituloCategorias.Name = "lblTituloCategorias";
            this.lblTituloCategorias.Size = new System.Drawing.Size(464, 24);
            this.lblTituloCategorias.TabIndex = 0;
            this.lblTituloCategorias.Text = "Total Categorias";
            this.lblTituloCategorias.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelTotalProveedores
            // 
            this.panelTotalProveedores.BackColor = System.Drawing.Color.LightYellow;
            this.panelTotalProveedores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTotalProveedores.Controls.Add(this.lblTotalProveedores);
            this.panelTotalProveedores.Controls.Add(this.lblTituloProveedores);
            this.panelTotalProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTotalProveedores.Location = new System.Drawing.Point(949, 4);
            this.panelTotalProveedores.Margin = new System.Windows.Forms.Padding(4);
            this.panelTotalProveedores.Name = "panelTotalProveedores";
            this.panelTotalProveedores.Size = new System.Drawing.Size(466, 141);
            this.panelTotalProveedores.TabIndex = 4;
            // 
            // lblTotalProveedores
            // 
            this.lblTotalProveedores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalProveedores.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProveedores.Location = new System.Drawing.Point(0, 25);
            this.lblTotalProveedores.Name = "lblTotalProveedores";
            this.lblTotalProveedores.Size = new System.Drawing.Size(464, 114);
            this.lblTotalProveedores.TabIndex = 1;
            this.lblTotalProveedores.Text = "0";
            this.lblTotalProveedores.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloProveedores
            // 
            this.lblTituloProveedores.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloProveedores.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloProveedores.Location = new System.Drawing.Point(0, 0);
            this.lblTituloProveedores.Name = "lblTituloProveedores";
            this.lblTituloProveedores.Size = new System.Drawing.Size(464, 25);
            this.lblTituloProveedores.TabIndex = 0;
            this.lblTituloProveedores.Text = "Total Proveedores";
            this.lblTituloProveedores.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelStockBajo
            // 
            this.panelStockBajo.BackColor = System.Drawing.Color.Salmon;
            this.panelStockBajo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStockBajo.Controls.Add(this.lblStockBajo);
            this.panelStockBajo.Controls.Add(this.lblTituloStockBajo);
            this.panelStockBajo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStockBajo.Location = new System.Drawing.Point(476, 4);
            this.panelStockBajo.Margin = new System.Windows.Forms.Padding(4);
            this.panelStockBajo.Name = "panelStockBajo";
            this.panelStockBajo.Size = new System.Drawing.Size(465, 141);
            this.panelStockBajo.TabIndex = 2;
            // 
            // lblStockBajo
            // 
            this.lblStockBajo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStockBajo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStockBajo.Location = new System.Drawing.Point(0, 25);
            this.lblStockBajo.Name = "lblStockBajo";
            this.lblStockBajo.Size = new System.Drawing.Size(463, 114);
            this.lblStockBajo.TabIndex = 1;
            this.lblStockBajo.Text = "0";
            this.lblStockBajo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloStockBajo
            // 
            this.lblTituloStockBajo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloStockBajo.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloStockBajo.Location = new System.Drawing.Point(0, 0);
            this.lblTituloStockBajo.Name = "lblTituloStockBajo";
            this.lblTituloStockBajo.Size = new System.Drawing.Size(463, 25);
            this.lblTituloStockBajo.TabIndex = 0;
            this.lblTituloStockBajo.Text = "Productos con Stock Bajo";
            this.lblTituloStockBajo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelTotalProductos
            // 
            this.panelTotalProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(204)))), ((int)(((byte)(227)))));
            this.panelTotalProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTotalProductos.Controls.Add(this.lblTotalProductos);
            this.panelTotalProductos.Controls.Add(this.lblTituloProductos);
            this.panelTotalProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTotalProductos.Location = new System.Drawing.Point(4, 4);
            this.panelTotalProductos.Margin = new System.Windows.Forms.Padding(4);
            this.panelTotalProductos.Name = "panelTotalProductos";
            this.panelTotalProductos.Size = new System.Drawing.Size(464, 141);
            this.panelTotalProductos.TabIndex = 1;
            // 
            // lblTotalProductos
            // 
            this.lblTotalProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalProductos.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProductos.Location = new System.Drawing.Point(0, 25);
            this.lblTotalProductos.Name = "lblTotalProductos";
            this.lblTotalProductos.Size = new System.Drawing.Size(462, 114);
            this.lblTotalProductos.TabIndex = 1;
            this.lblTotalProductos.Text = "0";
            this.lblTotalProductos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloProductos
            // 
            this.lblTituloProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloProductos.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloProductos.Location = new System.Drawing.Point(0, 0);
            this.lblTituloProductos.Name = "lblTituloProductos";
            this.lblTituloProductos.Size = new System.Drawing.Size(462, 25);
            this.lblTituloProductos.TabIndex = 0;
            this.lblTituloProductos.Text = "Total Productos";
            this.lblTituloProductos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.panelTotalProductos, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelTotalCategorias, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelStockBajo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelTotalProveedores, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 32);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1419, 299);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1419, 1100);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelGridUltimosIngresos);
            this.Controls.Add(this.panelGridStockBajo);
            this.Controls.Add(this.lblTituloDashboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMenu";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.panelGridStockBajo.ResumeLayout(false);
            this.panelGridStockBajo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockBajo)).EndInit();
            this.panelGridUltimosIngresos.ResumeLayout(false);
            this.panelGridUltimosIngresos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUltimosIngresos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelTotalCategorias.ResumeLayout(false);
            this.panelTotalProveedores.ResumeLayout(false);
            this.panelStockBajo.ResumeLayout(false);
            this.panelTotalProductos.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloDashboard;
        private System.Windows.Forms.Panel panelGridStockBajo;
        private System.Windows.Forms.DataGridView dgvStockBajo;
        private System.Windows.Forms.Label lblGridStockBajo;
        private System.Windows.Forms.Panel panelGridUltimosIngresos;
        private System.Windows.Forms.DataGridView dgvUltimosIngresos;
        private System.Windows.Forms.Label lblGridUltimosIngresos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblGastos;
        private System.Windows.Forms.Label lblGastosHoy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblIngresos;
        private System.Windows.Forms.Label lblIngresosHoy;
        private System.Windows.Forms.Panel panelTotalCategorias;
        private System.Windows.Forms.Label lblTotalCategorias;
        private System.Windows.Forms.Label lblTituloCategorias;
        private System.Windows.Forms.Panel panelTotalProveedores;
        private System.Windows.Forms.Label lblTotalProveedores;
        private System.Windows.Forms.Label lblTituloProveedores;
        private System.Windows.Forms.Panel panelStockBajo;
        private System.Windows.Forms.Label lblStockBajo;
        private System.Windows.Forms.Label lblTituloStockBajo;
        private System.Windows.Forms.Panel panelTotalProductos;
        private System.Windows.Forms.Label lblTotalProductos;
        private System.Windows.Forms.Label lblTituloProductos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewImageColumn colIcono;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoria;
    }
}