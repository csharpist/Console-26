using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26.FancyCollections
{
    public class FancyObservableCollection<T> : IFancyObservableCollection<T> where T : IPropertyObservable
    {
        public event EventHandler<CollectionItemPropertyChangedArgs> CollectionItemPropertyChanged;
        public event EventHandler<CollectionChangedEventArgs> CollectionChanged;

        private readonly List<T> _innerList = new List<T>();

        public IEnumerator<T> GetEnumerator() => _innerList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(T item)
        {
            _innerList.Add(item);
            if (item != null)
            {
                item.PropertyChanged += Item_PropertyChanged;
            }
            OnCollectionChanged(new CollectionChangedEventArgs(CollectionChange.Add));
        }

        public bool Remove(T item)
        {
            if (!_innerList.Remove(item)) return false;
            if (item != null) item.PropertyChanged -= Item_PropertyChanged;
            OnCollectionChanged(new CollectionChangedEventArgs(CollectionChange.Remove));
            return true;
        }

        public void Clear()
        {
            foreach (var item in _innerList) item.PropertyChanged -= Item_PropertyChanged;
            _innerList.Clear();
            OnCollectionChanged(new CollectionChangedEventArgs(CollectionChange.Clear));
        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCollectionItemPropertyChanged(new CollectionItemPropertyChangedArgs(sender, e.PropertyName, e.OldValue, e.NewValue));
        }

        public bool Contains(T item) => _innerList.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => _innerList.CopyTo(array, arrayIndex);
        public int Count => _innerList.Count;
        public bool IsReadOnly => false;

        protected virtual void OnCollectionItemPropertyChanged(CollectionItemPropertyChangedArgs e)
        {
            CollectionItemPropertyChanged?.Invoke(this, e);
        }

        protected virtual void OnCollectionChanged(CollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }
    }
}
