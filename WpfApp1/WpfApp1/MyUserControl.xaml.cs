using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApp1
{
    /// <summary>
    /// MyUserControl.xaml 的互動邏輯
    /// </summary>
    public partial class MyUserControl : UserControl, INotifyPropertyChanged
    {
        public MyUserControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        private String contextText;
        public String ContentText
        {
            get
            {
                return contextText;
            }
            set
            {
                SetProperty(ref contextText, value, "ContentText");
            }
        }

        private String header;
        public String Header
        {
            get
            {
                return header;
            }
            set
            {
                SetProperty(ref header, value, "Header");
            }
        }
        private String backgroundColor;
        public String BackgroundColor
        {
            get
            {
                return backgroundColor;
            }
            set
            {
                SetProperty(ref backgroundColor, value, "BackgroundColor");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            return true;
        }
    }
}
