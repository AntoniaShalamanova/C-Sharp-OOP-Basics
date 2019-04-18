using System;

namespace CollectionHierarchy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            foreach (var element in input)
            {
                addCollection.AddElement(element);
            }

            Console.WriteLine();

            foreach (var element in input)
            {
                addRemoveCollection.AddElement(element);
            }

            Console.WriteLine();

            foreach (var element in input)
            {
                myList.AddElement(element);
            }

            Console.WriteLine();

            int countToRemove = int.Parse(Console.ReadLine());

            for (int i = 0; i < countToRemove; i++)
            {
                addRemoveCollection.RemoveElement();
            }

            Console.WriteLine();

            for (int i = 0; i < countToRemove; i++)
            {
                myList.RemoveElement();
            }

            Console.WriteLine();
        }
    }
}
