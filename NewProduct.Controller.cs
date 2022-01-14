using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GestionDeProductos
{
    partial class NewProduct
    { 
        public bool ValidateUserEntry() //Check that the fields are correct
        {
            int i;
            double d;
            bool rtrn = true;
            // Checks the value of the text.
            if (!int.TryParse(IDBOX.Text, out i) || IDBOX.Text == "") { rtrn = false; }
            else if (NombreBOX.Text == "") { rtrn = false; }
            else if (NombreBOX.Text.Contains(";")) { rtrn = false; }
            else if (!int.TryParse(CantidadBOX.Text, out i) || CantidadBOX.Text == "") { rtrn = false; }
            else if (!double.TryParse(PrecioBOX.Text, out d) || PrecioBOX.Text == "") { rtrn = false; }
            else if (DescripBOX.Text.Contains(";")) { rtrn = false; }
            else if (TipoBOX.SelectedIndex == -1) { rtrn = false; }

            return rtrn;
        }
        public void Validate(object sender, EventArgs e) //If the fields are correct, activate the save button
        {
            if (!ValidateUserEntry()) { GuardarBT.Enabled = false; }
            else { GuardarBT.Enabled = true; }
        }

        private void ProductToTextBoxes(Product producto) //Assign the attributes of the product you want to edit to the text boxes
        {
            IDBOX.Text = producto.Id;
            NombreBOX.Text = producto.Name;
            CantidadBOX.Text = producto.Quantity;
            PrecioBOX.Text = producto.Price;
            DescripBOX.Text = producto.Description;
            TipoBOX.SelectedIndex = (int)producto.TypeProduct;
        }

        private void InitzializeBoxes() //Assign guide text to text boxes
        {
            intBox_Load(IDBOX, null);
            intBox_Load(CantidadBOX, null);
            doubleBox_Load(PrecioBOX, null);
            textBox_Load(DescripBOX, null);
            textBox_Load(NombreBOX, null);
        }

        private void InitzializeTypeBox()
        {
            TipoBOX.Items.Add(Product.Type.MONITOR.ToString());
            TipoBOX.Items.Add(Product.Type.TECLADO.ToString());
            TipoBOX.Items.Add(Product.Type.RATON.ToString());
            TipoBOX.Items.Add(Product.Type.PLACA_BASE.ToString());
        }

        private void Save(object sender, EventArgs e)//Save Button ClickListener
        {
            if (ValidateUserEntry())
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
                else { ProductController.Update(product); }

                this.DialogResult = DialogResult.OK;
            }
        }
        private void Cancel(object sender, EventArgs e) { this.DialogResult = DialogResult.Cancel; } //Cancel Button ClickListener

        //
        //
        //
        // Modifiers for managing guide text in text boxes -->
        //
        //
        //


        private void intBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Introduce un número entero")
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        private void intBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
            {
                textBox.Text = "Introduce un número entero";
                textBox.ForeColor = Color.Gray;
            }
        }

        private void intBox_Load(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = "Introduce un número entero";
            textBox.ForeColor = Color.Gray;
        }

        private void doubleBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Introduce un valor numérico")
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        private void doubleBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
            {
                textBox.Text = "Introduce un valor numérico";
                textBox.ForeColor = Color.Gray;
            }
        }

        private void doubleBox_Load(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = "Introduce un valor numérico";
            textBox.ForeColor = Color.Gray;
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Introduce texto sin signos")
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
            {
                textBox.Text = "Introduce texto sin signos";
                textBox.ForeColor = Color.Gray;
            }
        }

        private void textBox_Load(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = "Introduce texto sin signos";
            textBox.ForeColor = Color.Gray;
        }
    }
}
