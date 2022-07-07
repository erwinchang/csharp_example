using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_example
{
    //https://stackoverflow.com/questions/4279185/what-is-the-use-of-observablecollection-in-net
    public class Handler
    {
        public ObservableCollection<string> collection;
        public Handler()
        {
            collection = new ObservableCollection<string>();
            collection.CollectionChanged += HandleChange;
        }
        private void HandleChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            int i;
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Debug.WriteLine("HandleChange: Add");
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                Debug.WriteLine("HandleChange: Remove");
            }
            else if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                Debug.WriteLine("HandleChange: Reset");
            }
            else if (e.Action == NotifyCollectionChangedAction.Move)
            {
                Debug.WriteLine("HandleChange: Move");
            }

                i =0;
            if (e.OldItems != null)
            {
                foreach (var y in e.OldItems)
                {
                    Debug.WriteLine($"OldItems[{i}]: {y}");
                    i++;
                }
            }

            i = 0;
            if (e.NewItems != null)
            {
                foreach (var x in e.NewItems)
                {
                    Debug.WriteLine($"NewItems[{i}]: {x}");
                    i++;
                }
            }

            i = 0;
            foreach(var x in collection)
            {
                Debug.WriteLine($"collection[{i}]: {x}");
            }
        }
    }
}
