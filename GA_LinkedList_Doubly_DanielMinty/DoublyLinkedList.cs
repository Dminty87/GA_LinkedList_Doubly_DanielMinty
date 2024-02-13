using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_LinkedList_Doubly_DanielMinty
{
    internal class DoublyLinkedList<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;

        public int Count { get { return count; } }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > count - 1)
                {
                    throw new IndexOutOfRangeException();
                }

                LinkedListNode<T> current;

                if (index > count / 2)
                {
                    current = tail;

                    for (int i = count - 1; i != index; i--)
                    {
                        current = current.Previous;
                    }

                    return current.Value;
                }

                current = head;

                for (int i = 0; i != index; i++)
                {
                    current = current.Next;
                }

                return current.Value;
            }
        }

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void Add(T value)
        {
            if (head == null && tail == null)
            {
                head = new LinkedListNode<T>(value);
                tail = head;
                count = 1;
            }
            else
            {
                tail.Next = new LinkedListNode<T> (value);
                tail.Next.Previous = tail;
                tail = tail.Next;
                count++;
            }
        }

        public void DisplayForward()
        {
            LinkedListNode<T> current = head;

            while (current != null)
            {
                Console.Write($"{current.Value}, ");
                current = current.Next;
            }

            Console.WriteLine($"Count:{Count}");
        }
        
        public void DisplayBackward()
        {
            LinkedListNode<T> current = tail;

            while (current != null)
            {
                Console.Write($"{current.Value}, ");
                current = current.Previous;
            }

            Console.WriteLine($"Count:{Count}");
        }

        public bool Remove(T value)
        {
            if (head == null && tail == null)
            {
                return false;
            }

            LinkedListNode<T> current = head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    current.Next.Previous = current.Previous;
                    current.Previous.Next = current.Next;
                    count--;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public void InsertAtIndex(int index, T value)
        {
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                if (head == null && tail == null)
                {
                    head = new LinkedListNode<T>(value);
                    tail = head;
                    count = 1;
                }
                else
                {
                    head.Previous = new LinkedListNode<T>(value);
                    head.Previous.Next = head;
                    head = head.Previous;
                    count++;
                }
                return;
            }

            if (index == count)
            {
                if (head == null && tail == null)
                {
                    head = new LinkedListNode<T>(value);
                    tail = head;
                    count = 1;
                }
                else
                {
                    tail.Next = new LinkedListNode<T>(value);
                    tail.Next.Previous = tail;
                    tail = tail.Next;
                    count++;
                }
                return;
            }

            LinkedListNode<T> current;

            if (index > count / 2)
            {
                current = tail;

                for (int i = count - 1; i != index; i--)
                {
                    current = current.Previous;
                }
            }
            else
            {
                current = head;

                for (int i = 0; i != index; i++)
                {
                    current = current.Next;
                }
            }

            current.Previous.Next = new LinkedListNode<T>(value);
            current.Previous.Next.Next = current;
            current.Previous.Next.Previous = current.Previous;
            current.Previous = current.Previous.Next;
            count++;
        }

        public void InsertAtFront(T value)
        {
            if (head == null && tail == null)
            {
                head = new LinkedListNode<T>(value);
                tail = head;
                count = 1;
            }
            else
            {
                head.Previous = new LinkedListNode<T>(value);
                head.Previous.Next = head;
                head = head.Previous;
                count++;
            }
        }

        public void InsertAtEnd(T value)
        {
            this.Add(value);
        }

        public bool RemoveAtIndex(int index)
        {
            if (index < 0 || index > count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                head.Next.Previous = null;
                head = head.Next;
                count--;
                return true;
            }

            if (index == count - 1)
            {
                tail.Previous.Next = null;
                tail = tail.Previous;
                count--;
                return true;
            }

            LinkedListNode<T> current;

            if (index > count / 2)
            {
                current = tail;

                for (int i = count - 1; i != index; i--)
                {
                    current = current.Previous;
                }
            }
            else
            {
                current = head;

                for (int i = 0; i != index; i++)
                {
                    current = current.Next;
                }
            }

            current.Previous.Next = current.Next;
            current.Next.Previous = current.Previous;
            count--;
            return true;
        }

        public bool RemoveAtFront()
        {
            if (head == tail)
            {
                if (head == null)
                {
                    return false;
                }

                head = null;
                tail = null;
                count = 0;
                return true;
            }

            head.Next.Previous = null;
            head = head.Next;
            count--;
            return true;
        }

        public bool RemoveAtEnd()
        {
            if (head == tail)
            {
                if (head == null)
                {
                    return false;
                }

                head = null;
                tail = null;
                count = 0;
                return true;
            }

            tail.Previous.Next = null;
            tail = tail.Previous;
            count--;
            return true;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        private class LinkedListNode<T>
        {
            private T value;
            private LinkedListNode<T> next;
            private LinkedListNode<T> previous;

            public T Value { get { return value; } set { this.value = value; } }
            public LinkedListNode<T> Next { get { return next; } set { next = value; } }
            public LinkedListNode<T> Previous { get { return previous; } set { previous = value; } }

            public LinkedListNode(T value)
            {
                this.value = value;
                next = null;
                previous = null;
            }
        }
    }
}
