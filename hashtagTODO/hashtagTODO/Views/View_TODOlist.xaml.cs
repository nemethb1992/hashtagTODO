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

namespace hashtagTODO.Views
{
    /// <summary>
    /// Interaction logic for View_TODOlist.xaml
    /// </summary>
    public partial class View_TODOlist : UserControl
    {
        private Grid grid;

        TODOlist_controller todo_control = new TODOlist_controller();

        public View_TODOlist(Grid grid)
        {
            InitializeComponent();
            this.grid = grid;
            Application_StartUp();
        }
        private void Application_StartUp()
        {
            TODOlist_listbox.ItemsSource = todo_control.TODOlist_FullQuery();
        }
    }
}
