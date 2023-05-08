using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class ListTestPlan : INotifyPropertyChanged
    {
        private bool _Switch = true;
        private string _Class = string.Empty;
        private string _Standard = string.Empty;

        public bool Switch
        {
            get => _Switch;
            set
            {
                _Switch = value;
                OnPropertyChanged(nameof(Switch));
            }
        }
        public string Class
        {
            get => this._Class;
            set
            {
                _Class = value;
                OnPropertyChanged(nameof(Class));
            }
        }
        public string Standard
        {
            get => _Standard;
            set
            {
                _Standard = value;
                OnPropertyChanged(nameof(Standard));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;
            PropertyChanged((object)this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
