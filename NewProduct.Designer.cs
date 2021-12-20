namespace GestionDeProductos
{
    partial class NewProduct
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
            this.components = new System.ComponentModel.Container();
            this.IDBox = new System.Windows.Forms.TextBox();
            this.NombreBOX = new System.Windows.Forms.TextBox();
            this.CantidadBOX = new System.Windows.Forms.TextBox();
            this.PrecioBOX = new System.Windows.Forms.TextBox();
            this.DescripBOX = new System.Windows.Forms.TextBox();
            this.GuardarBT = new System.Windows.Forms.Button();
            this.IDLabel = new System.Windows.Forms.Label();
            this.NombreLabel = new System.Windows.Forms.Label();
            this.CantidadLabel = new System.Windows.Forms.Label();
            this.PrecioLabel = new System.Windows.Forms.Label();
            this.DescripLabel = new System.Windows.Forms.Label();
            this.TipoLable = new System.Windows.Forms.Label();
            this.typeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.typeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.typeBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.TipoBOX = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.typeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // IDBox
            // 
            this.IDBox.Location = new System.Drawing.Point(12, 91);
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(380, 22);
            this.IDBox.TabIndex = 0;
            // 
            // NombreBOX
            // 
            this.NombreBOX.Location = new System.Drawing.Point(12, 184);
            this.NombreBOX.Name = "NombreBOX";
            this.NombreBOX.Size = new System.Drawing.Size(380, 22);
            this.NombreBOX.TabIndex = 1;
            // 
            // CantidadBOX
            // 
            this.CantidadBOX.Location = new System.Drawing.Point(12, 285);
            this.CantidadBOX.Name = "CantidadBOX";
            this.CantidadBOX.Size = new System.Drawing.Size(380, 22);
            this.CantidadBOX.TabIndex = 2;
            // 
            // PrecioBOX
            // 
            this.PrecioBOX.Location = new System.Drawing.Point(12, 389);
            this.PrecioBOX.Name = "PrecioBOX";
            this.PrecioBOX.Size = new System.Drawing.Size(380, 22);
            this.PrecioBOX.TabIndex = 3;
            // 
            // DescripBOX
            // 
            this.DescripBOX.Location = new System.Drawing.Point(12, 491);
            this.DescripBOX.Name = "DescripBOX";
            this.DescripBOX.Size = new System.Drawing.Size(380, 22);
            this.DescripBOX.TabIndex = 4;
            // 
            // GuardarBT
            // 
            this.GuardarBT.Location = new System.Drawing.Point(164, 660);
            this.GuardarBT.Name = "GuardarBT";
            this.GuardarBT.Size = new System.Drawing.Size(75, 23);
            this.GuardarBT.TabIndex = 6;
            this.GuardarBT.Text = "Guardar";
            this.GuardarBT.UseVisualStyleBackColor = true;
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(9, 53);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(20, 16);
            this.IDLabel.TabIndex = 7;
            this.IDLabel.Text = "ID";
            // 
            // NombreLabel
            // 
            this.NombreLabel.AutoSize = true;
            this.NombreLabel.Location = new System.Drawing.Point(9, 150);
            this.NombreLabel.Name = "NombreLabel";
            this.NombreLabel.Size = new System.Drawing.Size(56, 16);
            this.NombreLabel.TabIndex = 8;
            this.NombreLabel.Text = "Nombre";
            // 
            // CantidadLabel
            // 
            this.CantidadLabel.AutoSize = true;
            this.CantidadLabel.Location = new System.Drawing.Point(9, 245);
            this.CantidadLabel.Name = "CantidadLabel";
            this.CantidadLabel.Size = new System.Drawing.Size(61, 16);
            this.CantidadLabel.TabIndex = 9;
            this.CantidadLabel.Text = "Cantidad";
            // 
            // PrecioLabel
            // 
            this.PrecioLabel.AutoSize = true;
            this.PrecioLabel.Location = new System.Drawing.Point(12, 353);
            this.PrecioLabel.Name = "PrecioLabel";
            this.PrecioLabel.Size = new System.Drawing.Size(46, 16);
            this.PrecioLabel.TabIndex = 10;
            this.PrecioLabel.Text = "Precio";
            // 
            // DescripLabel
            // 
            this.DescripLabel.AutoSize = true;
            this.DescripLabel.Location = new System.Drawing.Point(12, 453);
            this.DescripLabel.Name = "DescripLabel";
            this.DescripLabel.Size = new System.Drawing.Size(79, 16);
            this.DescripLabel.TabIndex = 11;
            this.DescripLabel.Text = "Descripción";
            // 
            // TipoLable
            // 
            this.TipoLable.AutoSize = true;
            this.TipoLable.Location = new System.Drawing.Point(12, 545);
            this.TipoLable.Name = "TipoLable";
            this.TipoLable.Size = new System.Drawing.Size(35, 16);
            this.TipoLable.TabIndex = 12;
            this.TipoLable.Text = "Tipo";
            // 
            // typeBindingSource
            // 
            this.typeBindingSource.DataSource = typeof(GestionDeProductos.Product.Type);
            // 
            // typeBindingSource1
            // 
            this.typeBindingSource1.DataSource = typeof(GestionDeProductos.Product.Type);
            // 
            // typeBindingSource2
            // 
            this.typeBindingSource2.DataSource = typeof(GestionDeProductos.Product.Type);
            // 
            // TipoBOX
            // 
            this.TipoBOX.FormattingEnabled = true;
            this.TipoBOX.Location = new System.Drawing.Point(15, 578);
            this.TipoBOX.Name = "TipoBOX";
            this.TipoBOX.Size = new System.Drawing.Size(377, 24);
            this.TipoBOX.TabIndex = 13;
            // 
            // NewProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 705);
            this.Controls.Add(this.TipoBOX);
            this.Controls.Add(this.TipoLable);
            this.Controls.Add(this.DescripLabel);
            this.Controls.Add(this.PrecioLabel);
            this.Controls.Add(this.CantidadLabel);
            this.Controls.Add(this.NombreLabel);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.GuardarBT);
            this.Controls.Add(this.DescripBOX);
            this.Controls.Add(this.PrecioBOX);
            this.Controls.Add(this.CantidadBOX);
            this.Controls.Add(this.NombreBOX);
            this.Controls.Add(this.IDBox);
            this.Name = "NewProduct";
            this.Text = "Producto";
            ((System.ComponentModel.ISupportInitialize)(this.typeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IDBox;
        private System.Windows.Forms.TextBox NombreBOX;
        private System.Windows.Forms.TextBox CantidadBOX;
        private System.Windows.Forms.TextBox PrecioBOX;
        private System.Windows.Forms.TextBox DescripBOX;
        private System.Windows.Forms.Button GuardarBT;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Label NombreLabel;
        private System.Windows.Forms.Label CantidadLabel;
        private System.Windows.Forms.Label PrecioLabel;
        private System.Windows.Forms.Label DescripLabel;
        private System.Windows.Forms.Label TipoLable;
        private System.Windows.Forms.BindingSource typeBindingSource;
        private System.Windows.Forms.BindingSource typeBindingSource1;
        private System.Windows.Forms.BindingSource typeBindingSource2;
        private System.Windows.Forms.ComboBox TipoBOX;
    }
}