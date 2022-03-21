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

namespace først_opgave
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

        private void jhon_Click(object sender, RoutedEventArgs e)
        {
            min_label.Content = "hej";
            min_label.Foreground = Brushes.Purple;
            min_label.FontSize = 25;
        }

        private void jhon_MouseEnter(object sender, MouseEventArgs e)
        {
            min_label.FontSize = 50;
            min_label.Background = Brushes.Salmon;
        }

        private void jhon_MouseLeave(object sender, MouseEventArgs e)
        {
            min_label.FontSize = 12;
            min_label.Background = Brushes.Transparent;
        }
    }
}
