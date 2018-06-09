using hashtagTODO.Controllers;
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
using static hashtagTODO.Models.Projektlist_model;

namespace hashtagTODO.Views
{
    /// <summary>
    /// Interaction logic for View_Projektlist.xaml
    /// </summary>
    public partial class View_Projektlist : UserControl
    {
        private Grid grid;
        private View_TODOlist View_TODOlist;
        Projektlist_controller proj_control = new Projektlist_controller();

        public View_Projektlist(Grid grid)
        {
            InitializeComponent();
            this.grid = grid;
            Application_StartUp();
        }
        private void Application_StartUp()
        {
            Projekt_list.ItemsSource = proj_control.Projektlist_FullQuery();
        }

        private void Projekt_Open_Click(object sender, MouseButtonEventArgs e)
        {
            Grid btn = sender as Grid;
            Projektlist_DataSource items = btn.DataContext as Projektlist_DataSource;
            proj_control.projektID = items.id;
            grid.Children.Clear();
            grid.Children.Add(View_TODOlist = new View_TODOlist(grid));
        }
    }
}
