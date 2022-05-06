using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private IDoublyLinkedList<T> _list = new DoublyLinkedList<T>();

        public T Dequeue()
        {
            if (_list.Length == 0)
                throw new InvalidOperationException();
            return _list.RemoveAt(0);
        }

        public void Enqueue(T item)
        {
            _list.Add(item);
        }

        public T Pop()
        {
            if (_list.Length == 0)
                throw new InvalidOperationException();
            return _list.RemoveAt(_list.Length - 1);
        }

        public void Push(T item)
        {
            _list.Add(item);
        }
    }
}
