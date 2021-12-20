using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionDeProductos
{
    public partial class NewProduct : Form
    {
        private MainView padre;
        public NewProduct()
        {
            padre = null;
            InitializeComponent();
            TipoBOX.Items.Add(Product.Type.MONITOR.ToString());
            TipoBOX.Items.Add(Product.Type.TECLADO.ToString());
            TipoBOX.Items.Add(Product.Type.RATON.ToString());
            TipoBOX.Items.Add(Product.Type.PLACA_BASE.ToString());
        }

        public NewProduct(MainView padre)
        {
            this.padre = padre;
            InitializeComponent();
            TipoBOX.Items.Add(Product.Type.MONITOR.ToString());
            TipoBOX.Items.Add(Product.Type.TECLADO.ToString());
            TipoBOX.Items.Add(Product.Type.RATON.ToString());
            TipoBOX.Items.Add(Product.Type.PLACA_BASE.ToString());
        }

        private void GuardarBT_Click(object sender, EventArgs e)
        {
            Product product = new Product();

            product.Id = IDBOX.Text;
            product.Name = NombreBOX.Text;
            product.Price = PrecioBOX.Text;
            product.Quantity = CantidadBOX.Text;
            product.Description = DescripBOX.Text;
            Product.Type tipo = (Product.Type)TipoBOX.SelectedIndex;
            product.TypeProduct = tipo;
            ProductController.save(product);
            this.padre.reloadTable();
            this.Dispose();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
