using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26.FancyCollections
{
    public enum CollectionChange
    {
        Add,
        Remove,
        Clear
    }

    public class CollectionChangedEventArgs : EventArgs
    {
        public CollectionChange CollectionChange { get; }

        public CollectionChangedEventArgs(CollectionChange change)
        {
            CollectionChange = change;
        }
    }
}
