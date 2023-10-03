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

    public void insertNodeAtHead(int val)
    {
        Node newNode = new Node(val);
        if (Head == null)
        {
            Head = newNode;
            return;
        }
        newNode.Next = Head;
        Head = newNode;
    }

    public void AddNode(int val)
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

    public void RemoveNodeByPosition(int position)
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
            if (count == position)
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

    public void DisplayReverseLinkedList()
    {
        Node current = Head;
        Node previous = null;
        Node next = null;

        while (current != null)
        {
            next = current.Next;
            current.Next = previous;
            previous = current;
            current = next;
        }

        while (previous != null)
        {
            Console.Write($"{previous.Val}");
            if (previous.Next != null)
            {
                Console.Write(" -> ");
            }
            previous = previous.Next ?? null;
        }
        Console.WriteLine();

    }

    public void CompareList(Node head1, Node head2)
    {
        Node current1 = head1;
        Node current2 = head2;

        while (current1 != null && current2 != null)
        {
            if (current1.Val != current2.Val)
            {
                Console.WriteLine("Not Equal");
                return;
            }
            current1 = current1.Next;
            current2 = current2.Next;
        }
        Console.WriteLine("Equal");
    }

    public void MergeLists(Node head1, Node head2)
    {
        Node current1 = head1;
        Node current2 = head2;

        Node dummy = new Node(0);
        Node tail = dummy;

        while (true)
        {
            if (current1 == null)
            {
                tail.Next = current2;
                break;
            }
            if (current2 == null)
            {
                tail.Next = current1;
                break;
            }

            if (current1.Val <= current2.Val)
            {
                tail.Next = current1;
                current1 = current1.Next;
            }
            else
            {
                tail.Next = current2;
                current2 = current2.Next;
            }
            tail = tail.Next;
        }
        // DisplayLinkedList(dummy.Next);
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

    /*
        Given N dices each face ranging from 1 to 6, return the minimum number of rotations necessary for each dice show the same face.
Notice in one rotation you can rotate the dice to the adjacent face. 
For example you can rotate the dice shows 1 to show 2, 3, 4, or 5. 
But to make it show 6, you need two rotations.
    */

    public int MinDiceRotations(int[] A)
    {
        int[] count = new int[7];
        int res = Int32.MaxValue;
        for (int i = 0; i < A.Length; i++)
        {
            count[A[i]]++;
        }

        for (int i = 1; i <= 6; i++)
        {
            res = Math.Min(res, A.Length - count[i]);
        }
        return res;
    }


}