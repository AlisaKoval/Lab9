 using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Lab9._3
{
    
    class Program
    {

        static void Main(string[] args)
        {
            string[] names = { "Alex", "Leo", "Kate", "Shon", "Rob", "Slava", "Vlad", "Dima", "Max", "Roma" };
            CircularLinkedList<string> persons = new CircularLinkedList<string>();
            foreach(string name in names)
            {
                persons.Add(name);
                Console.WriteLine(name);
            }
            string enterName;
            do
            {
                Console.WriteLine("Enter the name:");
                enterName = Console.ReadLine();
            } while (!persons.Contains(enterName));
            Console.WriteLine("Enter the rhyme:");
            string rhyme = Console.ReadLine();
            string[] wordRhyme = rhyme.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            persons.Swap(enterName);
            int i = 0;
            do
            {
                foreach (string person in persons)
                {
                    if (i == wordRhyme.Length-1)
                        Console.WriteLine(person);
                    i++;
                }
            } while (i < wordRhyme.Length);
            //Способ без дополнительных структур данных
            int ind;
           for( ind =0; ind<names.Length; ind++)
            {
                if (names[ind] == enterName)
                    break;
            }
            int h = wordRhyme.Length % 10 + ind;
            if (h > 10)
                h -= 10;
            Console.WriteLine(names[h - 1]);
            Console.ReadKey();
        }
    }
}
