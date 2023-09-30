

using System;

class PrintRepeatingNumber
{

    public ListNode DetectCycle(ListNode head)
    {

        if (head == null)
            return head;

        ListNode matchNode = null;

        ListNode slow = head;
        ListNode fast = head;

        while (fast != null & fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast)
            {
                Console.WriteLine(slow.val + " => " + fast.val);
                matchNode = slow;
                break;
            }
        }

        if (matchNode == null)
        {
            return null;
        }
        slow = head;

        while (slow != fast)
        {
            Console.WriteLine(slow.val + " => " + fast.val);
            slow = slow.next;
            fast = fast.next;
        }


        return slow;

    }
    public void PrintRepeatingNumbers(int[] arr)
    {

 
        int[] temp = new int[arr.Max()];
        for (int i = 0; i < arr.Length; i++)
        {
            temp[arr[i] - 1] += 1;
            if (temp[arr[i] - 1] > 1)
            {
                System.Console.WriteLine("Repeating number is " + arr[i]);
            }

        }

        for (int i = 0; i < temp.Length - 1; i++)
        {
            if (temp[i] == 0)
            {
                System.Console.WriteLine("missing number is " + (i + 1));
            }
        }

        // Dictionary<int, int> dict = new Dictionary<int, int>();
        // for (i = 0; i < arr.Length; i++)
        // {
        //     if (dict.ContainsKey(arr[i]))
        //     {
        //         dict[arr[i]] = dict[arr[i]] + 1;
        //     }
        //     else
        //     {
        //         dict.Add(arr[i], 1);
        //     }
        // }




        // foreach(var keyValue in dict)
        // {
        //     if (keyValue.Value > 1)
        //     {
        //         Console.WriteLine(keyValue.Key);
        //          var sum = dict.Keys.Sum(x=> x)/2 = keyValue.Key;
        //     }
        // }
        // kjshdfkljghsdklj



    }



}