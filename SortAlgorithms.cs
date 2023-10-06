using System;

public class SortAlgorithms
{


    /// <summary>
    /// Selection sort alogorithm complecit = O(n^2)
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public int[] SelectionSort(int[] arr, int length)
    {
        if (length < 2)
            return arr;

        int[] temp = new int[length];
        Array.Copy(arr, temp, length);
        for (int i = 0; i < temp.Length - 1; i++)
        {
            PrintArrayState(temp, "SelectionSort");
            int minIndex = i;
            for (int j = i + 1; j < temp.Length; j++)
            {
                PrintArrayState(temp, "\tSelectionSort");
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

    public int[] BubbleSort(int[] arr)
    {
        if (arr.Length < 2)
            return arr;

        int[] temp = new int[arr.Length];
        Array.Copy(arr, temp, arr.Length);

        for (int i = 0; i < temp.Length - 1; i++)
        {
            PrintArrayState(temp, "BubbleSort");

            for (int j = 0; j < temp.Length - 1 - i; j++)
            {
                PrintArrayState(temp, "\tBubbleSort");
                if (temp[j] > temp[j + 1])
                {
                    int tempData = temp[j];
                    temp[j] = temp[j + 1];
                    temp[j + 1] = tempData;
                }
            }


        }

        return temp;
    }

    public int[] InsertionSort(int[] arr)
    {
        if (arr.Length < 2)
            return arr;

        int[] temp = new int[arr.Length];
        Array.Copy(arr, temp, arr.Length);

        for (int i = 1; i < temp.Length; i++)
        {

            PrintArrayState(temp, "InsertionSort");
            int tempValue = temp[i];
            int j = i - 1;
            while (j >= 0 && temp[j] > tempValue)
            {
                temp[j + 1] = temp[j];
                j--;
                PrintArrayState(temp, "\tInsertionSort");
            }
            temp[j + 1] = tempValue;
        }

        return temp;
    }


    public int[] MergeSort(int[] arr)
    {

        if (arr.Length < 2)
            return arr;

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
            PrintArrayState(temp, "\tMergeSort");
            MergeSort(temp, v1, mid);
            PrintArrayState(temp, "\t\tMergeSort");
            MergeSort(temp, mid + 1, v2);
            Merge(temp, v1, mid, v2);
        }
    }

    private void Merge(int[] temp, int v1, int mid, int v2)
    {
        
        int[] tempArray = new int[v2 - v1 + 1];
        int i = v1;
        int j = mid + 1;
        int k = 0;
        while (i <= mid && j <= v2)
        {
            if (temp[i] < temp[j])
            {
                tempArray[k] = temp[i];
                i++;
            }
            else
            {
                tempArray[k] = temp[j];
                j++;
            }
            k++;
        }

        while (i <= mid)
        {
            tempArray[k] = temp[i];
            i++;
            k++;
        }

        while (j <= v2)
        {
            tempArray[k] = temp[j];
            j++;
            k++;
        }

        for (int l = v1; l <= v2; l++)
        {
            temp[l] = tempArray[l - v1];
        }
        PrintArrayState(temp, "\t\t\tMerge");

    }

    public int[] QuickSortArray(int[] arr){

            int[] temp = new int[arr.Length];
            Array.Copy(arr, temp, arr.Length);
            QuickSort(temp, 0, temp.Length - 1);
            return temp;
        }

        private void QuickSort(int[] temp, int start, int end)
        {

            if (start < end)
            {
                int pivot = Partition(temp, start, end);
                QuickSort(temp, start, pivot - 1);
                QuickSort(temp, pivot + 1, end);
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

    private void PrintArrayState(int[] temp, string method)
    {
        Console.Write($"{method} :: ");
        foreach (int i in temp)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}