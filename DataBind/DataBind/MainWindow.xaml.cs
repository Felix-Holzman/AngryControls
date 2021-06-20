using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DataBind
{
    class WeatherData : INotifyPropertyChanged
    {
        private string curTemp;
        public string m_curTemp
        {
            get { return curTemp; }
            set {
                curTemp = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(m_curTemp)));
                }
            }
        }
        private string _curSkyCondition;
        public string m_curSkyCondition {
            get
            {
                return _curSkyCondition;
            }
            set
            {
                _curSkyCondition = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(m_curSkyCondition   )));
                }
            }
        }
        string _airCondition;
        public string m_airCondition
        {
            get
            {
                return _airCondition;
            }
            set
            {
                _airCondition = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(m_airCondition)));
                }
            }
        }
        string _skyPng;
        public string m_skyPng
        {
            get
            {
                return _skyPng;
            }
            set
            {
                _skyPng = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(m_skyPng)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BackgroundWorker w = new BackgroundWorker();
            w.DoWork += W_DoWork;
            w.RunWorkerAsync();
            this.DataContext = m_data;
        }
        DateTime m_curTime = DateTime.Now;
        WeatherData m_data = new WeatherData();

        int idx = 0;
        int m_curTemp = -20;
        private void W_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true){
                var now = DateTime.Now;
                var span = now - m_curTime;
                if (span.TotalSeconds >= 2)
                {
                    m_curTime = now;
                    idx++;
                    m_data.m_curTemp = m_curTemp++.ToString();
                    m_data.m_curSkyCondition = "Sunny" + idx.ToString();
                    m_data.m_airCondition = "Pure" + idx.ToString();
                    string path = "";
                    if(now.Second % 3 == 0)
                    {
                        path = "pack://application:,,,/" + "DataBind" + ";component/" + "Resources/images/cloudy.png";
                    }
                    else
                    {
                        path = "pack://application:,,,/" + "DataBind" + ";component/" + "Resources/images/rain.png";
                    }
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
                    bi3.EndInit();

                    m_data.m_skyPng = path;
                    //this.Dispatcher.Invoke(new Action(() => {
                    //    this.DataContext = m_data;
                    //}));
                }
            }
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var now = DateTime.Now;
            m_curTime = now;
            m_data.m_curTemp = m_curTemp++.ToString();
            m_data.m_curSkyCondition = "Sunny" + idx++.ToString();
            m_data.m_airCondition = "Pure" + idx++.ToString();
            string path = "";
            if (now.Second % 3 == 0)
            {
                path = "pack://application:,,,/" + "DataBind" + ";component/" + "Resources/images/cloudy.png";
            }
            else
            {
                path = "pack://application:,,,/" + "DataBind" + ";component/" + "Resources/images/rain.png";
            }
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(path, UriKind.RelativeOrAbsolute);
            bi3.EndInit();

            //m_data.m_skyPng = bi3;

            this.DataContext = m_data;

        }
    }
}
