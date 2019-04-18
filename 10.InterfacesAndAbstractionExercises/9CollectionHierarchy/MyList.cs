using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : List<string>, IFunctional
    {
        private int used;

        public int Used
        {
            get { return used; }
            private set
            {
                used = this.Count;
            }
        }

        public void AddElement(string element)
        {
            this.Insert(0, element);
            Console.Write("0 ");
        }

        public void RemoveElement()
        {
            string firstElement = this[0];
            this.Remove(firstElement);
            Console.Write($"{firstElement} ");
        }
    }
}
