using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class PostsViewModel : INotifyPropertyChanged
    {
        public Posts posts { get; set; }

        public PostsViewModel()
        {
            posts = new Posts { postsText = "", postsTitle = "Unknown" };
        }

        public string PostsTitle
        {
            get { return posts.postsTitle; }
            set
            {
                if (posts.postsTitle != value)
                {
                    posts.postsTitle = value;
                    OnPropertyChanged("postsTitle");
                }
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
