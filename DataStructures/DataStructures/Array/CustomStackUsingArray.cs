using DataStructures.Array.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Array
{
    /// <summary>
    /// Class to create a stack using a fixed size array to emulate adding and removing elements.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomStackUsingArray<T> : ICustomStackUsingArray<T>
    {
        private int _top;
        private T[] _stack;
        private readonly int _capacity;

        public CustomStackUsingArray(int capacity)
        {
            // max allowed size of array
            _capacity = capacity;

            // initialise array of T
            _stack = new T[capacity];
        }

        public CustomStackUsingArray(IEnumerable<T> stack)
        {
            // max allowed size of array
            _capacity = stack.Count();

            // set top to end
            _top = _capacity;

            // assign stack
            _stack = stack.ToArray();
        }

        public void Clear() => _top = 0;

        public T[] ToArray() => _stack;

        public bool IsEmpty => _top == 0;
        public int Count => _top;

        public void Push(T item)
        {
            // cant add anymore items
            if (_top == _capacity)
                throw new StackOverflowException("Stack Overflow");

            // add item by index
            _stack[_top] = item;

            // increment index
            _top++;
        }

        public T Pop()
        {
            // no items to remove
            if (IsEmpty)
                throw new InvalidOperationException("Stack Underflow");

            // decrement index
            _top--;

            // return top item
            return _stack[_top];
        }

        public T Peek()
        {
            // no items to get
            if (IsEmpty)
                throw new InvalidOperationException("Stack Underflow");

            // get top result
            return _stack[_top - 1];
        }

        public bool TryPeek(out T result)
        {
            // no items to get
            if (IsEmpty)
            {
                result = default;

                return false;
            }

            // get top result
            result = _stack[_top - 1];

            // result found
            return true;
        }
        
        public bool Contains(T item)
        {
            foreach(var itemInArray in _stack)
            {
                if (itemInArray.Equals(item))
                    return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            // iterate to top value
            for (int i = 0; i < _top; i++)
            {
                // return each item in array
                yield return _stack[i];
            }            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
