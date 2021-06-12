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
    /// Interaction logic for QListViewItem.xaml
    /// </summary>
    public partial class QListViewItem : ListViewItem
    {
        public QListViewItem()
        {
            InitializeComponent();
        }
        public void setText(string str)
        {
            ui_textEdit.Text = str;
        }
        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            Background = Brushes.MediumOrchid;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            Background = Brushes.Transparent;
        }
    }
}
