using System;

namespace _13_RobotMove
{
    class Program
    {
        // 面试题13：机器人的运动范围
        // 题目：地上有一个m行n列的方格。一个机器人从坐标(0, 0)的格子开始移动，它
        // 每一次可以向左、右、上、下移动一格，但不能进入行坐标和列坐标的数位之和
        // 大于k的格子。例如，当k为18时，机器人能够进入方格(35, 37)，因为3+5+3+7=18。
        // 但它不能进入方格(35, 38)，因为3+5+3+8=19。请问该机器人能够到达多少个格子？
        static void Main(string[] args)
        {
            Console.WriteLine(MovingCount(5, 10, 10)); // 21
            Console.WriteLine(MovingCount(18, 40, 40)); // 1484
        }
        // 和面试题 12 思路类似，用回溯法。
        private static int MovingCount(int threshold, int rows, int cols)
        {
            if (threshold == 0 || rows == 0 || cols == 0) return 0;
            // 路径不能重复进入矩阵的格子，所以定义矩阵来标识路径是否已经进入了每个格子
            bool[] visited = new bool[rows * cols];
            return FindPath(threshold, rows, cols, 0, 0, visited);
        }

        private static int FindPath(int threshold, int rows, int cols, int row, int col, bool[] visited)
        {
            if (!Check(threshold, rows, cols, row, col, visited)) return 0;
            visited[row * cols + col] = true;
            // 脚下的格子+ 尝试上下左右的格子能不能走
            int count = 1 +
                        FindPath(threshold, rows, cols, row, col - 1, visited) +
                        FindPath(threshold, rows, cols, row, col + 1, visited) +
                        FindPath(threshold, rows, cols, row - 1, col, visited) +
                        FindPath(threshold, rows, cols, row + 1, col, visited);
            return count;
        }

        // 计算格子能不能走
        private static bool Check(int threshold, int rows, int cols, int row, int col, bool[] visited)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols &&
                   GetDigitSum(row) + GetDigitSum(col) <= threshold &&
                   !visited[row * cols + col];
        }

        // 计算行坐标和列坐标的数位之和
        private static int GetDigitSum(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }

            return sum;
        }
    }
}