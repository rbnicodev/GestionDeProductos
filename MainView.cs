using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                if(TablaDatos.SelectedRows.Count > 0 && TablaDatos.SelectedRows[0].Cells.Count > 0)
                {
                    if (TablaDatos.SelectedRows[0].Cells[0].Value != null)
                    {
                        foreach (DataGridViewRow row in TablaDatos.SelectedRows)
                        {
                            if (row.Cells[0].Value != null)
                            {
                                string message = "¿Desea eliminar el registro?";
                                string caption = "Eliminar";
                                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                                DialogResult result;

                                result = MessageBox.Show(message, caption, buttons);
                                if (result == DialogResult.Yes)
                                {
                                    ProductController.delete(row.Cells[0].Value.ToString());
                                    ReloadTable();
                                }
                            }
                        }

                    }
                } else
                {
                    string message = "Selecciona una fila";
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
    }
}
