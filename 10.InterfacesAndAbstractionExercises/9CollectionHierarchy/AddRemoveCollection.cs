using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : List<string>, IFunctional
    {
        public void AddElement(string element)
        {
            this.Insert(0, element);
            Console.Write("0 ");
        }

        public void RemoveElement()
        {
            string lastElement = this[this.Count - 1];
            this.Remove(lastElement);
            Console.Write($"{lastElement} ");
        }
    }
}
