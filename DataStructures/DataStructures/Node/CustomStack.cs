using DataStructures.Node.Interfaces;

namespace DataStructures.Node
{
    /// <summary>
    /// Extends BaseDataStructure with add and remove implementations. Provide stack functionality and enumeration.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomStack<T> : BaseDataStructure<T>, ICustomStack<T>
    {        
        public void Push(T item)
        {
            AddItem(item);
        }

        public T Pop()
        {
            // remove item from the end
            return RemoveItem();
        }

        protected override void AddItemSpecific(T item)
        {            
            // store last item
            Node<T> storeTail = _tail;

            // updates _head on first pass, update next with new item
            _tail.Next = _tail.Add(item);

            // update _tail with new item
            _tail = _tail.Next;

            // update previous with stored item
            _tail.Previous = storeTail;
        }

        protected override T RemoveItemSpecific()
        {
            // remove from the tail using the remove from end method
            T item = _tail.RemoveEnd();

            // set current position to previous item
            _tail = _tail.Previous;

            return item;
        }
    }
}
