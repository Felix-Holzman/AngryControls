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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            test_qcombo();
        }
        void test_qcombo()
        {
            ui_qcombo.setEditable(true);
            for(int i = 0;i < 4; ++i)
            {
                string str = "apple" + i.ToString();
                ui_qcombo.addItem(str);
            }
        }
        private void rect_MouseEvent(object sender, MouseEventArgs e)
        {
            if (rect.IsMouseOver)
            {
                VisualStateManager.GoToElementState(rect, "MouseEnter", true);
            }
            else
            {
                VisualStateManager.GoToElementState(rect, "MouseLeave", true);
            }
        }
    }
}
