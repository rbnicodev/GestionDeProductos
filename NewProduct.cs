using System;
using System.Windows.Forms;

namespace GestionDeProductos
{
    public partial class NewProduct : Form
    {
        private Product producto;
        
        private TextBox getIDBox(){ return IDBOX; }
        private TextBox getNameBox(){ return NombreBOX; }
        private TextBox getQuantityBox(){ return CantidadBOX; }
        private TextBox getPriceBox(){ return PrecioBOX; }
        private TextBox getDescriptionBox() {  return DescripBOX; }
        private ComboBox getTypeBox() { return TipoBOX; }
        public NewProduct()
        {
            InitializeComponent();
            TipoBOX.Items.Add(Product.Type.MONITOR.ToString());
            TipoBOX.Items.Add(Product.Type.TECLADO.ToString());
            TipoBOX.Items.Add(Product.Type.RATON.ToString());
            TipoBOX.Items.Add(Product.Type.PLACA_BASE.ToString());
        }

        public NewProduct(Product producto)
        {
            this.producto = producto;
            InitializeComponent();
            TipoBOX.Items.Add(Product.Type.MONITOR.ToString());
            TipoBOX.Items.Add(Product.Type.TECLADO.ToString());
            TipoBOX.Items.Add(Product.Type.RATON.ToString());
            TipoBOX.Items.Add(Product.Type.PLACA_BASE.ToString());


            IDBOX.Text = producto.Id;
            NombreBOX.Text = producto.Name;
            CantidadBOX.Text = producto.Quantity;
            PrecioBOX.Text = producto.Price;
            DescripBOX.Text = producto.Description;
            TipoBOX.SelectedIndex = (int)producto.TypeProduct;
        }
        private void ClickListener(object sender, EventArgs e)
        {

                if (sender == GuardarBT)
                {
                    if(validateUserEntry())
                    {
                        Product product = new Product();

                        product.Id = IDBOX.Text;
                        product.Name = NombreBOX.Text.Replace(";", "");
                        product.Price = PrecioBOX.Text;
                        product.Quantity = CantidadBOX.Text;
                        product.Description = DescripBOX.Text.Replace(";", "");
                        Product.Type tipo = (Product.Type)TipoBOX.SelectedIndex;
                        product.TypeProduct = tipo;
                        if (producto == null)
                        {
                            ProductController.Save(product);
                        }
                        else
                        {
                            ProductController.Update(product);
                        }

                    this.DialogResult = DialogResult.OK;

                }

            }
                else if (sender == CancelarBT)
                {
                    this.DialogResult = DialogResult.Cancel;
                }
        }
        private bool validateUserEntry()
        {
            int i;
            double d;
            bool rtrn = true;
            // Checks the value of the text.
            if (!int.TryParse(IDBOX.Text, out i) || IDBOX.Text == "")
            {
                string message = "Introduce un valor numérico";
                string caption = "ID erróneo";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                rtrn = false;
            }
            else if (NombreBOX.Text == "")
            {
                string message = "Introduce un nombre de producto";
                string caption = "Nombre no indicado";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                rtrn = false;
            } else if (NombreBOX.Text.Contains(";"))
            {
                string message = "No se puede introducir ';'";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                rtrn = false;
            }
            else if (!int.TryParse(CantidadBOX.Text, out i) || CantidadBOX.Text == "")
            {
                string message = "Introduce un valor numérico";
                string caption = "Cantidad no indicada";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                rtrn = false;
            }
            else if (!double.TryParse(PrecioBOX.Text, out d) || PrecioBOX.Text == "")
            {
                string message = "Introduce un valor válido";
                string caption = "Precio erróneo";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                rtrn = false;
            }
            else if (DescripBOX.Text.Contains(";"))
            {
                string message = "No se puede introducir ';'";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                rtrn = false;
            }
            else if (TipoBOX.SelectedIndex == -1)
            {
                string message = "Introduce un tipo de producto";
                string caption = "Error detectado";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                rtrn = false;
            }

            return rtrn;
        }
    }
}
