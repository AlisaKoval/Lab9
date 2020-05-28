using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9._1a
{
        public class DoublyNode<DoubleList>
        {
            public DoublyNode(DoubleList data)
            {
                Data = data;
            }
            public DoubleList Data { get; set; }
            public DoublyNode<DoubleList> Previous { get; set; }
            public DoublyNode<DoubleList> Next { get; set; }
        }
}

