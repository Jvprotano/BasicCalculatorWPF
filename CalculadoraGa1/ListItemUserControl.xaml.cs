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

namespace CalculadoraGa1
{
    public partial class ListItemUserControl : UserControl
    {

        public ListItem listItem
        {
            get { return listItem; }
            set { listItem = value; }
        }


        public ListItemUserControl()
        {
            InitializeComponent();
        }

    }
}
