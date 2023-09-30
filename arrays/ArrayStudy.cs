using System;

namespace algori.arrays
{
    public class ArrayStudy
    {

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