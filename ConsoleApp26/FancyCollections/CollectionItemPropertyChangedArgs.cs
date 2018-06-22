using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26.FancyCollections
{
    public class CollectionItemPropertyChangedArgs : EventArgs
    {
        public object Element { get; }
        public string PropertyName { get; }
        public object OldValue { get; }
        public object NewValue { get; }
        public CollectionItemPropertyChangedArgs(object element, string propertyName, object oldValue, object newValue)
        {
            Element = element;
            PropertyName = propertyName;
            OldValue = oldValue;
            NewValue = newValue;
        }

    }
}
