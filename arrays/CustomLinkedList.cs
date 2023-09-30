using System;

public class CustomLinkedList
{

    public Node Head;
    public class Node
    {

        public int Val;
        public Node Next;

        public Node(int val)
        {
            this.Val = val;
        }
    }

    // public void AddNode(int val)
    // {
    //     Node newNode = new Node(val);
    //     if (Head == null)
    //     {
    //         Head = newNode;
    //         return;
    //     }

    //     Node current = Head;
    //     while (current.Next != null)
    //     {
    //         current = current.Next;
    //     }
    //     current.Next = newNode;
    // }


    public void AddNewNode(int val)
    {
        Node newNode = new Node(val);

        if (Head == null)
        {
            Head = newNode;
            return;
        }

        Node current = Head;

        while (current.Next != null)
        {
            current = current.Next;
        }

        current.Next = newNode;
    }

    public void RemoveFirst()
    {
        if (Head == null)
        {
            return;
        }
        Head = Head.Next;
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
    }

    public void RemoveNode(int val)
    {
        if (Head == null)
        {
            return;
        }
        Node current = Head;
        while (current.Next != null)
        {
            if (current.Next.Val == val)
            {
                current.Next = current.Next.Next;
                return;
            }
            current = current.Next;
        }
    }

    public void InsertItemMiddle(int val, int position)
    {
        Node newNode = new Node(val);
        if (Head == null)
        {
            Head = newNode;
            return;
        }
        Node current = Head;
        int count = 0;
        while (current.Next != null)
        {
            count++;
            if (count == position)
            {
                newNode.Next = current.Next;
                current.Next = newNode;
                return;
            }
            current = current.Next;
        }
    }

    public void deleteBackHalf()
    {
        if (Head == null)
        {
            return;
        }
        Node current = Head;
        int count = 0;
        while (current.Next != null)
        {
            count++;
            current = current.Next;
        }
        current = Head;
        int mid = count / 2;
        count = 0;
        while (current.Next != null)
        {
            count++;
            if (count == mid)
            {
                current.Next = null;
                return;
            }
            current = current.Next;
        }
    }

    public void DisplayLinkedList()
    {
        Node current = Head;

        while (current != null)
        {
            Console.Write($"{current.Val}");
            if (current.Next != null)
            {
                Console.Write(" -> ");
            }
            current = current.Next ?? null;
        }
        Console.WriteLine();

    }

    public void DisplayReverseLinkedList(){
        Node current = Head;
        Node previous = null;
        Node next = null;

        while(current != null){
            next = current.Next;
            current.Next = previous;
            previous = current;
            current = next;
        }

        while(previous != null){
            Console.Write($"{previous.Val}");
            if (previous.Next != null)
            {
                Console.Write(" -> ");
            }
            previous = previous.Next ?? null;
        }
        Console.WriteLine();

    }


    public void DeleteKthNodeFromEndofTheList(int kthNode)
    {
        if (Head == null || kthNode == 0)
        {
            return;
        }

        Node first = Head;
        Node second = Head;

        // traverse from head node to kth node
        for (int i = 0; i <= kthNode; i++)
        {
            second = second.Next;
            if (second.Next == null)
            {
                if (i == kthNode - 1)
                {
                    Head = Head.Next;

                }
                return;
            }
        }


        while (second.Next != null)
        {
            first = first.Next;
            second = second.Next;
        }

        first.Next = first.Next.Next;
    }

    public void DeleteFirstNodeFromStart(int kthNode)
    {
        if (Head == null || kthNode == 0)
        {
            return;
        }

        Node first = Head;
        Node second = Head;


        int counter = 0;
        while (second.Next != null)
        {
            counter++;

            if (counter == kthNode)
            {

                first.Next = first.Next.Next;
                break;
            }
            first = first.Next;
            second = second.Next;
        }

    }


}