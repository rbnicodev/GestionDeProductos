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
                NewProduct ventana = new NewProduct(this);
                ventana.ShowDialog();

            }else if (sender == Editar)
            {

            }else if (sender == Eliminar)
            {

            }
        }
    }
}
