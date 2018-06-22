using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp26.FancyCollections
{
    public class PropertyChangedEventArgs : EventArgs
    {
        public string PropertyName { get; }
        public object OldValue { get; }
        public object NewValue { get; }
        public PropertyChangedEventArgs(string propertName, object oldValue, object newValue)
        {
            PropertyName = propertName;
            OldValue = oldValue;
            NewValue = newValue;
        }

    }
}
