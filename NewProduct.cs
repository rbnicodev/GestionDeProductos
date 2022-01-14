using System;
using System.Windows.Forms;

namespace GestionDeProductos
{
    public partial class NewProduct : Form
    {
        private Product producto;
        
        public TextBox getIDBox(){ return IDBOX; }
        public TextBox getNameBox(){ return NombreBOX; }
        public TextBox getQuantityBox(){ return CantidadBOX; }
        public TextBox getPriceBox(){ return PrecioBOX; }
        public TextBox getDescriptionBox() {  return DescripBOX; }
        public ComboBox getTypeBox() { return TipoBOX; }
        public Product getProduct() { return producto; }
        public Button getSaveButton() { return GuardarBT; }
        public NewProduct()
        {
            this.producto = null;
            InitializeComponent();
            InitzializeTypeBox();
        }

        public NewProduct(Product producto)
        {
            this.producto = producto;
            InitializeComponent();
            InitzializeTypeBox();
            ProductToTextBoxes(producto);
        }
        private void Save(object sender, EventArgs e){ NewProductController.Save(); }
        private void Cancel(object sender, EventArgs e){ this.DialogResult = DialogResult.Cancel; }
        private void Validate(object sender, EventArgs e){ NewProductController.ValidateSave(); }

        private void ProductToTextBoxes(Product producto)
        {
            IDBOX.Text = producto.Id;
            NombreBOX.Text = producto.Name;
            CantidadBOX.Text = producto.Quantity;
            PrecioBOX.Text = producto.Price;
            DescripBOX.Text = producto.Description;
            TipoBOX.SelectedIndex = (int)producto.TypeProduct;
        }
        private void InitzializeTypeBox()
        {
            TipoBOX.Items.Add(Product.Type.MONITOR.ToString());
            TipoBOX.Items.Add(Product.Type.TECLADO.ToString());
            TipoBOX.Items.Add(Product.Type.RATON.ToString());
            TipoBOX.Items.Add(Product.Type.PLACA_BASE.ToString());
        }

        private void InitzializeBoxes()
        {
            IDBOX.
        }

    }
}
