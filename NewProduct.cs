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
        public NewProduct()
        {
            InitializeComponent();
            TipoBOX.Items.Add(Product.Type.MONITOR.ToString());
            TipoBOX.Items.Add(Product.Type.TECLADO.ToString());
            TipoBOX.Items.Add(Product.Type.RATON.ToString());
            TipoBOX.Items.Add(Product.Type.PLACA_BASE.ToString());
        }
    }
}
