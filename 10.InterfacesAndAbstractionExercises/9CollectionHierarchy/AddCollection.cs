using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection : List<string>, IAdditional
    {
        public void AddElement(string element)
        {
            this.Add(element);
            Console.Write($"{this.Count - 1} ");
        }
    }
}
