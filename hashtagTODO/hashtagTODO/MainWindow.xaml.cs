using hashtagTODO.Views;
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

namespace hashtagTODO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private View_Projektlist view_Projektlist;
        public MainWindow()
        {
            InitializeComponent();
            sgrid.Children.Add(view_Projektlist = new View_Projektlist(sgrid));
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void exit_btn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sgrid.Children.Clear();
            sgrid.Children.Add(view_Projektlist = new View_Projektlist(sgrid));
        }
    }
}
