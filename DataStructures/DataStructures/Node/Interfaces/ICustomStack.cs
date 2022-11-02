using System.Collections.Generic;

namespace DataStructures.Node.Interfaces
{
    public interface ICustomStack<T> : IBaseDataStructure, IEnumerable<T>
    {
        void Push(T item);
        T Pop();        
    }
}
