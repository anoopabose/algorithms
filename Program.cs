// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

using algori.arrays;

using static CustomLinkedList;

Console.WriteLine("Hello, World!");

// ArrayStudy arrayStudy = new ArrayStudy();
// int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
// arrayStudy.ShiftArrayRight(arr, 5);
// Array.ForEach(arr, Console.WriteLine);


// // // arrayStudy.ShiftArrayElementsToLeftByOnePostion(arr);

// // arrayStudy.ShiftArrayRight(arr, 1);

// // Console.WriteLine("After shifting elements to left by one position");
// // foreach (int i in arr)
// // {
// //     Debug.Write(i + " ");
// // }


// arrayStudy.ShiftArrayLeft(arr, 2);
// Array.ForEach(arr, Console.WriteLine);


// ListNode list1 = new ListNode();
// ListNode list2 = new ListNode();

// int[] arra1 = new int[] { 2,4,3 };
// int[] arra2 = new int[] { 5,6,4 };
// for (int i = 0; i < arra1.Length; i++)
// {
//     list1 = new ListNode(arra1[i],new ListNode());   
//     list1 = list1.next;
// }


// for (int i = 0; i < arra2.Length; i++)
// {
//     list2.val = arra2[i];
//     list2.next = new ListNode();
//     list2 = list2.next;
// }


// Solution s1 = new Solution();
// ListNode result = s1.AddTwoNumbers(list1, list2);
// while (result != null)
// {
//     Console.WriteLine(result.val);
//     result = result.next;
// }


// int[] arr = { 7, 3, 4, 5, 5, 6,9, 2 ,9};
// PrintRepeatingNumber ps = new PrintRepeatingNumber();
// ps.PrintRepeatingNumbers(arr);



// Solution solution = new Solution();
// solution.CreateLinkedList();
// solution.DisplayLinkedList();


// CustomLinkedList customLinkedList = new CustomLinkedList();
// customLinkedList.AddNode(1);
// customLinkedList.AddNode(2);
// customLinkedList.AddNode(3);
// customLinkedList.AddNode(4);
// customLinkedList.AddNode(5);
// customLinkedList.AddNode(6);
// customLinkedList.AddNode(7);
// customLinkedList.AddNode(8);
// customLinkedList.InsertItemMiddle(5, 5);
// customLinkedList.DisplayLinkedList();
// //customLinkedList.DeleteKthNodeFromEndofTheList(5);
// customLinkedList.RemoveNode(5);

// // customLinkedList.DeleteFirstNodeFromStart(1);
// customLinkedList.DisplayLinkedList();
// Console.WriteLine();


// List<List<int>> arr = new List<List<int>>();
// for (int i = 0; i < 3; i++)
// {
//     arr.Add(new List<int>() { 0 + i, 0 + i, 0 + i });
// }

// // arr.Add(new List<int>() { 1, 1, 1, 0, 0, 0 });lis


// List<int> arr = new List<int>() { -4, 3, -9, 0, 4, 1 };

// double countOfPositives = arr.Count(x => x > 0);
// double ratioOfPositives = countOfPositives / arr.Count;

// double countOfNegatives = arr.Count(x => x < 0);
// double ratioOfNegatives = countOfNegatives / arr.Count;

// double countOfZeros = arr.Count(x => x == 0);
// double ratioOfZeroes = countOfZeros / arr.Count;

// Console.WriteLine(ratioOfPositives.ToString("0.000000"));
// Console.WriteLine(ratioOfNegatives.ToString("0.000000"));
// Console.WriteLine(ratioOfZeroes.ToString("0.000000"));


// int n = 5;
// string s = "#";
// for (int i = 1; i <= n; i++)
// {
//     Console.WriteLine(s.PadLeft(n));
//     s += "#";
// }

// string s = "12:00:00AM";
// string[] splitTime = s.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
// foreach (var item in splitTime)
// {
//     Console.WriteLine(item);
// }

// DateTime time = DateTime.Parse(s);
// Console.WriteLine(time.ToString("HH:mm:ss"));


string s = "abacaba";
//printlexicalorderforagivenstring("abacaba");
Console.WriteLine(OrderStringInLexicalOrder("abacaba"));
// void printlexicalorderforagivenstring(string s)
// {
//     List<string> result = new List<string>();
//     for (int i = 0; i < s.Length; i++)
//     {
//         for (int j = i + 1; j <= s.Length; j++)
//         {
//             result.Add(s.Substring(i, j - i));
//         }
//     }

//     result.Sort();
//     foreach (var item in result)
//     {
//         Console.WriteLine(item);
//     }
// }

string OrderStringInLexicalOrder(string s)
{
    List<string> result = new List<string>();
    for (int i = 0; i < s.Length; i++)
    {
        for (int j = i + 1; j <= s.Length; j++)
        {
            result.Add(s.Substring(i, j - i));
        }
    }

    result.Sort();
    return result[0];
}

// convert string into the lexicographically smallest possible string in as few moves as possible. i.e alphabatical order.
// string s = "abacaba";
int count = 0;
for (int i = 0; i < s.Length; i++)
{
    for (int j = i + 1; j < s.Length; j++)
    {
        if (s[i] > s[j])
        {
            count++;
        }
    }
}

 


// List<int> candles = new List<int>() { 3, 2, 1, 3 };
// Console.WriteLine(birthdayCakeCandles(candles));

// static int birthdayCakeCandles(List<int> candles)
// {
//     int maxCandleHeight = 0;
//     for (int i = 0; i < candles.Count; i++)
//     {
//         int count = 1;

//         for (int j = i + 1; j < candles.Count; j++)
//         {

//             if (candles[i] == candles[j])
//             {
//                 count++;

//                 if (maxCandleHeight < count)
//                 {
//                     maxCandleHeight = count;
//                 }
//             }
//         }
//     }

//     return maxCandleHeight;

// }



// List<int> arr = new List<int>() { 793810624, 895642170, 685903712, 623789054, 468592370 };
// miniMaxSum(arr);

// static void miniMaxSum(List<int> arr)
// {
//     List<long> result = new List<long>();
//     long sum = arr.Sum(x => (long)x);
//     for (int i = 0; i < arr.Count; i++)
//     {
//         result.Add(sum - arr[i]);
//     }
//     Console.WriteLine(result.Min() + " " + result.Max());

// }


// int sumOfPrimaryDiagonal = 0;
// int sumOfSecondaryDiagonal = 0;

// for (int i = 0; i < arr.Count; i++)
// {
//     for (int j = 0; j < arr[i].Count; j++)
//     {
//         // Prinicpal Diagonal
//         if (i == j)
//         {
//             Console.WriteLine(arr[i][j]);
//             sumOfPrimaryDiagonal += arr[i][j];
//         }

//         // Secondary Diagonal
//         if (i + j == arr.Count - 1)
//         {
//             Console.WriteLine(arr[i][j]);
//             sumOfSecondaryDiagonal += arr[i][j];
//         }
//     }
// }

// return Math.Abs(sumOfPrimaryDiagonal - sumOfSecondaryDiagonal);


// compareTriplets(new List<int>() { 5, 6, 7 }, new List<int>() { 3, 6, 10 });

// static List<int> compareTriplets(List<int> a, List<int> b)
// {
//     List<int> result = new List<int>();
//     result.Add(0);
//     result.Add(0);

//     if (a != null && b != null && b.Count == a.Count)
//     {
//         for (int i = 0; i < a.Count; i++)
//         {

//             if (a[i] > b[i])
//             {
//                 result[0] += 1;
//             }
//             else if (a[i] < b[i])
//             {
//                 result[1] += 1;
//             }
//         }
//     }

//     return result;
// }