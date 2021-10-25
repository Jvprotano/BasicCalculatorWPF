using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CalculadoraGa1.Model;
using CalculadoraGa1.ViewModel;

namespace CalculadoraGa1
{
    public partial class ListItemUserControl : UserControl
    {
        private ListItem? _listItem;

        public ListItem ListItem
        {
            get
            {
                return _listItem;
            }
            set
            {
                _listItem = value;
                Operation_TextBox.Text = ListItem.Operation;
                Result_TextBox.Text = ListItem.Result;
            }
        }

        private int _width;

        public int Width
        {
            get { return _width; }
            set
            {
                _width = value;
                ListItem_Button.Width = _width;
            }
        }

        public static readonly DependencyProperty CarDependency = DependencyProperty.Register("ListItem", typeof(ListItem), typeof(ListItemUserControl));


        public ListItemUserControl()
        {
            InitializeComponent();
        }

    }
}
