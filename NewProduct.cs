using System;
using System.Windows.Forms;

namespace GestionDeProductos
{
    public partial class NewProduct : Form
    {
        private Product producto;

        public NewProduct() //Default constructor
        {
            this.producto = null;
            InitializeComponent();
            InitzializeBoxes();
            InitzializeTypeBox();
        }

        public NewProduct(Product producto) //Constructor for the edit function
        {
            this.producto = producto;
            InitializeComponent();
            InitzializeTypeBox();
            ProductToTextBoxes(producto);
        }
    }
}
