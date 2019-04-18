using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random { get; set; }

        public RandomList()
        {
            random = new Random();
        }

        public string RandomString()
        {
            if (this.Count < 1)
            {
                throw new IndexOutOfRangeException("There are no questions left");
            }

            int index = random.Next(0, this.Count - 1);
            string randomQuestion = this[index];
            this.RemoveAt(index);

            return randomQuestion;
        }
    }
}
