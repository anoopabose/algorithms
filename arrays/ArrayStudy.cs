using System;

namespace algori.arrays
{
    public class ArrayStudy
    {

        // Sort array using Binary Serach
        public int[] SortArryUsingBinarySerach(int[] arr)
        {
            int[] temp = new int[arr.Length];
            Array.Copy(arr, temp, arr.Length);
            Array.Sort(temp);
            return temp;
        }

        // Sort array using Selection Sort
        public int[] SortArryUsingSelectionSort(int[] arr)
        {
            int[] temp = new int[arr.Length];
            Array.Copy(arr, temp, arr.Length);
            for (int i = 0; i < temp.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < temp.Length; j++)
                {
                    if (temp[j] < temp[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int tempValue = temp[i];
                temp[i] = temp[minIndex];
                temp[minIndex] = tempValue;
            }
            return temp;
        }

        // Sort array using Bubble Sort
        public int[] SortArryUsingBubbleSort(int[] arr)
        {
            int[] temp = new int[arr.Length];
            Array.Copy(arr, temp, arr.Length);
            for (int i = 0; i < temp.Length - 1; i++)
            {
                for (int j = 0; j < temp.Length - 1 - i; j++)
                {
                    if (temp[j] > temp[j + 1])
                    {
                        int tempValue = temp[j];
                        temp[j] = temp[j + 1];
                        temp[j + 1] = tempValue;
                    }
                }
            }
            return temp;
        }

        // Sort array using Insertion Sort
        public int[] SortArryUsingInsertionSort(int[] arr)
        {
            int[] temp = new int[arr.Length];
            Array.Copy(arr, temp, arr.Length);
            for (int i = 1; i < temp.Length; i++)
            {
                int tempValue = temp[i];
                int j = i - 1;
                while (j >= 0 && temp[j] > tempValue)
                {
                    temp[j + 1] = temp[j];
                    j--;
                }
                temp[j + 1] = tempValue;
            }
            return temp;
        }

        // Sort array using Merge Sort
        public int[] SortArryUsingMergeSort(int[] arr)
        {
            int[] temp = new int[arr.Length];
            Array.Copy(arr, temp, arr.Length);
            MergeSort(temp, 0, temp.Length - 1);
            return temp;
        }

        private void MergeSort(int[] temp, int v1, int v2)
        {
            if (v1 < v2)
            {
                int mid = (v1 + v2) / 2;
                MergeSort(temp, v1, mid);
                MergeSort(temp, mid + 1, v2);
                Merge(temp, v1, mid, v2);
            }
        }

        private void Merge(int[] temp, int v1, int mid, int v2)
        {
            int[] tempArr = new int[v2 - v1 + 1];
            int i = v1;
            int j = mid + 1;
            int k = 0;
            while (i <= mid && j <= v2)
            {
                if (temp[i] < temp[j])
                {
                    tempArr[k] = temp[i];
                    i++;
                }
                else
                {
                    tempArr[k] = temp[j];
                    j++;
                }
                k++;
            }

            while (i <= mid)
            {
                tempArr[k] = temp[i];
                i++;
                k++;
            }

            while (j <= v2)
            {
                tempArr[k] = temp[j];
                j++;
                k++;
            }

            for (int l = v1; l <= v2; l++)
            {
                temp[l] = tempArr[l - v1];
            }
        }

        // Sort array using Quick Sort
        public int[] QuickSortArray(int[] arr){

            int[] temp = new int[arr.Length];
            Array.Copy(arr, temp, arr.Length);
            QuickSort(temp, 0, temp.Length - 1);
            return temp;
        }

        private void QuickSort(int[] temp, int v1, int v2)
        {

            if (v1 < v2)
            {
                int pivot = Partition(temp, v1, v2);
                QuickSort(temp, v1, pivot - 1);
                QuickSort(temp, pivot + 1, v2);
            }
            
        }

        private int Partition(int[] temp, int v1, int v2)
        {
            int pivot = temp[v2];
            int i = v1 - 1;
            for (int j = v1; j < v2; j++)
            {
                if (temp[j] < pivot)
                {
                    i++;
                    int tempValue = temp[i];
                    temp[i] = temp[j];
                    temp[j] = tempValue;
                }
            }
            int tempValue2 = temp[i + 1];
            temp[i + 1] = temp[v2];
            temp[v2] = tempValue2;
            return i + 1;            
        }

        // Sort array using Heap Sort
        // Sort array using Counting Sort
        // Sort array using Radix Sort
        // Sort array using Bucket Sort
        // Sort array using Shell Sort
        // Sort array using Tim Sort
        // Sort array using Comb Sort
        // Sort array using Pigeonhole Sort
        // Sort array using Cycle Sort
        // Sort array using Cocktail Sort
        // Sort array using Strand Sort
        // Sort array using Bitonic Sort
        // Sort array using Pancake Sort





        public void PrintArrayInSprialAntiClockWise(int[,] arr, int m, int n)
        {

            int top = 0;
            int bottom = m - 1;
            int left = 0;
            int right = n - 1;
            int dir = 0;

            while (right >= left && bottom >= top)
            {

                // Top to bottom
                if (dir == 0)
                {
                    for (int i = top; i <= bottom; i++)
                    {
                        Console.Write(arr[i, top].ToString().PadLeft(2, '0') + " ");
                    }
                    left++;
                }

                // Left to Right
                if (dir == 1)
                {
                    for (int i = left; i <= right; i++)
                    {
                        Console.Write(arr[bottom, i].ToString().PadLeft(2, '0') + " ");
                    }
                    bottom--;
                }

                if (dir == 2)
                {
                    for (int i = bottom; i >= top; i--)
                    {
                        Console.Write(arr[i, right].ToString().PadLeft(2, '0') + " ");
                    }
                    right--;
                }

                if (dir == 3)
                {
                    for (int i = right; i >= left; i--)
                    {
                        Console.Write(arr[top, i].ToString().PadLeft(2, '0') + " ");
                    }
                    top++;
                }

                dir = (dir + 1) % 4;
            }


            Console.WriteLine();

        }
        public void PrintArrayInSprialClockWise(int[,] arr, int m, int n)
        {

            int top = 0, bottom = m - 1, left = 0, right = n - 1;
            int dir = 0;

            while (left <= right && top <= bottom)
            {

                if (dir == 0)
                {
                    for (int i = left; i <= right; i++)
                    {
                        Console.Write(arr[top, i].ToString().PadLeft(2, '0') + " ");
                    }
                    top++;
                }

                if (dir == 1)
                {
                    for (int i = top; i <= bottom; i++)
                    {
                        Console.Write(arr[i, right].ToString().PadLeft(2, '0') + " ");
                    }
                    right--;
                }

                if (dir == 2)
                {
                    for (int i = right; i >= left; i--)
                    {
                        Console.Write(arr[bottom, i].ToString().PadLeft(2, '0') + " ");
                    }
                    bottom--;
                }

                if (dir == 3)
                {
                    for (int i = bottom; i >= top; i--)
                    {
                        Console.Write(arr[i, left].ToString().PadLeft(2, '0') + " ");
                    }
                    left++;
                }


                // for change direction!
                dir = (dir + 1) % 4;

            }

























            // int top = 0; int bottom = m - 1; int left = 0; int right = n - 1;
            // int dir = 0;

            // while (left <= right && top <= bottom)
            // {
            //     // Letf to Right
            //     if (dir == 0)
            //     {
            //         for (int i = left; i <= right; i++)
            //         {
            //             Console.Write(arr[top, i].ToString().PadLeft(2, '0') + " ");
            //         }
            //         top++;
            //     }

            //     // Right to Bottom
            //     if (dir == 1)
            //     {
            //         for (int i = top; i <= bottom; i++)
            //         {
            //             Console.Write(arr[i, right].ToString().PadLeft(2, '0') + " ");
            //         }
            //         right--;
            //     }

            //     if (dir == 2)
            //     {
            //         for (int i = right; i >= left; i--)
            //         {
            //             Console.Write(arr[bottom, i].ToString().PadLeft(2, '0') + " ");
            //         }
            //         bottom--;
            //     }

            //     if (dir == 3)
            //     {
            //         for (int i = bottom; i >= top; i--)
            //         {
            //             Console.Write(arr[i, left].ToString().PadLeft(2, '0') + " ");
            //         }
            //         left++;
            //     }

            //     dir = (dir + 1) % 4;

            // }

        }

        public void ShiftArrayRight(int[] arr, int shift)
        {
            int[] temp = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                temp[(i + shift) % arr.Length] = arr[i];
                Console.WriteLine($"i = {i} ((i + shift) % arr.Length = {(i + shift) % arr.Length} =  arr[i] = {arr[i]}");

            }
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = temp[i];
            }
        }

        public void ShiftArrayLeft(int[] arr, int shift)
        {
            int[] temp = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"i = {i} (i - shift + arr.Length) % arr.Length = {(i - shift + arr.Length) % arr.Length} =  arr[i] = {arr[i]}");
                temp[(i - shift + arr.Length) % arr.Length] = arr[i];
            }

            Array.Copy(temp, arr, arr.Length);
            // for (int i = 0; i < arr.Length; i++)
            // {
            //     arr[i] = temp[i];
            // }
        }

        public void ShiftArrayElementsToLeftByOnePostion(int[] arr)
        {
            int temp = arr[0];
            for (int i = 0; i < arr.Length - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            arr[arr.Length - 1] = temp;
        }

        public bool SearchIntArrayUsingLinearSearch(int[] arr, int key)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == key)
                {
                    return true;
                }
            }
            return false;
        }

        // Array if integers, search a key using binary search
        public bool searchIntegerArraysUsingBinarySearch(int[] arr, int key)
        {
            int low = 0;
            int high = arr.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (key == arr[mid])
                {
                    return true;
                }
                else if (key < arr[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return false;
        }

    }

}