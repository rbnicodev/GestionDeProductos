using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace GestionDeProductos
{
    partial class MainView
    {
        public void SampleData() //Function to load sample data
        {
            //It first asks the user if he wants to import the sample data
            if (MessageBox.Show("¿Desea importar datos de ejemplo?", "Importar Datos Ejemplo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(ProductController.ImportCSV("sample_data.csv") == true)
                {
                    ReloadTable();
                    MessageBox.Show("Importados con éxito", "Importar Datos Ejemplo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Parece que ha habido un error", "Error al importar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }
        public void ReloadTable() //Reload the table view
        {
            DataTable.Rows.Clear();
            ProductController.First();  //Sets the ProductController index to 0
            for (int i = 0; i < ProductController.Count; i++)
            {
                DataTable.Rows.Add(ProductController.LoadString(ProductController.Next().Id));
            }
        }
        private void Filter(object sender, EventArgs e)
        {
            int type = ComboFilter.SelectedIndex;
            type--; //This is because by adding the "Alls" option, the indexes have been increased by one.
            if (type >= 0) //If type has been chosen
            {
                DataTable.Rows.Clear();
                foreach (Product p in ProductController.getProducts())
                {
                    if ((int)p.TypeProduct == type) //It only adds it to the view if the type matches
                    {
                        DataTable.Rows.Add(ProductController.LoadString(p.Id));
                    }
                }
            }
            else //If "Alls" has been chosen
            {
                ReloadTable();
            }
        }
        public void Create(object sender, EventArgs e) //Function used in the ClickListener of the "new" button
        {
            NewProduct newProduct = new NewProduct();
            newProduct.ShowDialog();
            if (newProduct.DialogResult == DialogResult.OK)
            {
                ReloadTable();
            }
        }
        public void Edit(object sender, EventArgs e)//Function used in the ClickListener of the "edit" button
        {
            if (DataTable.SelectedRows.Count > 0 && DataTable.SelectedRows[0].Cells.Count > 0) //If the number of selected rows is greater than 0, and the number of selected cells in the first row is also greater than 0
            {
                if (DataTable.SelectedRows[0].Cells[0].Value != null) //If the first cell of the first selected row has a value other than null
                {
                    if (new NewProduct(ProductController.Load(DataTable.SelectedRows[0].Cells[0].Value.ToString())).ShowDialog() == DialogResult.OK)
                    {
                        ReloadTable();
                    }
                }
            }
            else
            {
                string message = "Selecciona una fila";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
            }
        }
        public void Delete(object sender, EventArgs e)//Function used in the ClickListener of the "delete" button
        {
            string message = null;
            if (DataTable.SelectedRows.Count > 0 && DataTable.SelectedRows[0].Cells.Count > 0) //If the number of selected rows is greater than 0, and the number of selected cells in the first row is also greater than 0
            {
                if (DataTable.SelectedRows[0].Cells[0].Value != null) //If the first cell of the first selected row has a value other than null
                {
                    if (DataTable.SelectedRows.Count == 1) //Confirmation for one selected row
                    {
                        message = "¿Está seguro de que desea eliminar el registro?";
                    }
                    else //Confirmation for more than one selected row
                    {
                        message = "¿Está seguro de que desea eliminar los registros?";
                    }
                    string caption = "Eliminar";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes) //If the user confirms the deletion
                    {
                        foreach (DataGridViewRow row in DataTable.SelectedRows)
                        {
                            if (row.Cells[0].Value != null)
                            {
                                ProductController.Delete(row.Cells[0].Value.ToString());
                            }
                        }
                    }
                    ReloadTable();
                }
            }
        }
        private void ImportFromCSV(object sender, EventArgs e) //Function that opens the dialog to select file, and calls ProductController to import it
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "csv files (*.csv)|*.csv";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                string message = "¿Está seguro de querer importar?\nSe perderán los datos actuales";
                string caption = "Importar";

                if (MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (ProductController.ImportCSV(openFileDialog.FileName)) //If the file is imported successfully
                    {

                        buttons = MessageBoxButtons.OK;
                        message = "Importado con éxito";
                        caption = "Importar";
                        MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);
                        ReloadTable();
                    }
                    else //If there is any error importing the file
                    {

                        buttons = MessageBoxButtons.OK;
                        message = "Ha habido un error al importar";
                        caption = "Importar";
                        MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                    }
                }

                ReloadTable();
            }
        }

        private void ExportToCSV(object sender, EventArgs e) //Function that opens the dialog to select the destination of the file, and calls ProductController to export it
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "csv files (*.csv)|*.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (ProductController.SaveCSV(saveFileDialog.FileName)) //If the file is exported successfully
                {
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    string message = "Exportado con éxito";
                    string caption = "Exportar";
                    MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);
                }
                else //If there is any error exporting the file
                {
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    string message = "Ha habido un error al guardar";
                    string caption = "Exportar";
                    MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                }
            }
        }
        private void SortId(object sender, EventArgs e)
        {
            DataTable.Sort(DataTable.Columns["ID"], ListSortDirection.Ascending);
        }
        private void SortName(object sender, EventArgs e)
        {
            DataTable.Sort(DataTable.Columns["Name"], ListSortDirection.Ascending);
        }
        private void SortQuantity(object sender, EventArgs e)
        {
            DataTable.Sort(DataTable.Columns["Cantidad"], ListSortDirection.Ascending);
        }
        private void SortPrice(object sender, EventArgs e)
        {
            DataTable.Sort(DataTable.Columns["Precio"], ListSortDirection.Ascending);
        }
        private void SortType(object sender, EventArgs e)
        {
            DataTable.Sort(DataTable.Columns["Tipo"], ListSortDirection.Ascending);
        }
    }
}
