using System;
using System.Collections.Generic;

namespace Lab9._4
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 50000;
            N = (int)Math.Pow(N, 0.333);           
            Dictionary<string, int> cube = new Dictionary<string, int>();
            for (int i =1; i<N;i++)
            {
                for(int j=1;j<N;j++)
                {
                    for(int k=1;k<N;k++)
                    {
                        int sum = (int)(Math.Pow(i, 3) + Math.Pow(j, 3) + Math.Pow(k, 3));
                        cube.Add(i + " " + j + " " + k, sum);
                    }
                }
            }
            int[] cnt = new int[50001];
            foreach (KeyValuePair < string, int> keyVaiue in cube)
            {
                if (keyVaiue.Value <= 50000)
                    cnt[keyVaiue.Value]++;
            }
            for(int i=0; i<cnt.Length;i++)
            {
                if (cnt[i] > 2)
                    Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
