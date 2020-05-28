using System;
using System.Collections.Generic;

namespace Lab9._2
{
    class Program
    {
        static bool Check (string s)
        {
            Stack<char> brackets = new Stack<char>();
            for(int i=0; i<s.Length;i++)
            { 
                if (s[i] == '(')
                    brackets.Push(s[i]);
                else if(s[i] == ')')
                {
                    if (brackets.Count == 0 || brackets.Pop() != '(')
                        return false;
                }
            }
            return brackets.Count == 0;
        }
        static void Main(string[] args)
        {
            string s;
            do
            {
                Console.WriteLine("Enter expression:");
                s = Console.ReadLine();
                bool isCorrect = Check(s);
                if (isCorrect)
                    Console.WriteLine("correct expression");
                else
                    Console.WriteLine("The expression is wrong");
            }
            while (s != "stop");
        }
    }
}
