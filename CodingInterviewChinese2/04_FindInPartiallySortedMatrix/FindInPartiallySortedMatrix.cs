using System;

namespace CodingInterviewChinese2._04_FindInPartiallySortedMatrix
{
    class FindInPartiallySortedMatrix
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[][] array = new int[4][];
            array[0] = new int[] {1, 2, 8, 9};
            array[1] = new int[] {2, 4, 9, 12};
            array[2] = new int[] {4, 7, 10, 13};
            array[3] = new int[] {6, 8, 11, 15};
            Console.WriteLine(Find(1, array));
        }

        // 面试题4：二维数组中的查找
        // 题目：在一个二维数组中，每一行都按照从左到右递增的顺序排序，每一列都按
        // 照从上到下递增的顺序排序。请完成一个函数，输入这样的一个二维数组和一个
        // 整数，判断数组中是否含有该整数。
        public static bool Find(int target, int[][] array)
        {
            if (array.Length == 0 || array[0].Length == 0) return false;
            // 当前行数
            int row = 0;
            // 最大行数
            int rows = array.Length;
            // 当前列数
            int column = array[0].Length - 1;
            while (row < rows && column >= 0)
            {
                if (array[row][column] != target)
                {
                    Console.WriteLine("{0},{1}", row, column);
                    if (array[row][column] < target)
                    {
                        row++;
                    }
                    else if (array[row][column] > target)
                    {
                        column--;
                    }
                }
                else
                {
                    return true;
                }
            }

            return false;
        }
    }
}