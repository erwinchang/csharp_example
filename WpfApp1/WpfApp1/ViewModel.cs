using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ViewModel : INotifyPropertyChanged
    {
        private String _ContentText;
        public string ContentText
        {
            get => this._ContentText;
            set
            {
                this._ContentText = value;
                this.OnPropertyChanged(nameof(ContentText));
            }
        }

        private String _Header;
        public string Header
        {
            get => this._Header;
            set
            {
                this._Header = value;
                this.OnPropertyChanged(nameof(Header));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged == null)
                return;
            this.PropertyChanged((object)this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
