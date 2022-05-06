namespace Tasks
{
    internal class Node<T>
    {
        public Node<T> NextNode { get; set; }
        public Node<T> PreviousNode { get; set; }
        public T Value { get; set; }

        public Node(Node<T> previousNode, T value, Node<T> nextNode)
        {
            NextNode = nextNode;
            PreviousNode = previousNode;
            Value = value;
        }
    }
}
