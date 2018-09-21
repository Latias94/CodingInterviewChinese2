using System;

namespace _11_MinNumberInRotatedArray
{
    class Program
    {
        // 面试题11：旋转数组的最小数字
        // 题目：把一个数组最开始的若干个元素搬到数组的末尾，我们称之为数组的旋转。
        // 输入一个递增排序的数组的一个旋转，输出旋转数组的最小元素。例如数组
        // {3, 4, 5, 1, 2}为{1, 2, 3, 4, 5}的一个旋转，该数组的最小值为1。
        static void Main(string[] args)
        {
            int[] arr = {3, 4, 5, 1, 2};
            Console.WriteLine(MinNumberInRotateArray1(arr)); // 1
            Console.WriteLine(MinNumberInRotateArray2(arr)); // 1
        }

        // O(n) 但没有利用输入的旋转数组的特性
        private static int MinNumberInRotateArray1(int[] rotateArray)
        {
            int current = rotateArray[0];
            for (int i = 1; i < rotateArray.Length; i++)
            {
                if (current < rotateArray[i])
                {
                    current = rotateArray[i];
                }
                else
                {
                    return rotateArray[i];
                }
            }

            return 0;
        }

        // 二分查找的思路 两个指针分别指向数组的第一个和最后一个元素
        private static int MinNumberInRotateArray2(int[] rotateArray)
        {
            int left = 0, right = rotateArray.Length - 1;
            int mid = 0;
            while (rotateArray[left] >= rotateArray[right])
            {
                // 如果两指针相邻，那么前一个指针指向的是前面递增子数组的末尾，
                // 而后一个指针指向的是旋转子数组的开头，也就是要找的目标
                if (right - left == 1)
                {
                    return rotateArray[right];
                }

                mid = (right + left) / 2;
                // 如果该中间元素位于前面的递增子数组，那么它应该大于或者等于第一个指针指向的元素。
                if (rotateArray[mid] >= rotateArray[left])
                {
                    left = mid;
                }
                else
                {
                    // 如果不是，它应该小于或者等于第二个指针指向的元素
                    right = mid;
                }
            }

            return rotateArray[mid];
        }
    }
}