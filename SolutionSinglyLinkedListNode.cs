using System;

public class SolutionSinglyLinkedListNode
{

    public class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    public class SinglyLinkedList
    {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

    }

    public void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep)
    {
        while (node != null)
        {
            Console.Write(node.data);

            node = node.next;

            if (node != null)
            {
                Console.Write(sep);
            }
        }
    }

    public SinglyLinkedListNode insertNodeAtHead(SinglyLinkedListNode llist, int data)
    {
        SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);

        if (llist == null)
        {
            return newNode;
        }

        newNode.next = llist;
        return newNode;
    }
}