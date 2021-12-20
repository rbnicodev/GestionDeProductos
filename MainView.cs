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
    public partial class MainView : Form
    {
        public MainView()
        {
            Product product = new Product();
            product.Name = "Hola";
            product.Quantity = "234";
            product.Description = "lkjadsfljkñadsfljkñ";
            product.Id = "234";
            product.Price = "2342€";
            product.TypeProduct = Product.Type.PLACA_BASE;

            ProductController.save(product);
            InitializeComponent();
            
        }

        public void reloadTable()
        {
            TablaDatos.Rows.Clear();
            for (int i = 0; i < ProductController.Count; i++)
            {
                TablaDatos.Rows.Add(ProductController.loadString(ProductController.next().Id));
            }
        }

        private void Click(object sender, EventArgs e)
        {
            if (sender == Nuevo)
            {
                NewProduct ventana = new NewProduct();
                ventana.ShowDialog();

            }else if (sender == Editar)
            {

            }else if (sender == Eliminar)
            {

            }
        }
    }
}
