using System;

public class CircularLinkedList {

    public Node Head;
    public class Node {

        public int Val;
        public Node Next;

        public Node (int val) {
            this.Val = val;
        }
    }

    public void AddNewNode (int val) {
        Node newNode = new Node (val);

        if (Head == null) {
            Head = newNode;
            return;
        }

        Node current = Head;

        while (current.Next != null) {
            current = current.Next;
        }

        current.Next = newNode;
    }

    public void RemoveFirst () {
        if (Head == null) {
            return;
        }

        Head = Head.Next;
    }

    public void RemoveLast () {
        if (Head == null) {
            return;
        }

        Node current = Head;

        while (current.Next.Next != null) {
            current = current.Next;
        }

        current.Next = null;
    }

    public void RemoveAt (int position) {
        if (Head == null) {
            return;
        }

        Node current = Head;
        Node previous = null;
        int count = 0;

        while (current.Next != null && count < position) {
            previous = current;
            current = current.Next;
            count++;
        }

        previous.Next = current.Next;
    }

    public void InsertAt (int position, int val) {
        Node newNode = new Node (val);

        if (Head == null) {
            Head = newNode;
            return;
        }

        Node current = Head;
        Node previous = null;
        int count = 0;

        while (current.Next != null && count < position) {
            previous = current;
            current = current.Next;
            count++;
        }

        previous.Next = newNode;
        newNode.Next = current;
    }

    public void DisplayLinkedList () {
        Node current = Head;

        while (current != null) {
            Console.Write (current.Val + " ");
            current = current.Next;
        }
    }

    public void ReverseLinkedList () {
        Node current = Head;
        Node previous = null;
        Node next = null;

        while (current != null) {
            next = current.Next;
            current.Next = previous;
            previous = current;
            current = next;
        }

        Head = previous;
    }

    public void DetectCycle(){
        Node slow = Head;
        Node fast = Head;

        while(fast != null && fast.Next != null){
            slow = slow.Next;
            fast = fast.Next.Next;

            if(slow == fast){
                Console.WriteLine("Cycle detected");
                return;
            }
        }

        Console.WriteLine("No cycle detected");
    }

}