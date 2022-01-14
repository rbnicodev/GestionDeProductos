using System.Windows.Forms;


namespace GestionDeProductos
{
    internal class NewProductController
    {
        static NewProduct newProduct { get; set; }

        public static NewProduct GetNewProductView()
        {
            newProduct = new NewProduct();
            newProduct.ShowDialog();

            return newProduct;
        }

        public static NewProduct GetNewProductView(Product producto)
        {
            newProduct = new NewProduct(producto);
            newProduct.ShowDialog();

            return newProduct;
        }
        public static bool ValidateUserEntry()
        {
            int i;
            double d;
            bool rtrn = true;
            // Checks the value of the text.
            if (!int.TryParse(newProduct.getIDBox().Text, out i) || newProduct.getIDBox().Text == "")
            {
                //string message = "Introduce un valor numérico";
                //string caption = "ID erróneo";
                //MessageBoxButtons buttons = MessageBoxButtons.OK;
                //MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                rtrn = false;
            }
            else if (newProduct.getNameBox().Text == "")
            {
                //string message = "Introduce un nombre de producto";
                //string caption = "Nombre no indicado";
                //MessageBoxButtons buttons = MessageBoxButtons.OK;
                //MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                rtrn = false;
            }
            else if (newProduct.getNameBox().Text.Contains(";"))
            {
                //string message = "No se puede introducir ';'";
                //string caption = "Error";
                //MessageBoxButtons buttons = MessageBoxButtons.OK;
                //MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                rtrn = false;
            }
            else if (!int.TryParse(newProduct.getQuantityBox().Text, out i) || newProduct.getQuantityBox().Text == "")
            {
                //string message = "Introduce un valor numérico";
                //string caption = "Cantidad no indicada";
                //MessageBoxButtons buttons = MessageBoxButtons.OK;
                //MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                rtrn = false;
            }
            else if (!double.TryParse(newProduct.getPriceBox().Text, out d) || newProduct.getPriceBox().Text == "")
            {
                //string message = "Introduce un valor válido";
                //string caption = "Precio erróneo";
                //MessageBoxButtons buttons = MessageBoxButtons.OK;
                //MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                rtrn = false;
            }
            else if (newProduct.getDescriptionBox().Text.Contains(";"))
            {
                //string message = "No se puede introducir ';'";
                //string caption = "Error";
                //MessageBoxButtons buttons = MessageBoxButtons.OK;
                //MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                rtrn = false;
            }
            else if (newProduct.getTypeBox().SelectedIndex == -1)
            {
                //string message = "Introduce un tipo de producto";
                //string caption = "Error detectado";
                //MessageBoxButtons buttons = MessageBoxButtons.OK;
                //MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                rtrn = false;
            }

            return rtrn;
        }
        public static void ValidateSave()
        {
            if(!ValidateUserEntry())
            {
                newProduct.getSaveButton().Enabled = false;
            }
            else
            {
                newProduct.getSaveButton().Enabled = true;
            }
        }

        public static void Save()
        {
            if (ValidateUserEntry())
            {
                Product product = new Product();

                product.Id = newProduct.getIDBox().Text;
                product.Name = newProduct.getNameBox().Text.Replace(";", "");
                product.Price = newProduct.getPriceBox().Text;
                product.Quantity = newProduct.getQuantityBox().Text;
                product.Description = newProduct.getDescriptionBox().Text.Replace(";", "");
                Product.Type tipo = (Product.Type)newProduct.getTypeBox().SelectedIndex;
                product.TypeProduct = tipo;
                if (newProduct.getProduct() == null)
                {
                    ProductController.Save(product);
                }
                else
                {
                    ProductController.Update(product);
                }

                newProduct.DialogResult = DialogResult.OK;
            }
        }
    }
}
