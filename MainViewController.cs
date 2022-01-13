using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GestionDeProductos
{
    internal class MainViewController
    {

        public static void ReloadTable(DataGridView DataTable)
        {
            DataTable.Rows.Clear();
            ProductController.First();  //Sets the ProductController index to 0
            for (int i = 0; i < ProductController.Count; i++)
            {
                DataTable.Rows.Add(ProductController.LoadString(ProductController.Next().Id));
            }
        }
        public static void ReloadTableFiltered(DataGridView DataTable, int type)
        {
            type--;
            if(type >= 0)
            {
                DataTable.Rows.Clear();
                foreach (Product p in ProductController.getProducts())
                {
                    if ((int)p.TypeProduct == type)
                    {
                        DataTable.Rows.Add(ProductController.LoadString(p.Id));
                    }
                }
            } else
            {
                ReloadTable(DataTable);
            }
        }
        public static void Create(DataGridView DataTable)
        {
            NewProduct ventana = new NewProduct();
            ventana.ShowDialog();
            if (ventana.DialogResult == DialogResult.OK)
            {
                ReloadTable(DataTable);
            }
        }
        public static void Edit(DataGridView DataTable)
        {
            if (DataTable.SelectedRows.Count > 0 && DataTable.SelectedRows[0].Cells.Count > 0) //If the number of selected rows is greater than 0, and the number of selected cells in the first row is also greater than 0
            {
                if (DataTable.SelectedRows[0].Cells[0].Value != null) //If the first cell of the first selected row has a value other than null
                {
                    NewProduct ventana = new NewProduct(ProductController.Load(DataTable.SelectedRows[0].Cells[0].Value.ToString()));
                    ventana.ShowDialog();
                    if (ventana.DialogResult == DialogResult.OK)
                    {
                        ReloadTable(DataTable);
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
        public static void Delete(DataGridView DataTable)
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
                    ReloadTable(DataTable);
                }
            }
        }
        public static void ImportCSV(DataGridView DataTable)
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
                        ReloadTable(DataTable);
                    }
                    else //If there is any error importing the file
                    {

                        buttons = MessageBoxButtons.OK;
                        message = "Ha habido un error al importar";
                        caption = "Importar";
                        MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                    }
                }

                MainViewController.ReloadTable(DataTable);
            }
        }

        public static void ExportCSV()
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
    }
}
