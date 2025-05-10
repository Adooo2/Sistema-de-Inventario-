namespace GUI
{
    partial class FormReportes
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnInventarioActual = new System.Windows.Forms.Button();
            this.btnProductosStockBajo = new System.Windows.Forms.Button();
            this.btnMovimientos = new System.Windows.Forms.Button();
            this.btnEntradas = new System.Windows.Forms.Button();
            this.btnSalidas = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAplicarFiltro = new System.Windows.Forms.Button();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.lblCategoría = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.lblTituloReporte = new System.Windows.Forms.Label();
            this.lblResumen = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelTitulo.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 884F));
            this.tableLayoutPanel1.Controls.Add(this.panelTitulo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelFiltros, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgvReporte, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblTituloReporte, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblResumen, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 561);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panelTitulo.Controls.Add(this.lblTitulo);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTitulo.Location = new System.Drawing.Point(3, 3);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(878, 44);
            this.panelTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(878, 44);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "REPORTES DE INVENTARIO\n\n\n";
            // 
            // panelFiltros
            // 
            this.panelFiltros.Controls.Add(this.tableLayoutPanel2);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFiltros.Location = new System.Drawing.Point(3, 53);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(878, 54);
            this.panelFiltros.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btnInventarioActual, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnProductosStockBajo, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnMovimientos, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnEntradas, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSalidas, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(878, 54);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnInventarioActual
            // 
            this.btnInventarioActual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnInventarioActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInventarioActual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventarioActual.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnInventarioActual.Location = new System.Drawing.Point(3, 3);
            this.btnInventarioActual.Name = "btnInventarioActual";
            this.btnInventarioActual.Size = new System.Drawing.Size(169, 48);
            this.btnInventarioActual.TabIndex = 0;
            this.btnInventarioActual.Text = "Inventario Actual";
            this.btnInventarioActual.UseVisualStyleBackColor = false;
            this.btnInventarioActual.Click += new System.EventHandler(this.btnInventarioActual_Click_1);
            // 
            // btnProductosStockBajo
            // 
            this.btnProductosStockBajo.BackColor = System.Drawing.Color.DarkOrange;
            this.btnProductosStockBajo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProductosStockBajo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductosStockBajo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnProductosStockBajo.Location = new System.Drawing.Point(178, 3);
            this.btnProductosStockBajo.Name = "btnProductosStockBajo";
            this.btnProductosStockBajo.Size = new System.Drawing.Size(169, 48);
            this.btnProductosStockBajo.TabIndex = 1;
            this.btnProductosStockBajo.Text = "Productos Stock Bajo";
            this.btnProductosStockBajo.UseVisualStyleBackColor = false;
            this.btnProductosStockBajo.Click += new System.EventHandler(this.btnProductosStockBajo_Click_1);
            // 
            // btnMovimientos
            // 
            this.btnMovimientos.BackColor = System.Drawing.Color.Red;
            this.btnMovimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMovimientos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMovimientos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMovimientos.Location = new System.Drawing.Point(353, 3);
            this.btnMovimientos.Name = "btnMovimientos";
            this.btnMovimientos.Size = new System.Drawing.Size(169, 48);
            this.btnMovimientos.TabIndex = 2;
            this.btnMovimientos.Text = "Movimientos";
            this.btnMovimientos.UseVisualStyleBackColor = false;
            this.btnMovimientos.Click += new System.EventHandler(this.btnMovimientos_Click);
            // 
            // btnEntradas
            // 
            this.btnEntradas.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnEntradas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEntradas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntradas.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEntradas.Location = new System.Drawing.Point(528, 3);
            this.btnEntradas.Name = "btnEntradas";
            this.btnEntradas.Size = new System.Drawing.Size(169, 48);
            this.btnEntradas.TabIndex = 3;
            this.btnEntradas.Text = "Entradas";
            this.btnEntradas.UseVisualStyleBackColor = false;
            this.btnEntradas.Click += new System.EventHandler(this.btnEntradas_Click);
            // 
            // btnSalidas
            // 
            this.btnSalidas.BackColor = System.Drawing.Color.Purple;
            this.btnSalidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSalidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalidas.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSalidas.Location = new System.Drawing.Point(703, 3);
            this.btnSalidas.Name = "btnSalidas";
            this.btnSalidas.Size = new System.Drawing.Size(172, 48);
            this.btnSalidas.TabIndex = 4;
            this.btnSalidas.Text = "Salidas";
            this.btnSalidas.UseVisualStyleBackColor = false;
            this.btnSalidas.Click += new System.EventHandler(this.btnSalidas_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.btnAplicarFiltro);
            this.panel1.Controls.Add(this.cmbCategoria);
            this.panel1.Controls.Add(this.cmbProducto);
            this.panel1.Controls.Add(this.lblCategoría);
            this.panel1.Controls.Add(this.lblProducto);
            this.panel1.Controls.Add(this.lblHasta);
            this.panel1.Controls.Add(this.dtpFechaFin);
            this.panel1.Controls.Add(this.dtpFechaInicio);
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 99);
            this.panel1.TabIndex = 3;
            this.panel1.Visible = false;
            // 
            // btnAplicarFiltro
            // 
            this.btnAplicarFiltro.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAplicarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicarFiltro.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAplicarFiltro.Location = new System.Drawing.Point(450, 20);
            this.btnAplicarFiltro.Name = "btnAplicarFiltro";
            this.btnAplicarFiltro.Size = new System.Drawing.Size(90, 25);
            this.btnAplicarFiltro.TabIndex = 8;
            this.btnAplicarFiltro.Text = "Aplicar Filtro";
            this.btnAplicarFiltro.UseVisualStyleBackColor = false;
            this.btnAplicarFiltro.Click += new System.EventHandler(this.btnAplicarFiltro_Click);
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(290, 32);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(150, 21);
            this.cmbCategoria.TabIndex = 7;
            // 
            // cmbProducto
            // 
            this.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(70, 32);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(150, 21);
            this.cmbProducto.TabIndex = 6;
            // 
            // lblCategoría
            // 
            this.lblCategoría.AutoSize = true;
            this.lblCategoría.Location = new System.Drawing.Point(230, 35);
            this.lblCategoría.Name = "lblCategoría";
            this.lblCategoría.Size = new System.Drawing.Size(54, 13);
            this.lblCategoría.TabIndex = 5;
            this.lblCategoría.Text = "Categoría";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(10, 35);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(50, 13);
            this.lblProducto.TabIndex = 4;
            this.lblProducto.Text = "Producto";
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(170, 10);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(35, 13);
            this.lblHasta.TabIndex = 3;
            this.lblHasta.Text = "Hasta";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(220, 8);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaFin.TabIndex = 2;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(60, 8);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaInicio.TabIndex = 1;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(10, 10);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(38, 13);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Desde";
            // 
            // dgvReporte
            // 
            this.dgvReporte.AllowUserToAddRows = false;
            this.dgvReporte.AllowUserToDeleteRows = false;
            this.dgvReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporte.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReporte.GridColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvReporte.Location = new System.Drawing.Point(3, 259);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReporte.Size = new System.Drawing.Size(878, 274);
            this.dgvReporte.TabIndex = 2;
            // 
            // lblTituloReporte
            // 
            this.lblTituloReporte.AutoSize = true;
            this.lblTituloReporte.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblTituloReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTituloReporte.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloReporte.Location = new System.Drawing.Point(3, 215);
            this.lblTituloReporte.Name = "lblTituloReporte";
            this.lblTituloReporte.Size = new System.Drawing.Size(878, 41);
            this.lblTituloReporte.TabIndex = 4;
            this.lblTituloReporte.Text = "Reporte: Inventario Actual";
            this.lblTituloReporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblResumen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumen.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblResumen.Location = new System.Drawing.Point(3, 536);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(878, 25);
            this.lblResumen.TabIndex = 5;
            this.lblResumen.Text = "Total: 0 productos | Valor total: $0.00";
            this.lblResumen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reportes de Inventario";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelTitulo.ResumeLayout(false);
            this.panelFiltros.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnInventarioActual;
        private System.Windows.Forms.Button btnProductosStockBajo;
        private System.Windows.Forms.Button btnMovimientos;
        private System.Windows.Forms.Button btnEntradas;
        private System.Windows.Forms.Button btnSalidas;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.Label lblCategoría;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Button btnAplicarFiltro;
        private System.Windows.Forms.Label lblTituloReporte;
        private System.Windows.Forms.Label lblResumen;
    }
}