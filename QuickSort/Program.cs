﻿using System;
using System.Collections.Generic;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {20, 5, 30, 10, 15, 6, 25, 12, 28};
            QuickSort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        private static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        private static void QuickSort(int[] arr, int left, int right)
        {
            if (left >= right) return;
            int j = Partition(arr, left, right);
            QuickSort(arr, left, j - 1);
            QuickSort(arr, j + 1, right);
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int i = left, j = right + 1;
            int pivot = arr[left];
            while (true)
            {
                while (arr[++i] < pivot)
                {
                    if (i == right) break;
                }

                while (arr[--j] > pivot)
                {
                    if (j == left) break;
                }

                if (i >= j) break;
                Exch(arr, i, j);
            }

            Exch(arr, left, j); // Put pivot a[j] into position 

            return j;
        }

        private static void Exch(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}