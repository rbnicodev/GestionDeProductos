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


        private void Create(object sender, EventArgs e)
        {
            MainViewController.Create(DataTable);
        }
        private void Edit(object sender, EventArgs e)
        {
            MainViewController.Edit(DataTable);
        }
        private void Delete(object sender, EventArgs e)
        {
            MainViewController.Delete(DataTable);
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
        private void ImportFromCSV(object sender, EventArgs e)
        {
            MainViewController.ImportCSV(DataTable);
        }
        private void ExportToCSV(object sender, EventArgs e)
        {
            MainViewController.ExportCSV();
        }
        private void Filter(object sender, EventArgs e)
        {
            MainViewController.ReloadTableFiltered(DataTable, ComboFilter.SelectedIndex);
        }
    }
}
