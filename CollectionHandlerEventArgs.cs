using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using labar10;

namespace RealLaba13
{
    public class CollectionHandlerEventArgs : EventArgs
    {
        public string NameOfChange { get; }

        public Person Element { get; set; }

        public string CollectionName { get; set; }

        public CollectionHandlerEventArgs(string nameOfChange, string collectionName, Person element)
        {
            NameOfChange = nameOfChange;
            Element = element;
            CollectionName = collectionName;
        }
    }
}
