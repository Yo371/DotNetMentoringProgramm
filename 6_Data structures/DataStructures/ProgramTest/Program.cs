using Tasks;

var list = new DoublyLinkedList<int>();
list.Add(1);
list.Add(2);

list.Remove(4);

list.Print();

Console.WriteLine();