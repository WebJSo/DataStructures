using System.Collections.Generic;

namespace DataStructures.Node.Interfaces
{
    public interface ICustomQueue<T> : IBaseDataStructure, IEnumerable<T>
    {
        void Enqueue(T item);
        T Dequeue();
    }
}
