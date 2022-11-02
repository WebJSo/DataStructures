using DataStructures.Node.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Node
{
    /// <summary>
    /// Abstract class to provide base functionality for more derived data structures. Uses Node class to navigate list, adding and removing items.
    /// Implements IEnumerable for enumeration.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseDataStructure<T> : IBaseDataStructure, IEnumerable<T>
    {
        protected Node<T> _head;
        protected Node<T> _tail;
        public int Count { get; set; }
        public bool IsEmpty => Count == 0;

        protected void AddItem(T item)
        {
            if (IsEmpty)
            {
                // create new node
                _head = _tail = new Node<T>(item);
            }
            else
            {
                // add items in derived class
                AddItemSpecific(item);
            }
            Count++;
        }

        protected T RemoveItem()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack Underflow");

            Count--;

            // remove item in derived class
            T item = RemoveItemSpecific();

            // reset nodes if no more items
            if (IsEmpty)
                _head = _tail = null;

            return item;
        }
        // add items in derived class
        protected abstract void AddItemSpecific(T item);
        // remove items in derived class
        protected abstract T RemoveItemSpecific();
        
        public IEnumerator<T> GetEnumerator()
        {
            // start at first item
            Node<T> currentItem = _head;

            // loop through items while there is a next
            while (currentItem != null)
            {
                yield return currentItem.Item;

                currentItem = currentItem.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected class Node<T>
        {
            public Node(T item) => Item = item;

            // store item value
            public T Item { get; set; }

            // link to next Node
            public Node<T> Next { get; set; }

            // link to previous node
            public Node<T> Previous { get; set; }

            public Node<T> Add(T item) => new Node<T>(item);

            public T RemoveStart()
            {
                // if last item return item value
                if (Next == null)
                    return Item;

                // store item to return
                T item = Item;

                // if available set to next item                
                Item = Next.Item;

                // if available set next to next's next
                if (Next.Next != null)
                    Next = Next.Next;                

                // return original item value
                return item;
            }

            public T RemoveEnd()
            {
                // if last item return item value
                if (Previous == null)
                    return Item;

                // store item to return
                T item = Item;

                // if previous item then remove next link                               
                Previous.Next = null;                

                // return original item value
                return item;
            }
        }
    }
}
