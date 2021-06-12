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
    /// Interaction logic for QComboBox.xaml
    /// </summary>
    public partial class QComboBox : Border
    {
        public QComboBox()
        {
            InitializeComponent();
        }
        public void addItem(UIElement e)
        {
            ui_list.Items.Add(e);
        }
        public void addItem(string str)
        {
            ListViewItem item = new ListViewItem();
            item.Height = 32;
            Style st = FindResource("style_listviewItem") as Style;
            if(st != null)
            {
                item.Style = st;
            }
            item.Content = str;
            ui_list.Items.Add(item);
        }
        DateTime m_downTime = DateTime.Now;

        private void Ui_toggleButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            m_downTime = DateTime.Now;
        }

        //点击事件
        private void Ui_toggleButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            var span = DateTime.Now - m_downTime;
            if(span.TotalMilliseconds <= 200)
            {
                //0.2 second
                ui_pp.IsOpen = !ui_pp.IsOpen;
            }
        }
        DateTime m_downInList = DateTime.Now;
        private void ScrollViewer_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            m_downInList = DateTime.Now;
        }
        public void setEditable(bool s)
        {
                ui_textBox.IsEnabled = s;
            
        }
        private void ScrollViewer_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            var span = DateTime.Now - m_downInList;
            if(span.TotalMilliseconds <= 200)
            {
                //0.2 second
                foreach(var item in ui_list.Items)
                {
                    ListViewItem listItem = item as ListViewItem;
                    if (listItem == null) continue;
                    if (listItem.Content == null) continue;
                    if (listItem.IsSelected)
                    {
                        ui_textBox.Text = listItem.Content.ToString();
                        ui_pp.IsOpen = false;
                        return;
                    }
                }
            }
        }
    }
}
