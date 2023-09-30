public class ListNode
{
    public int val { get; set; }
    public ListNode next { get; set; }
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

}


public class Solution
{
    public LinkedList<int> list;
    public void CreateLinkedList()
    {
        ; list = new LinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        list.AddLast(4);



    }

    public void DisplayLinkedList()
    {
        foreach (int i in list)
        {
            Console.Write(i + " -> ");
        }

        Console.WriteLine();
        while (list.Count > 0)
        {
            Console.Write(list.First.Value + " -> ");
            list.RemoveFirst();
        }
        Console.WriteLine();

        foreach (int i in list)
        {
            Console.Write(i + " -> ");
        }
        Console.WriteLine();

    }


    // https://leetcode.com/problems/add-two-numbers/
    // You are given two non-empty linked lists representing two non-negative integers. 
    // The digits are stored in reverse order, and each of their nodes contains a single digit. 
    // Add the two numbers and return the sum as a linked list.
    // You may assume the two numbers do not contain any leading zero, except the number 0 itself.
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var sumList = new ListNode();
        var current = sumList;
        int carry = 0, sum = 0;

        while (l1 != null || l2 != null || carry == 1)
        {
            var v1 = l1 == null ? 0 : l1.val;
            var v2 = l2 == null ? 0 : l2.val;
            sum = v1 + v2 + carry;
            carry = sum > 9 ? 1 : 0;
            sum = sum % 10;
            current.next = new ListNode(sum);

            current = current.next;
            l1 = l1 == null ? null : l1.next;
            l2 = l2 == null ? null : l2.next;
        }

        return sumList.next;
    }

}
