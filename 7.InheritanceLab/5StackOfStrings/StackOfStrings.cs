using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : List<string>
    {
        private List<string> list;

        public List<string> List
        {
            get { return list; }
            set { list = value; }
        }

        public StackOfStrings()
        {
            this.List = new List<string>();
        }

        public void Push(string item)
        {
            this.List.Add(item);
        }

        public string Pop()
        {
            if (this.IsEmpty())
            {
                throw new IndexOutOfRangeException("There is no data in the stack");
            }

            string element = this.List.Last();
            this.List.Remove(element);
            return element;
        }

        public string Peek()
        {
            if (this.IsEmpty())
            {
                throw new IndexOutOfRangeException("There is no data in the stack");
            }

            return this.List.Last();
        }

        public bool IsEmpty()
        {
            return this.List.Count < 1;
        }
    }
}
