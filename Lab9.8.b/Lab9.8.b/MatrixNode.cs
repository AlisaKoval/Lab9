using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9._8.b
{
    public class MatrixNode
    {
        public MatrixNode(int[] data)
        {
            Data = data;
        }
        public int[] Data { get; set; }
        public MatrixNode Next { get; set; }
    }
}
