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
            //this.KeyPress += new KeyPressEventHandler(KeyPressed);
            
        }

        public void ReloadTable()
        {
            TablaDatos.Rows.Clear();
            ProductController.First();
            for(int i = 0; i < ProductController.Count; i++)
            {
                TablaDatos.Rows.Add(ProductController.LoadString(ProductController.Next().Id));
            }
        }

        private void CRUD(object sender, EventArgs e)
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
                if(TablaDatos.SelectedRows.Count > 0 && TablaDatos.SelectedRows[0].Cells.Count > 0)
                {
                    if (TablaDatos.SelectedRows[0].Cells[0].Value != null)
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
                if(TablaDatos.SelectedRows.Count > 0 && TablaDatos.SelectedRows[0].Cells.Count > 0)
                {
                    if (TablaDatos.SelectedRows[0].Cells[0].Value != null)
                    {
                        if(TablaDatos.SelectedRows.Count == 1)
                        {
                            message = "¿Está seguro de que desea eliminar el registro?";
                        }else
                        {
                            message = "¿Está seguro de que desea eliminar los registros?";
                        }
                        string caption = "Eliminar";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
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
                } else
                {
                    message = "Selecciona una fila";
                    string caption = "Error";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                }

            }
        }

        private void Sort(object sender, EventArgs e)
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

        private void CSV(object sender, EventArgs e)
        {
            if (sender == ImportCSV)
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "csv files (*.csv)|*.csv";
                    //openFileDialog.FilterIndex = 2;
                    //openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        string message = "¿Está seguro de querer importar?\nSe perderán los datos actuales";
                        string caption = "Importar";
                        
                        if(MessageBox.Show(message, caption, buttons, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (ProductController.ImportCSV(openFileDialog.FileName))
                            {
                                buttons = MessageBoxButtons.OK;
                                message = "Importado con éxito";
                                caption = "Importar";
                                MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);
                                ReloadTable();
                            }
                            else
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
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "csv files (*.csv)|*.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if(ProductController.SaveCSV(saveFileDialog.FileName))
                    {
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        string message = "Exportado con éxito";
                        string caption = "Exportar";
                        MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);
                    } else
                    {
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        string message = "Ha habido un error al guardar";
                        string caption = "Exportar";
                        MessageBox.Show(message, caption, buttons, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //private void KeyPressed(object sender, KeyPressEventArgs k)
        //{
        //    if(k.KeyChar == 5)
        //    {
        //        CSV(ExportCSV, null);
        //    }
        //}
        
    }
}
