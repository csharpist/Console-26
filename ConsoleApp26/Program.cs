using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp26.Annotations;
using ConsoleApp26.Examples;
using ConsoleApp26.FancyCollections;

namespace ConsoleApp26
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new FancyObservableCollection<MyExampleClass>();
            collection.CollectionItemPropertyChanged += Collection_CollectionItemPropertyChanged;

            collection.Add(new MyExampleClass { Age = 35, Name = "Emily" });
            collection.Add(new MyExampleClass { Age = 23, Name = "Mark" }); 

            collection.First().Age = 36;
            collection.First().Age = 37;
            collection.First().Name = "Frank";
            collection.Last().Name = "Mark 2";
            collection.Last().Age = 60;

            var obj = collection.Last();
            collection.Remove(obj);

            obj.Name = "Mark 2 after removed from collection"; // should not fire events

        }

        private static void Collection_CollectionItemPropertyChanged(object sender, CollectionItemPropertyChangedArgs e)
        {
            Console.WriteLine($"Changed element: {e.Element}, changed property: {e.PropertyName}, changed: {e.OldValue} → {e.NewValue}");
        }

    }
}
