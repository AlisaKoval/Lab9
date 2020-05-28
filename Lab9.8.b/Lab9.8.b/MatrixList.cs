using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Lab9._8.b
{
    public class MatrixList : IEnumerable
    {
        MatrixNode head;
        MatrixNode tail;
        int count;
        public void Add (int[] data)
        {
            MatrixNode node = new MatrixNode(data);
            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;
            count++;
        }
        public int Count { get { return count; } }
        public int Lenght { get { return head.Data.Length; } }
        public int Elem( int i, int j)
        {
            if (i >= count)
                throw new IndexOutOfRangeException();
            if (i < 0)
                throw new IndexOutOfRangeException();
            MatrixNode curremt = head;
            for(int k = 0,l = 0; curremt != null; k++,l++)
            {
                if( i == k && j ==l )
                   return curremt.Data[i];
                else curremt = curremt.Next;
            }
            return default;
        }
        public void PrintMatrix()
        {
            MatrixNode current = head;
            for(int i = 0; i < count; i++)
            {
                for(int j = 0; j < current.Data.Length; j++)
                {
                    Console.Write(Elem(i, j) + " ");
                }
                Console.WriteLine();
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    
        }
    }

