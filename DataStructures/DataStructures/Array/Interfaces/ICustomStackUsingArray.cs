using System;
using System.Collections.Generic;

namespace DataStructures.Array.Interfaces
{
    public interface ICustomStackUsingArray<T>: IEnumerable<T>
    {
        bool IsEmpty { get; }
        int Count { get; }
        void Clear();
        void Push(T item);
        T Pop();
        T Peek();        
        bool TryPeek(out T result);
        T[] ToArray();
        bool Contains(T item);
    }
}
