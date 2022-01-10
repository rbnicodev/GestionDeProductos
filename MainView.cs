using System;
using System.IO;
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
            ProductController.first();
            for(int i = 0; i < ProductController.Count; i++)
            {
                TablaDatos.Rows.Add(ProductController.loadString(ProductController.next().Id));
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

            }else if ((sender == Editar || sender == MenuEditar) && TablaDatos.SelectedRows.Count > 0 && TablaDatos.SelectedRows[0].Cells.Count > 0)
            {
                if (TablaDatos.SelectedRows[0].Cells[0].Value != null)
                {
                    NewProduct ventana = new NewProduct(this, ProductController.load(TablaDatos.SelectedRows[0].Cells[0].Value.ToString()));
                    ventana.ShowDialog();
                    if (ventana.DialogResult == DialogResult.OK)
                    {
                        ReloadTable();
                    }
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
                        DialogResult result = MessageBox.Show(message, caption, buttons);
                        if (result == DialogResult.Yes)
                        {
                            foreach (DataGridViewRow row in TablaDatos.SelectedRows)
                            {
                                if (row.Cells[0].Value != null)
                                {
                                    ProductController.delete(row.Cells[0].Value.ToString());
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
                    MessageBox.Show(message, caption, buttons);
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
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
            }
            else if (sender == ExportCSV)
            {
                Stream myStream = ProductController.ToCsvStream();
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                saveFileDialog1.Filter = "csv files (*.csv)|*.csv";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {
                        myStream.Close();
                    }
                }
            }
        }
        
    }
}
