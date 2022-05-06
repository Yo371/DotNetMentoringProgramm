using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {

        private Node<T> _headNode;
        private Node<T> _tailNode;

        public int Length { get; private set; }

        public void Add(T e)
        {
            if (Length == 0)
            {
                _headNode = new Node<T>(null, e, null);
                _tailNode = _headNode;
                Length++;
            }
            else
            {
                var node = new Node<T>(_tailNode, e, null);
                _tailNode.NextNode = node;
                _tailNode = node;
                Length++;
            }
        }

        public void AddAt(int index, T e)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException($"{index} index is out of range!");
            }

            var node = new Node<T>(null, e, null);

            if (Length == 0 && index == 0)
            {
                _headNode = node;
            }
            else if (Length != 0 && index == 0)
            {
                node.NextNode = _headNode;
                _headNode.PreviousNode = node;
                _headNode = node;
            }
            else if (Length == index)
            {
                _tailNode.NextNode = node;
                node.PreviousNode = _tailNode;
                _tailNode = node;
            }
            else
            {
                var currentNode = NodeAt(index);

                node.NextNode = currentNode.PreviousNode.NextNode; 
                node.PreviousNode = currentNode.PreviousNode;
                currentNode.PreviousNode.NextNode = node;
                currentNode.PreviousNode = node;
            }

            Length++;
        }

        public T ElementAt(int index)
        {
            CheckIndex(index);
            return NodeAt(index).Value;
        }

        public IEnumerator<T> GetEnumerator() => new NodeEnumerator<T>(_headNode);

        public void Remove(T item)
        {
            if(_headNode == null) return;

            if (_headNode.Value.Equals(item))
            {
                RemoveHeadNode();
            }
            else if (_tailNode.Value.Equals(item))
            {
                RemoveTailNode();
            }
            else
            {
                var currentNode = _headNode.NextNode;

                while (currentNode != null)
                {
                    if (currentNode.Value.Equals(item))
                    {
                        RemoveNode(currentNode);
                    }
                    currentNode = currentNode.NextNode;
                }
            }
        }

        public T RemoveAt(int index)
        {
            CheckIndex(index);

            var node = _headNode;
            if (index == 0)
            {
                RemoveHeadNode();
            }
            else if (index == Length - 1)
            {
                node = _tailNode;
                RemoveTailNode();
            }
            else
            {
                node = NodeAt(index);
                RemoveNode(node);
            }

            return node.Value;
        }

        private Node<T> NodeAt(int index)
        {
            var node = _headNode;

            for (int i = 0; i < index; i++)
                node = node.NextNode;

            return node;
        }

        private void CheckIndex(int index)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException($"{index} index is out of range!");
            }
        }

        public void Print()
        {
            var currentNode = _headNode;

            while (currentNode.NextNode != null)
            {
                Console.Write($"<- |{currentNode.Value}| ->");
                currentNode = currentNode.NextNode;
            }
            Console.Write($"<- |{currentNode.Value}| ->");
        }

        private void RemoveNode(Node<T> node)
        {
            node.PreviousNode.NextNode = node.NextNode;
            node.NextNode.PreviousNode = node.PreviousNode;
            Length--;
        }

        private void RemoveHeadNode()
        {
            _headNode.NextNode.PreviousNode = null;
            _headNode = _headNode.NextNode;
            Length--;
        }

        private void RemoveTailNode()
        {
            _tailNode.PreviousNode.NextNode = null;
            _tailNode = _tailNode.PreviousNode;
            Length--;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
