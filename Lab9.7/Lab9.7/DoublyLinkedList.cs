using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab9._7
{
    public class DoublyLinkedList<DoubleList> : IEnumerable<DoubleList>
    {
        DoublyNode<DoubleList> head;
        DoublyNode<DoubleList> tail;
        int count;
        public void Add(DoubleList data)
        {
            DoublyNode<DoubleList> node = new DoublyNode<DoubleList>(data);
            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }
        public void AddFirst(DoubleList data)
        {
            DoublyNode<DoubleList> node = new DoublyNode<DoubleList>(data);
            DoublyNode<DoubleList> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }
        public bool Remove(DoubleList data)
        {
            DoublyNode<DoubleList> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if (current != null)
            {
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    tail = current.Previous;
                }
                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    head = current.Next;
                }
                count--;
                return true;
            }
            return false;
        }
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        public bool Contains(DoubleList data)
        {
            DoublyNode<DoubleList> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
        IEnumerator<DoubleList> IEnumerable<DoubleList>.GetEnumerator()
        {
            DoublyNode<DoubleList> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        public IEnumerable<DoubleList> BackEnumerator()
        {
            DoublyNode<DoubleList> current = tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
        public DoublyNode<DoubleList> GetElem(int index)
        {
            DoublyNode<DoubleList> Previous = tail;
            DoublyNode<DoubleList> Next = head;
            if (index < ((count + 1) / 2))
            {
                if (index == 0)
                    return head;
                while (index != 0)
                {
                    Next = Next.Next;
                    index--;
                }
                return Next;
            }
            else
            {
                while (index < count - 1)
                {
                    Previous = Previous.Previous;
                    index++;
                }
                return Previous;
            }
        }
        public DoubleList Insert(DoubleList data, int index)
        {
            DoublyNode<DoubleList> Last = tail;
            DoublyNode<DoubleList> Next = GetElem(index);
            if (index == 0)
            {
                head = new DoublyNode<DoubleList>(data);
                head.Next = Next;
                Next.Previous = head;
                count++;
                return default(DoubleList);
            }
            DoublyNode<DoubleList> NewData = new DoublyNode<DoubleList>(data);
            if (index == count)
            {
                Last.Next = NewData;
                NewData.Previous = Last;
                tail = NewData;
                count++;
                return default(DoubleList);
            }
            DoublyNode<DoubleList> Previous = GetElem(index - 1);

            Previous.Next = NewData;
            NewData.Previous = Previous;
            Next.Previous = NewData;
            NewData.Next = Next;
            count++;
            return default(DoubleList);
        }

    }
}
