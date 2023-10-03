// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

using algori.arrays;

using static CustomLinkedList;
using static SolutionSinglyLinkedListNode;


/*

121. Best Time to Buy and Sell Stock
You are given an array prices where prices[i] is the price of a given stock on the ith day.
You want to maximize your profit by choosing a single day to buy one stock and 
choosing a different day in the future to sell that stock.
Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.

Example 1:

Input: prices = [7,1,5,3,6,4]
Output: 5
Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

Example 2:
Input: prices = [7,6,4,3,1]
Output: 0
Explanation: In this case, no transactions are done and the max profit = 0.

*/

static int BestTimeToBuyAndSellStock(int[] prices)
{
    int buy = 0;
    int sell = 0;
    int profit = 0;

    buy = prices[0];
    for (int i = 1; i < prices.Length; i++)
    {
        sell = prices[i];
        if (sell > buy)
        {
            profit = Math.Max(profit, sell - buy);
        }
        else
        {
            buy = sell;
        }


        // for (int j = i + 1; j < prices.Length; j++)
        // {
        //     if(prices[j] > prices[i])
        //         continue;
        //     if (prices[j] - prices[i] > profit)
        //     {
        //         buy = prices[i];
        //         sell = prices[j];
        //         profit = prices[j] - prices[i];
        //     }
        // }
    }
    return profit;

}

BestTimeToBuyAndSellStock(new int[] { 1,2 });


/*
The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

P   A   H   N
A P L S I I G
Y   I   R
And then read line by line: "PAHNAPLSIIGYIR"

Write the code that will take a string and make this conversion given a number of rows:

string convert(string s, int numRows);
 

Example 1:

Input: s = "PAYPALISHIRING", numRows = 3
Output: "PAHNAPLSIIGYIR"
Example 2:

Input: s = "PAYPALISHIRING", numRows = 4
Output: "PINALSIGYAHRPI"
Explanation:
P     I    N
A   L S  I G
Y A   H R
P     I
Example 3:

Input: s = "A", numRows = 1
Output: "A"
 

Constraints:

1 <= s.length <= 1000
s consists of English letters (lower-case and upper-case), ',' and '.'.
1 <= numRows <= 1000

*/

static string ZigZagConvert(string s, int numRows)
{
    if (numRows == 1)
    {
        return s;
    }

    string result = string.Empty;
    int cycleLength = 2 * numRows - 2;
    for (int i = 0; i < numRows; i++)
    {
        for (int j = 0; j + i < s.Length; j += cycleLength)
        {
            result += s[j + i];
            if (i != 0 && i != numRows - 1 && j + cycleLength - i < s.Length)
            {
                result += s[j + cycleLength - i];
            }
        }
    }

    return result;

}

Console.WriteLine(ZigZagConvert("PAYPALISHIRING", 3));
/*

5. Longest Palindromic Substring
Given a string s, return the longest 
palindromic
 
substring
 in s.

Example 1:

Input: s = "babad"
Output: "bab"
Explanation: "aba" is also a valid answer.
Example 2:

Input: s = "cbbd"
Output: "bb"
 

Constraints:

1 <= s.length <= 1000
s consist of only digits and English letters.
*/
LongestPalindrome("badad");
static string LongestPalindrome(string s)
{
    if (s.Length == 1)
    {
        return s;
    }

    string result = string.Empty;
    for (int i = 0; i < s.Length; i++)
    {
        for (int j = i + 1; j <= s.Length; j++)
        {
            string subString = s.Substring(i, j - i);
            if (IsPalindrome(subString))
            {
                if (subString.Length > result.Length)
                {
                    result = subString;
                }
            }
        }
    }

    return result;

}

static bool IsPalindrome(string subString)
{
    int i = 0;
    int j = subString.Length - 1;
    while (i < j)
    {
        if (subString[i] != subString[j])
        {
            return false;
        }
        i++;
        j--;
    }

    return true;
}


/*

Favorite Genres
Given a map Map<String, List<String>> userMap, where the key is a username and the value is a list of user's songs. Also given a map Map<String, List<String>> genreMap, where the key is a genre and the value is a list of songs belonging to this genre. The task is to return a map Map<String, List<String>>, where the key is a username and the value is a list of the user's favorite genres. Favorite genre is a genre with the most song.

Example :
Input:

userMap = {
   "David": ["song1", "song2", "song3", "song4", "song8"],
   "Emma":  ["song5", "song6", "song7"]
},
genreMap = {
   "Rock":    ["song1", "song3"],
   "Dubstep": ["song7"],
   "Techno":  ["song2", "song4"],
   "Pop":     ["song5", "song6"],
   "Jazz":    ["song8", "song9"]
}
Output:
{
   "David": ["Rock", "Techno"],
   "Emma":  ["Pop"]
}
Explanation:
David has 2 Rock, 2 Techno and 1 Jazz song. So he has 2 favorite genres.
Emma has 2 Pop and 1 Dubstep song. Pop is Emma's favorite genre.

*/


static Dictionary<string, List<string>> FavoriteGenres(Dictionary<string, List<string>> userMap, Dictionary<string, List<string>> genreMap)
{
    Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
    Dictionary<string, string> songToGenre = new Dictionary<string, string>();
    Dictionary<string, int> genreCount = new Dictionary<string, int>();

    foreach (var genre in genreMap)
    {
        foreach (var song in genre.Value)
        {
            songToGenre.Add(song, genre.Key);
        }
    }

    foreach (var user in userMap)
    {
        genreCount = new Dictionary<string, int>();

        foreach (var song in user.Value)
        {
            if (songToGenre.ContainsKey(song))
            {
                if (genreCount.ContainsKey(songToGenre[song]))
                {
                    genreCount[songToGenre[song]]++;
                }
                else
                {
                    genreCount.Add(songToGenre[song], 1);
                }
            }
        }

        int max = 0;
        foreach (var genre in genreCount)
        {
            if (genre.Value > max)
            {
                max = genre.Value;
            }
        }

        List<string> favoriteGenre = new List<string>();
        foreach (var genre in genreCount)
        {
            if (genre.Value == max)
            {
                favoriteGenre.Add(genre.Key);
            }
        }

        result.Add(user.Key, favoriteGenre);
    }

    return result;
}

Dictionary<string, List<string>> userMap = new Dictionary<string, List<string>>();
userMap.Add("David", new List<string>() { "song1", "song2", "song3", "song4", "song8" });
userMap.Add("Emma", new List<string>() { "song5", "song6", "song7" });

Dictionary<string, List<string>> genreMap = new Dictionary<string, List<string>>();
genreMap.Add("Rock", new List<string>() { "song1", "song3" });
genreMap.Add("Dubstep", new List<string>() { "song7" });
genreMap.Add("Techno", new List<string>() { "song2", "song4" });
genreMap.Add("Pop", new List<string>() { "song5", "song6" });
genreMap.Add("Jazz", new List<string>() { "song8", "song9" });

Dictionary<string, List<string>> favoriteGenres = FavoriteGenres(userMap, genreMap);
foreach (var item in favoriteGenres)
{
    Console.WriteLine(item.Key);
    foreach (var genre in item.Value)
    {
        Console.WriteLine(genre);
    }
    Console.WriteLine();
}

/*

Find the k post offices located closest to you, given your location and a list of locations of all post offices available.
Locations are given in 2D coordinates in [X, Y], where X and Y are integers.
Euclidean distance is applied to find the distance between you and a post office.
Assume your location is [m, n] and the location of a post office is [p, q], 
the Euclidean distance between the office and you is SquareRoot((m - p) * (m - p) + (n - q) * (n - q)).
K is a positive integer much smaller than the given number of post offices.

e.g.
Input
you: [0, 0]
post_offices: [[-16, 5], [-1, 2], [4, 3], [10, -2], [0, 3], [-5, -9]]
k = 3

Output 
[[-1, 2], [0, 3], [4, 3]]

*/

static int[,] KNearestPostOffices(int[,] postoffices, int[,] myLocation, int k)
{
    int[,] result = new int[k, 2];
    int[] distance = new int[postoffices.GetLength(0)];
    for (int i = 0; i < postoffices.GetLength(0); i++)
    {
        int dis = (int)Math.Sqrt(Math.Pow((myLocation[0, 0] - postoffices[i, 0]), 2) + Math.Pow((myLocation[0, 1] - postoffices[i, 1]), 2));
        if (dis < 0)
        {
            dis = dis * -1;
        }
        distance[i] = dis;
    }

    int[] tempDistance = new int[distance.Length];
    Array.Copy(distance, tempDistance, distance.Length);
    Array.Sort(tempDistance);
    for (int i = 0; i < k; i++)
    {
        for (int j = 0; j < distance.Length; j++)
        {
            if (tempDistance[i] == distance[j])
            {
                result[i, 0] = postoffices[j, 0];
                result[i, 1] = postoffices[j, 1];
                break;
            }
        }
    }


    return result;
}


var result = KNearestPostOffices(new int[,] { { -16, 5 }, { -1, 2 }, { 4, 3 }, { 10, -2 }, { 0, 3 }, { -5, -9 } }, new int[,] { { 0, 0 } }, 3);

for (int i = 0; i < result.GetLength(0); i++)
{
    for (int j = 0; j < result.GetLength(1); j++)
    {

        System.Console.Write($"{result[i, j]} ");

    }
    System.Console.WriteLine();
}


static int MinDiceRotations(int[] A)
{
    int[] count = new int[7];
    int res = Int32.MaxValue;
    for (int i = 0; i < A.Length; i++)
    {
        count[A[i]]++;
    }

    if (count[1] > 0 && count[6] > 0 && count[2] == 0 && count[3] == 0 && count[4] == 0 && count[5] == 0)
    {
        return Math.Max(count[1], count[6]);
    }

    for (int i = 1; i <= 6; i++)
    {
        res = Math.Min(res, A.Length - count[i]);
    }
    return res;
}

Console.WriteLine(MinDiceRotations(new int[] { 6, 6, 1 }));
// Console.WriteLine(MinDiceRotations(new int[] {6, 1, 5, 4 }));
// Console.WriteLine(MinDiceRotations(new int[] {6, 5, 4 }));


static void Hacker_SingleLinkedList()
{
    SolutionSinglyLinkedListNode sb = new SolutionSinglyLinkedListNode();
    SinglyLinkedList llist = new SinglyLinkedList();
    for (int i = 0; i < 5; i++)
    {

        SinglyLinkedListNode llist_head = sb.insertNodeAtHead(llist.head, System.Random.Shared.Next(100, 500));
        llist.head = llist_head;
    }

    sb.PrintSinglyLinkedList(llist.head, "\n");


}
// Hacker_SingleLinkedList();


static void PrintSprial()
{

    int[,] arr = new int[5, 5];
    int data = 0;
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            arr[i, j] = data++;
        }
    }


    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {

            Console.Write(arr[i, j].ToString().PadLeft(2, '0') + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();

    ArrayStudy arrayStudy = new ArrayStudy();
    // arrayStudy.PrintArrayInSprialAntiClockWise(arr, arr.GetLength(0), arr.GetLength(1));
    //   arrayStudy.PrintArrayInSprialClockWise(arr, arr.GetLength(0), arr.GetLength(1));



}


static void PrintArray(int i)
{
    Console.Write(i + " ");
}

static void BinarySearchArrayAndFindDuplicates()
{

    int[] arr = new int[] { 9, 5, 8, 6, 2, 4, 7, 1, 3, 6, 4, 5, 6, 7, 8 };

    ArrayStudy arrayStudy = new ArrayStudy();
    Array.ForEach(arr, PrintArray);
    Console.WriteLine();
    int[] sortedArray = arrayStudy.SortArryUsingSelectionSort(arr);
    Array.ForEach(sortedArray, PrintArray);
    Console.WriteLine();

}

static void SortAlgorithms()
{

    SortAlgorithms sort = new SortAlgorithms();
    int[] arr = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
    Array.ForEach(arr, PrintArray);
    Console.WriteLine();

    // int[] sortedArray = sort.SelectionSort(arr, arr.Length);
    // Array.ForEach(sortedArray, PrintArray);

    arr = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
    // int[] sortedArray = sort.BubbleSort(arr);

    // int[] sortedArray = sort.InsertionSort(arr);
    // Array.ForEach(sortedArray, PrintArray);
    // Console.WriteLine();

    // sort.InsertionSort(sortedArray);
    // Array.ForEach(sortedArray, PrintArray);
    // Console.WriteLine();

    // int[] sortedArray = sort.MergeSort(arr);
    // Array.ForEach(sortedArray, PrintArray);
    // sortedArray = sort.MergeSort(sortedArray);
    // Array.ForEach(sortedArray, PrintArray);


    int[] sortedArray = sort.QuickSortArray(arr);
    Array.ForEach(sortedArray, PrintArray);
    sortedArray = sort.QuickSortArray(sortedArray);
    Array.ForEach(sortedArray, PrintArray);
}

//SortAlgorithms();



// PrintSprial();
// BinarySearchArrayAndFindDuplicates();
// // {
// //     // List<int> result = new List<int>();
// //     // for (int i = 0; i < grades.Length; i++)
// //     // {
// //     //     if (grades[i] < 38)
// //     //     {
// //     //         result.Add(grades[i]);
// //     //     }
// //     //     else
// //     //     {
// //     //         int nextMultipleOfFive = grades[i] + (5 - grades[i] % 5);
// //     //         if (nextMultipleOfFive - grades[i] < 3)
// //     //         {
// //     //             result.Add(nextMultipleOfFive);
// //     //         }
// //     //         else
// //     //         {
// //     //             result.Add(grades[i]);
// //     //         }
// //     //     }
// //     // }

// //     // return result.ToArray();
// // }

// Console.WriteLine(LeetCode.Reverse(1534236469));
// //Console.WriteLine("Divide(1000, 10) " + LeetCode.Divide(1000, 10));
// // Console.WriteLine("Divide(7, -2) " + LeetCode.Divide(-1, 1));
// // Console.WriteLine("Divide(7, -2) " + LeetCode.Divide(7, -2));
// // Console.WriteLine("Hello, World!");

// // Console.WriteLine(" minimumNumber : " + HackerRank.minimumNumber(11, "#HackerRank"));
// // Console.WriteLine(" minimumNumber : " + HackerRank.minimumNumber(3, "Ab1"));
// // Console.WriteLine(" minimumNumber : " + HackerRank.minimumNumber(4, "4700"));

// Console.WriteLine(" minimumNumber : " + HackerRank.alternate("anoopabose"));

// static Node reverse(Node llist)
// {

//     Node current = llist;
//     Node previous = null;
//     Node next = null;

//     while(current != null){
//         next = current.Next;
//         current.Next = previous;
//         previous = current;
//         current = next;

//     }
//     return current;

// }

// /*
// * Complete the 'gradingStudents' function below.
// *
// * The function is expected to return an INTEGER_ARRAY.
// * The function accepts INTEGER_ARRAY grades as parameter.
// */

// // static List<int> gradingStudents(List<int> grades)
// // {
// //     List<int> results = new List<int>();

// //     foreach (var grade in grades)
// //     {
// //         if (grade < 38)
// //         {
// //             results.Add(grade);
// //         }
// //         else
// //         {
// //             int multiplesofFive = grade + (5 - grade % 5);
// //             if (multiplesofFive - grade < 3)
// //             {
// //                 results.Add(multiplesofFive);
// //             }
// //             else
// //             {
// //                 results.Add(grade);
// //             }
// //         }

// //     }

// //     return results;
// // }

// // foreach (var m in gradingStudents(new List<int> { 73, 67, 38, 33 }))
// // {
// //     Console.WriteLine(m);
// // }

// // static void DetectCycleInLinkedList()
// // {

// //     int position = 1;
// //     int[] arra1 = new int[] { 2, 4, 3 };
// //     CustomLinkedList list = new CustomLinkedList();
// //     for (int i = 0; i < arra1.Length; i++)
// //     {
// //         list.AddNewNode(arra1[i]);
// //     }

// //     //  list.InsertItemMiddle(1, 1);
// //     list.DisplayLinkedList();
// // }

// // // DetectCycleInLinkedList();


// // SampleDoubleLinkedList();

// // static void SampleDoubleLinkedList()
// // {

// //     DoubleLinkedList list = new DoubleLinkedList();
// //     int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// //     for (int i = 0; i < arr.Length; i++)
// //     {
// //         list.AddNewNode(arr[i]);
// //     }

// //     list.DisplayLinkedList();
// //     list.DisplayReverseLinkedList();

// // }

// // // ArrayStudy arrayStudy = new ArrayStudy();
// // // int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
// // // arrayStudy.ShiftArrayRight(arr, 5);
// // // Array.ForEach(arr, Console.WriteLine);


// // // // // arrayStudy.ShiftArrayElementsToLeftByOnePostion(arr);

// // // // arrayStudy.ShiftArrayRight(arr, 1);

// // // // Console.WriteLine("After shifting elements to left by one position");
// // // // foreach (int i in arr)
// // // // {
// // // //     Debug.Write(i + " ");
// // // // }


// // // arrayStudy.ShiftArrayLeft(arr, 2);
// // // Array.ForEach(arr, Console.WriteLine);


// // // ListNode list1 = new ListNode();
// // // ListNode list2 = new ListNode();

// // // int[] arra1 = new int[] { 2,4,3 };
// // // int[] arra2 = new int[] { 5,6,4 };
// // // for (int i = 0; i < arra1.Length; i++)
// // // {
// // //     list1 = new ListNode(arra1[i],new ListNode());   
// // //     list1 = list1.next;
// // // }


// // // for (int i = 0; i < arra2.Length; i++)
// // // {
// // //     list2.val = arra2[i];
// // //     list2.next = new ListNode();
// // //     list2 = list2.next;
// // // }


// // // Solution s1 = new Solution();
// // // ListNode result = s1.AddTwoNumbers(list1, list2);
// // // while (result != null)
// // // {
// // //     Console.WriteLine(result.val);
// // //     result = result.next;
// // // }


// // // int[] arr = { 7, 3, 4, 5, 5, 6,9, 2 ,9};
// // // PrintRepeatingNumber ps = new PrintRepeatingNumber();
// // // ps.PrintRepeatingNumbers(arr);



// // // Solution solution = new Solution();
// // // solution.CreateLinkedList();
// // // solution.DisplayLinkedList();


// // // CustomLinkedList customLinkedList = new CustomLinkedList();
// // // customLinkedList.AddNode(1);
// // // customLinkedList.AddNode(2);
// // // customLinkedList.AddNode(3);
// // // customLinkedList.AddNode(4);
// // // customLinkedList.AddNode(5);
// // // customLinkedList.AddNode(6);
// // // customLinkedList.AddNode(7);
// // // customLinkedList.AddNode(8);
// // // customLinkedList.InsertItemMiddle(5, 5);
// // // customLinkedList.DisplayLinkedList();
// // // //customLinkedList.DeleteKthNodeFromEndofTheList(5);
// // // customLinkedList.RemoveNode(5);

// // // // customLinkedList.DeleteFirstNodeFromStart(1);
// // // customLinkedList.DisplayLinkedList();
// // // Console.WriteLine();


// // // List<List<int>> arr = new List<List<int>>();
// // // for (int i = 0; i < 3; i++)
// // // {
// // //     arr.Add(new List<int>() { 0 + i, 0 + i, 0 + i });
// // // }

// // // // arr.Add(new List<int>() { 1, 1, 1, 0, 0, 0 });lis


// // // List<int> arr = new List<int>() { -4, 3, -9, 0, 4, 1 };

// // // double countOfPositives = arr.Count(x => x > 0);
// // // double ratioOfPositives = countOfPositives / arr.Count;

// // // double countOfNegatives = arr.Count(x => x < 0);
// // // double ratioOfNegatives = countOfNegatives / arr.Count;

// // // double countOfZeros = arr.Count(x => x == 0);
// // // double ratioOfZeroes = countOfZeros / arr.Count;

// // // Console.WriteLine(ratioOfPositives.ToString("0.000000"));
// // // Console.WriteLine(ratioOfNegatives.ToString("0.000000"));
// // // Console.WriteLine(ratioOfZeroes.ToString("0.000000"));


// // // int n = 5;
// // // string s = "#";
// // // for (int i = 1; i <= n; i++)
// // // {
// // //     Console.WriteLine(s.PadLeft(n));
// // //     s += "#";
// // // }

// // // string s = "12:00:00AM";
// // // string[] splitTime = s.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
// // // foreach (var item in splitTime)
// // // {
// // //     Console.WriteLine(item);
// // // }

// // // DateTime time = DateTime.Parse(s);
// // // Console.WriteLine(time.ToString("HH:mm:ss"));


// // // string s = "abacaba";
// // // //printlexicalorderforagivenstring("abacaba");
// // // Console.WriteLine(OrderStringInLexicalOrder("ab"));
// // // // void printlexicalorderforagivenstring(string s)
// // // // {
// // // //     List<string> result = new List<string>();
// // // //     for (int i = 0; i < s.Length; i++)
// // // //     {
// // // //         for (int j = i + 1; j <= s.Length; j++)
// // // //         {
// // // //             result.Add(s.Substring(i, j - i));
// // // //         }
// // // //     }

// // // //     result.Sort();
// // // //     foreach (var item in result)
// // // //     {
// // // //         Console.WriteLine(item);
// // // //     }
// // // // }


// // // Console.WriteLine(LexicographicallyGreaterString("ab"));
// // // Console.WriteLine(LexicographicallyGreaterString("bb"));
// // // Console.WriteLine(LexicographicallyGreaterString("hefg"));
// // // Console.WriteLine(LexicographicallyGreaterString("dhck"));
// // // Console.WriteLine(LexicographicallyGreaterString("dkhc"));

// // // string LexicographicallyGreaterString(string input)
// // // {
// // //     char[] chars = input.ToCharArray();
// // //     for (int i = 0; i < chars.Length; i++)
// // //     {
// // //         for (int j = i + 1; j < chars.Length; j++)
// // //         {
// // //             if (chars[i] > chars[j])
// // //             {
// // //                 char temp = chars[i];
// // //                 chars[i] = chars[j];
// // //                 chars[j] = temp;
// // //             }
// // //         }
// // //     }

// // //     return new string(chars);

// // // }


// // // int OrderStringInLexicalOrder(string s)
// // // {
// // //     List<string> result = new List<string>();
// // //     Console.WriteLine(s);
// // //     char[] chars = s.ToCharArray();
// // //     int count = 0;

// // //     for (int j = 0 + 1; j < chars.Length; j++)
// // //     {
// // //         int m = j + 1 < chars.Length ? j + 1 : j;
// // //         if (chars[j] >= chars[m])
// // //         {
// // //             continue;

// // //         }
// // //         else if (chars[j] < chars[m])
// // //         {
// // //             count++;
// // //             char temp = chars[j];
// // //             chars[j] = chars[m];
// // //             chars[m] = temp;
// // //         }

// // //     }

// // //     Console.WriteLine(new string(chars));

// // //     return count;
// // // }

// // // // convert string into the lexicographically smallest possible string in as few moves as possible. i.e alphabatical order.
// // // // string s = "abacaba";
// // // int count = 0;
// // // for (int i = 0; i < s.Length; i++)
// // // {
// // //     for (int j = i + 1; j < s.Length; j++)
// // //     {
// // //         if (s[i] > s[j])
// // //         {
// // //             count++;
// // //         }
// // //     }
// // // }




// // // List<int> candles = new List<int>() { 3, 2, 1, 3 };
// // // Console.WriteLine(birthdayCakeCandles(candles));

// // // static int birthdayCakeCandles(List<int> candles)
// // // {
// // //     int maxCandleHeight = 0;
// // //     for (int i = 0; i < candles.Count; i++)
// // //     {
// // //         int count = 1;

// // //         for (int j = i + 1; j < candles.Count; j++)
// // //         {

// // //             if (candles[i] == candles[j])
// // //             {
// // //                 count++;

// // //                 if (maxCandleHeight < count)
// // //                 {
// // //                     maxCandleHeight = count;
// // //                 }
// // //             }
// // //         }
// // //     }

// // //     return maxCandleHeight;

// // // }



// // // List<int> arr = new List<int>() { 793810624, 895642170, 685903712, 623789054, 468592370 };
// // // miniMaxSum(arr);

// // // static void miniMaxSum(List<int> arr)
// // // {
// // //     List<long> result = new List<long>();
// // //     long sum = arr.Sum(x => (long)x);
// // //     for (int i = 0; i < arr.Count; i++)
// // //     {
// // //         result.Add(sum - arr[i]);
// // //     }
// // //     Console.WriteLine(result.Min() + " " + result.Max());

// // // }


// // // int sumOfPrimaryDiagonal = 0;
// // // int sumOfSecondaryDiagonal = 0;

// // // for (int i = 0; i < arr.Count; i++)
// // // {
// // //     for (int j = 0; j < arr[i].Count; j++)
// // //     {
// // //         // Prinicpal Diagonal
// // //         if (i == j)
// // //         {
// // //             Console.WriteLine(arr[i][j]);
// // //             sumOfPrimaryDiagonal += arr[i][j];
// // //         }

// // //         // Secondary Diagonal
// // //         if (i + j == arr.Count - 1)
// // //         {
// // //             Console.WriteLine(arr[i][j]);
// // //             sumOfSecondaryDiagonal += arr[i][j];
// // //         }
// // //     }
// // // }

// // // return Math.Abs(sumOfPrimaryDiagonal - sumOfSecondaryDiagonal);


// // // compareTriplets(new List<int>() { 5, 6, 7 }, new List<int>() { 3, 6, 10 });

// // // static List<int> compareTriplets(List<int> a, List<int> b)
// // // {
// // //     List<int> result = new List<int>();
// // //     result.Add(0);
// // //     result.Add(0);

// // //     if (a != null && b != null && b.Count == a.Count)
// // //     {
// // //         for (int i = 0; i < a.Count; i++)
// // //         {

// // //             if (a[i] > b[i])
// // //             {
// // //                 result[0] += 1;
// // //             }
// // //             else if (a[i] < b[i])
// // //             {
// // //                 result[1] += 1;
// // //             }
// // //         }
// // //     }

// // //     return result;
// // // }