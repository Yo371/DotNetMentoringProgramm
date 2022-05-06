using System.Collections;
using System.Collections.Generic;

namespace Tasks
{
    internal class NodeEnumerator<T> : IEnumerator<T>
    {
        private Node<T> _headNode;
        private Node<T> _currentNode;

        public T Current => _currentNode.Value;
        object? IEnumerator.Current => _currentNode.Value;

        public NodeEnumerator(Node<T> headNode)
        {
            _headNode = headNode;
        }

        public bool MoveNext()
        {
            if (_currentNode == null)
            {
                _currentNode = _headNode;
            }
            else
            {
                _currentNode = _currentNode.NextNode;
            }

            return _currentNode != null;
        }

        public void Reset()
        {
            _currentNode = null;
        }

        public void Dispose()
        {
        }
    }
}
