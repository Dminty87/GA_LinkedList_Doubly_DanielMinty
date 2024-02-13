using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_LinkedList_Doubly_DanielMinty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();

            list.Add("Zero");
            list.Add("One");
            list.Add("Two");
            list.Add("Three");
            list.Add("Four");
            list.Add("Five");

            list.DisplayForward();

            list.DisplayBackward();

            for (int i = 0; i <= list.Count - 1; i++)
            {
                Console.WriteLine(list[i]);
            }

            list.Clear();

            list.DisplayForward();

            list.DisplayBackward();

            for (int i = 0; i <= list.Count - 1; i++)
            {
                Console.WriteLine(list[i]);
            }

            Console.ReadLine();
        }
    }
}
