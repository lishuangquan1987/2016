using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.Model;
namespace WPFControls
{
    /// <summary>
    /// Interaction logic for UCDataGrid.xaml
    /// </summary>
    public partial class UCDataGrid : UserControl
    {
        public UCDataGrid()
        {
            InitializeComponent();
        }

        private void DataGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataGridCellInfo cell = dg.SelectedCells[0];
            Student s = cell.Item as Student;

            string field = cell.Column.Header.ToString();
            MessageBox.Show(s.GetType().GetProperty(field).GetValue(s,null).ToString());
            
        }
    }
}
