namespace GestionDeProductos
{
    partial class MainView
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEditar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.ordenarPorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SortID = new System.Windows.Forms.ToolStripMenuItem();
            this.SortNombre = new System.Windows.Forms.ToolStripMenuItem();
            this.SortCantidad = new System.Windows.Forms.ToolStripMenuItem();
            this.SortPrecio = new System.Windows.Forms.ToolStripMenuItem();
            this.SortTipo = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataTable = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripción = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eliminar = new System.Windows.Forms.Button();
            this.Nuevo = new System.Windows.Forms.Button();
            this.Editar = new System.Windows.Forms.Button();
            this.ComboFilter = new System.Windows.Forms.ComboBox();
            this.FilterLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.ordenarPorToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1064, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportCSV,
            this.ExportCSV});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // ImportCSV
            // 
            this.ImportCSV.Name = "ImportCSV";
            this.ImportCSV.Size = new System.Drawing.Size(224, 26);
            this.ImportCSV.Text = "Importar *.csv";
            this.ImportCSV.Click += new System.EventHandler(this.ImportFromCSV);
            // 
            // ExportCSV
            // 
            this.ExportCSV.Name = "ExportCSV";
            this.ExportCSV.Size = new System.Drawing.Size(224, 26);
            this.ExportCSV.Text = "Exportar *.csv";
            this.ExportCSV.Click += new System.EventHandler(this.ExportToCSV);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNuevo,
            this.MenuEditar,
            this.MenuEliminar});
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // MenuNuevo
            // 
            this.MenuNuevo.Name = "MenuNuevo";
            this.MenuNuevo.Size = new System.Drawing.Size(210, 26);
            this.MenuNuevo.Text = "Nuevo Producto";
            this.MenuNuevo.Click += new System.EventHandler(this.Create);
            // 
            // MenuEditar
            // 
            this.MenuEditar.Name = "MenuEditar";
            this.MenuEditar.Size = new System.Drawing.Size(210, 26);
            this.MenuEditar.Text = "Editar Producto";
            this.MenuEditar.Click += new System.EventHandler(this.Edit);
            // 
            // MenuEliminar
            // 
            this.MenuEliminar.Name = "MenuEliminar";
            this.MenuEliminar.Size = new System.Drawing.Size(210, 26);
            this.MenuEliminar.Text = "Eliminar Producto";
            this.MenuEliminar.Click += new System.EventHandler(this.Delete);
            // 
            // ordenarPorToolStripMenuItem
            // 
            this.ordenarPorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SortID,
            this.SortNombre,
            this.SortCantidad,
            this.SortPrecio,
            this.SortTipo});
            this.ordenarPorToolStripMenuItem.Name = "ordenarPorToolStripMenuItem";
            this.ordenarPorToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.ordenarPorToolStripMenuItem.Text = "Ordenar por";
            // 
            // SortID
            // 
            this.SortID.Name = "SortID";
            this.SortID.Size = new System.Drawing.Size(152, 26);
            this.SortID.Text = "Id";
            this.SortID.Click += new System.EventHandler(this.SortId);
            // 
            // SortNombre
            // 
            this.SortNombre.Name = "SortNombre";
            this.SortNombre.Size = new System.Drawing.Size(152, 26);
            this.SortNombre.Text = "Nombre";
            this.SortNombre.Click += new System.EventHandler(this.SortName);
            // 
            // SortCantidad
            // 
            this.SortCantidad.Name = "SortCantidad";
            this.SortCantidad.Size = new System.Drawing.Size(152, 26);
            this.SortCantidad.Text = "Cantidad";
            this.SortCantidad.Click += new System.EventHandler(this.SortQuantity);
            // 
            // SortPrecio
            // 
            this.SortPrecio.Name = "SortPrecio";
            this.SortPrecio.Size = new System.Drawing.Size(152, 26);
            this.SortPrecio.Text = "Precio";
            this.SortPrecio.Click += new System.EventHandler(this.SortPrice);
            // 
            // SortTipo
            // 
            this.SortTipo.Name = "SortTipo";
            this.SortTipo.Size = new System.Drawing.Size(152, 26);
            this.SortTipo.Text = "Tipo";
            this.SortTipo.Click += new System.EventHandler(this.SortType);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // DataTable
            // 
            this.DataTable.AllowUserToAddRows = false;
            this.DataTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nombre,
            this.Cantidad,
            this.Precio,
            this.Descripción,
            this.Tipo});
            this.DataTable.Location = new System.Drawing.Point(12, 39);
            this.DataTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DataTable.Name = "DataTable";
            this.DataTable.ReadOnly = true;
            this.DataTable.RowHeadersWidth = 51;
            this.DataTable.RowTemplate.Height = 24;
            this.DataTable.RowTemplate.ReadOnly = true;
            this.DataTable.Size = new System.Drawing.Size(1037, 390);
            this.DataTable.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Descripción
            // 
            this.Descripción.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripción.HeaderText = "Descripción";
            this.Descripción.MinimumWidth = 6;
            this.Descripción.Name = "Descripción";
            this.Descripción.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.MinimumWidth = 6;
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // Eliminar
            // 
            this.Eliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Eliminar.Location = new System.Drawing.Point(12, 452);
            this.Eliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(100, 25);
            this.Eliminar.TabIndex = 2;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseVisualStyleBackColor = true;
            this.Eliminar.Click += new System.EventHandler(this.Delete);
            // 
            // Nuevo
            // 
            this.Nuevo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Nuevo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Nuevo.FlatAppearance.BorderSize = 0;
            this.Nuevo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Nuevo.Location = new System.Drawing.Point(489, 452);
            this.Nuevo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Nuevo.Name = "Nuevo";
            this.Nuevo.Size = new System.Drawing.Size(100, 25);
            this.Nuevo.TabIndex = 3;
            this.Nuevo.Text = "Nuevo";
            this.Nuevo.UseVisualStyleBackColor = false;
            this.Nuevo.Click += new System.EventHandler(this.Create);
            // 
            // Editar
            // 
            this.Editar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Editar.Location = new System.Drawing.Point(949, 452);
            this.Editar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Editar.Name = "Editar";
            this.Editar.Size = new System.Drawing.Size(100, 25);
            this.Editar.TabIndex = 4;
            this.Editar.Text = "Editar";
            this.Editar.UseVisualStyleBackColor = true;
            this.Editar.Click += new System.EventHandler(this.Edit);
            // 
            // ComboFilter
            // 
            this.ComboFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboFilter.FormattingEnabled = true;
            this.ComboFilter.Items.AddRange(new object[] {
            "ALL",
            "MONITOR",
            "TECLADO",
            "RATON",
            "PLACA_BASE"});
            this.ComboFilter.Location = new System.Drawing.Point(808, 1);
            this.ComboFilter.Margin = new System.Windows.Forms.Padding(4);
            this.ComboFilter.Name = "ComboFilter";
            this.ComboFilter.Size = new System.Drawing.Size(239, 24);
            this.ComboFilter.TabIndex = 7;
            this.ComboFilter.SelectedIndexChanged += new System.EventHandler(this.Filter);
            // 
            // FilterLabel
            // 
            this.FilterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FilterLabel.AutoSize = true;
            this.FilterLabel.Location = new System.Drawing.Point(713, 6);
            this.FilterLabel.Name = "FilterLabel";
            this.FilterLabel.Size = new System.Drawing.Size(88, 16);
            this.FilterLabel.TabIndex = 8;
            this.FilterLabel.Text = "Filtrar por tipo";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 503);
            this.Controls.Add(this.FilterLabel);
            this.Controls.Add(this.ComboFilter);
            this.Controls.Add(this.Editar);
            this.Controls.Add(this.Nuevo);
            this.Controls.Add(this.Eliminar);
            this.Controls.Add(this.DataTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1078, 47);
            this.Name = "MainView";
            this.Text = "Gestión de Productos";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.DataGridView DataTable;
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.Button Nuevo;
        private System.Windows.Forms.Button Editar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripción;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.ToolStripMenuItem ImportCSV;
        private System.Windows.Forms.ToolStripMenuItem ExportCSV;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuNuevo;
        private System.Windows.Forms.ToolStripMenuItem MenuEditar;
        private System.Windows.Forms.ToolStripMenuItem MenuEliminar;
        private System.Windows.Forms.ToolStripMenuItem ordenarPorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SortID;
        private System.Windows.Forms.ToolStripMenuItem SortNombre;
        private System.Windows.Forms.ToolStripMenuItem SortCantidad;
        private System.Windows.Forms.ToolStripMenuItem SortPrecio;
        private System.Windows.Forms.ToolStripMenuItem SortTipo;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ComboBox ComboFilter;
        private System.Windows.Forms.Label FilterLabel;
    }
}

