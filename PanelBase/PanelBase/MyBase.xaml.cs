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

namespace PanelBase
{
    /// <summary>
    /// Interaction logic for MyBase.xaml
    /// </summary>
    public partial class MyBase : UserControl
    {
        public MyBase()
        {
            InitializeComponent();
        }

        private void onMouseEnter(object sender, MouseEventArgs e)
        {
            this.Background = Brushes.GreenYellow;
        }

        private void onMouseLeave(object sender, MouseEventArgs e)
        {
            this.Background = Brushes.Yellow;
        }
    }
}
