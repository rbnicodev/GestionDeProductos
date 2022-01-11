using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GestionDeProductos
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();          
        }

        public void ReloadTable()
        {
            TablaDatos.Rows.Clear();
            ProductController.First();  //Sets the ProductController index to 0
            for (int i = 0; i < ProductController.Count; i++)
            {
                TablaDatos.Rows.Add(ProductController.LoadString(ProductController.Next().Id));
            }
        }

        private void CRUD(object sender, EventArgs e) //Listener for buttons related to product management
        {
            if (sender == Nuevo || sender == MenuNuevo)
            {
                NewProduct ventana = new NewProduct(this);
                ventana.ShowDialog();
                if(ventana.DialogResult == DialogResult.OK)
                {
                    ReloadTable();
                } 

            }else if (sender == Editar || sender == MenuEditar)
            {
                if(TablaDatos.SelectedRows.Count > 0 && TablaDatos.SelectedRows[0].Cells.Count > 0) //If the number of selected rows is greater than 0, and the number of selected cells in the first row is also greater than 0
                {
                    if (TablaDatos.SelectedRows[0].Cells[0].Value != null) //If the first cell of the first selected row has a value other than null
                    {
                        NewProduct ventana = new NewProduct(this, ProductController.Load(TablaDatos.SelectedRows[0].Cells[0].Value.ToString()));
                        ventana.ShowDialog();
                        if (ventana.DialogResult == DialogResult.OK)
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
                
            }else if ((sender == Eliminar || sender == MenuEliminar))
            {
                string message = null;
                if(TablaDatos.SelectedRows.Count > 0 && TablaDatos.SelectedRows[0].Cells.Count > 0) //If the number of selected rows is greater than 0, and the number of selected cells in the first row is also greater than 0
                {
                    if (TablaDatos.SelectedRows[0].Cells[0].Value != null) //If the first cell of the first selected row has a value other than null
                    {
                        if(TablaDatos.SelectedRows.Count == 1) //Confirmation for one selected row
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
                            foreach (DataGridViewRow row in TablaDatos.SelectedRows)
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
                else //If the user has not selected any row
                {
                    message = "Selecciona una fila";
                    string caption = "Error";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                }

            }
        }

        private void Sort(object sender, EventArgs e) //Listener for sort buttons
        {
            if(sender == SortID)
            {
                TablaDatos.Sort(TablaDatos.Columns["ID"], ListSortDirection.Ascending);
            } else if(sender == SortNombre)
            {
                TablaDatos.Sort(TablaDatos.Columns["Nombre"], ListSortDirection.Ascending);
            } else if (sender == SortCantidad)
            {
                TablaDatos.Sort(TablaDatos.Columns["Cantidad"], ListSortDirection.Ascending);
            } else if (sender == SortPrecio)
            {
                TablaDatos.Sort(TablaDatos.Columns["Precio"], ListSortDirection.Ascending);
            } else if (sender == SortTipo)
            {
                TablaDatos.Sort(TablaDatos.Columns["Tipo"], ListSortDirection.Ascending);
            }
        }

        private void Filter(object sender, EventArgs e)
        {

        }

        private void CSV(object sender, EventArgs e) //Listener for CSV import and export buttons
        {
            if (sender == ImportCSV)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog()) //declaration of the file selection dialog, which releases the resource as soon as the statement completes
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "csv files (*.csv)|*.csv";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        string message = "¿Está seguro de querer importar?\nSe perderán los datos actuales";
                        string caption = "Importar";
                        
                        if(MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question) == DialogResult.Yes)
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
            }
            else if (sender == ExportCSV)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog()) //declaration of the file selection dialog, which releases the resource as soon as the statement completes
                {
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
    }
}
