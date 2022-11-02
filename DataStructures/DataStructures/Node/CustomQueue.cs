using DataStructures.Node.Interfaces;

namespace DataStructures.Node
{
    /// <summary>
    /// Extends BaseDataStructure with add and remove implementations. Provide queue functionality and enumeration.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomQueue<T> : BaseDataStructure<T>, ICustomQueue<T>
    {
        public void Enqueue(T item)
        { 
            AddItem(item);
        }

        public T Dequeue()
        {
            // remove first item
            return RemoveItem();
        }

        protected override void AddItemSpecific(T item)
        {
            // updates _head on first pass, update next with new item
            _tail.Next = _tail.Add(item);

            // update _tail with new item
            _tail = _tail.Next;
        }

        // remove from the head using the remove from start method
        protected override T RemoveItemSpecific() => _head.RemoveStart();
    }
}
