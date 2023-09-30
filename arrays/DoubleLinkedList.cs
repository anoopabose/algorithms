using System;


// Create a double linked list
public class DoubleLinkedList
{

    public Node Head;
    public Node Tail;

    public class Node
    {
        public int Val;
        public Node Next;
        public Node Previous;

        public Node(int val)
        {
            this.Val = val;
        }
    }

    public void AddNewNode(int val)
    {
        Node newNode = new Node(val);

        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
            return;
        }

        Node current = Head;

        while (current.Next != null)
        {
            current = current.Next;
        }

        current.Next = newNode;
        newNode.Previous = current;
        Tail = newNode;
    }

    public void RemoveFirst()
    {
        if (Head == null)
        {
            return;
        }

        Head = Head.Next;
        Head.Previous = null;
    }

    public void RemoveLast()
    {
        if (Head == null)
        {
            return;
        }

        Node current = Head;

        while (current.Next.Next != null)
        {
            current = current.Next;
        }

        current.Next = null;
        Tail = current;
    }

    public void RemoveAt(int position)
    {
        if (Head == null)
        {
            return;
        }

        Node current = Head;

        while (current.Next != null && position > 1)
        {
            current = current.Next;
            position--;
        }

        current.Next = current.Next.Next;
        current.Next.Previous = current;
    }

    public void DisplayLinkedList()
    {
        Node current = Head;

        while (current != null)
        {
            if (current.Previous != null)
            {
                Console.Write("Previous : " + current.Previous.Val + " ");
            }
            Console.Write("Current: " + current.Val + " ");
            if (current.Next != null)
            {
                Console.Write("Next: " + current.Next.Val + " ");
            }
            Console.Write("->");
            current = current.Next;
            Console.WriteLine();
        }        
    }

    public void DisplayReverseLinkedList(){
        Node current = Tail;

        while(current != null){
            if(current.Previous != null){
                Console.Write("Previous: " + current.Previous.Val + " ");
            }
            Console.Write("Current: " + current.Val + " ");
            if(current.Next != null){
                Console.Write("Next: " + current.Next.Val + " ");
            }
            Console.Write("->");
            current = current.Previous;
            Console.WriteLine();
        }
    }

}