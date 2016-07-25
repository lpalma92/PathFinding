using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinding.Classes
{
    class Heap<T> where T: IComparable
    {
        T[] items;
        int currentItemCount;

        public Heap(int size)
        {
            items = new T[size];
        }

        public int Count
        {
            get { return currentItemCount; }
        }

        public void Add(T item)
        {
            items[currentItemCount - 1] = item;
            currentItemCount = items.Length;
        }

        public void Remove()
        {
            
        }

        public Node GetFirst()
        {
            return null;
        }

        public bool Contains(Node d)
        {
            return true;
        }
    }
}
