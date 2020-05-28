using System;
using System.Collections.Generic;

namespace Lab9._7
{
    class Program
    {
        public static Boolean ListsContains<T>(List<T> firstList, List<T> secondList)
        {
            foreach(T item in secondList)
            {
                if (!firstList.Contains(item))
                    return false;
            }
            return true;
        }
        public static Boolean DoublyLinkedListsContains<T>(DoublyLinkedList<T> firstList, DoublyLinkedList<T> secondList)
        {
            foreach(T item in secondList)
            {
                if (!firstList.Contains(item))
                    return false;
            }
            return true;
        }
static void Main(string[] args)
        {
            //var 5
            //.Net
            List<string> firstList = new List<string>();
            firstList.AddRange(new string[] { "1", "2", "a", "b", "c", "d", "e" });
            List<string> secondList = new List<string>();
            secondList.AddRange(new string[] { "a", "b", "c", "c" });
            Console.WriteLine(ListsContains(firstList, secondList));
            //DoublyLinkedList
            DoublyLinkedList<string> listOne = new DoublyLinkedList<string>
            {
                "1",
                "2",
                "a",
                "k",
                "c",
                "d",
                "e"
            };
            DoublyLinkedList<string> listTwo = new DoublyLinkedList<string>
            {
                "a",
                "b",
                "c",
                "c"
            };
            Console.WriteLine(DoublyLinkedListsContains(listOne, listTwo));
            Console.ReadKey();
        }
    }
}
