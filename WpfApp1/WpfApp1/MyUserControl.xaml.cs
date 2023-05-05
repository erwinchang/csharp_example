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
            //DataContext = this;
        }

        public static readonly DependencyProperty ContentTextProperty = DependencyProperty.Register("ContentText",typeof(String), typeof(MyUserControl),
                                                                       (PropertyMetadata)new FrameworkPropertyMetadata(new PropertyChangedCallback(MyUserControl.OnContentTextChanged)));
        public String ContentText
        {
            get
            {
                return (String)GetValue(ContentTextProperty);
            }
            set
            {
                SetValue(ContentTextProperty, value);
            }
        }

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header",typeof(String), typeof(MyUserControl), 
                                                                    (PropertyMetadata)new FrameworkPropertyMetadata(new PropertyChangedCallback(MyUserControl.OnHeaderChanged)));
        public String Header
        {
            get
            {
                return (String)GetValue(HeaderProperty);
            }
            set
            {
                SetValue(HeaderProperty, value);
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

        private static void OnHeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MyUserControl mu = (MyUserControl)d;
            mu.txtHeader.Text = mu.Header;
        }

        private static void OnContentTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MyUserControl mu = (MyUserControl)d;
            mu.txtContentText.Text = mu.ContentText;
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
