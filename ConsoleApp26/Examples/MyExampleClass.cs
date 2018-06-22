using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp26.FancyCollections;

namespace ConsoleApp26.Examples
{
    public class MyExampleClass : IPropertyObservable
    {
        private int _age;
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                if (_name == value) return;
                var old = _name;
                _name = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Name), old, value));
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (_age == value) return;
                var old = _age;
                _age = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Age), old, value));
            }
        }

        public event EventHandler<PropertyChangedEventArgs> PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
