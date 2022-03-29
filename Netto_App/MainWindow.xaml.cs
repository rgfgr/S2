using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Netto_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Netto_App.Netto_dbDataSet netto_dbDataSet = ((Netto_App.Netto_dbDataSet)(this.FindResource("netto_dbDataSet")));
            // Load data into the table Varre. You can modify this code as needed.
            Netto_App.Netto_dbDataSetTableAdapters.VarreTableAdapter netto_dbDataSetVarreTableAdapter = new Netto_App.Netto_dbDataSetTableAdapters.VarreTableAdapter();
            netto_dbDataSetVarreTableAdapter.Fill(netto_dbDataSet.Varre);
            System.Windows.Data.CollectionViewSource varreViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("varreViewSource")));
            varreViewSource.View.MoveCurrentToFirst();
        }
    }
}
