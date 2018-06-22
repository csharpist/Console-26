using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26.FancyCollections
{
    public interface IFancyObservableCollection<T> : ICollection<T>
    {
        event EventHandler<CollectionItemPropertyChangedArgs> CollectionItemPropertyChanged;
        event EventHandler<CollectionChangedEventArgs> CollectionChanged;
    }
}
