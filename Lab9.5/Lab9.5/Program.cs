using System;
using Lab9._5.Properties;
using System.Collections.Generic;
using System.Linq;

namespace Lab9._5
{
    class Program
    {
      
        static void Main(string[] args)
        {
            string AllData = Resources.TextFile1;
            string[] arrayWords = AllData.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);      
            Dictionary<string, int> word = new Dictionary<string, int>();
            foreach (string item in arrayWords)
            {
                if (!word.ContainsKey(item))
                    word.Add(item, 1);
                else
                    word[item]++;
            }
            SortedDictionary < string, int> sortedWord = new SortedDictionary<string, int>(word);
            foreach (var sourse in sortedWord.OrderByDescending(x=>x.Value).Take(10))
            {
                Console.WriteLine(sourse.Key);
            }
            Console.ReadKey();
        }
    }
}
