using System;

namespace _12_StringPathInMatrix
{
    class Program
    {
        // 面试题12：矩阵中的路径
        // 题目：请设计一个函数，用来判断在一个矩阵中是否存在一条包含某字符串所有
        // 字符的路径。路径可以从矩阵中任意一格开始，每一步可以在矩阵中向左、右、
        // 上、下移动一格。如果一条路径经过了矩阵的某一格，那么该路径不能再次进入
        // 该格子。例如在下面的3×4的矩阵中包含一条字符串“bfce”的路径（路径中的字
        // 母用下划线标出）。但矩阵中不包含字符串“abfb”的路径，因为字符串的第一个
        // 字符b占据了矩阵中的第一行第二个格子之后，路径不能再次进入这个格子。
        // A B T G
        // C F C S
        // J D E H
        static void Main(string[] args)
        {
            string matrix = "ABTGCFCSJDEH";
            bool result = HasPath(matrix, 3, 4, "BFCE");
            Console.WriteLine(result);
        }

        // 回溯法
        private static bool HasPath(string matrix, int rows, int cols, string path)
        {
            if (matrix.Length == 0 || rows == 0 || cols == 0 || path.Length == 0) return false;
            // 路径不能重复进入矩阵的格子，所以定义矩阵来标识路径是否已经进入了每个格子
            bool[] visited = new bool[rows * cols];
            int pathLength = 0;
            // 双重循环找起点
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (FindPath(matrix, rows, cols, row, col, path, ref pathLength, visited))
                    {
                        // 找到了
                        return true;
                    }
                }
            }

            return false;
        }

        // 给定起点后递归地查找路径
        private static bool FindPath(string matrix, int rows, int cols,
            int row, int col, string path, ref int pathLength, bool[] visited)
        {
            // 如果当前找到路径长度已经等于需要的路径长度，说明已经找到所有路径
            if (path.Length == pathLength) return true;
            bool hasPath = false;
            // 行列数在范围内，且矩阵中查到的字符和所给路径的相应字符相等
            // 且矩阵的当前格子尚未进入过
            if (row >= 0 && row < rows && col >= 0 && col < cols &&
                matrix[row * cols + col] == path[pathLength] && !visited[row * cols + col])
            {
                pathLength++;
                visited[row * cols + col] = true;
                // 递归地在当前格子的上下左右来找
                hasPath = FindPath(matrix, rows, cols, row, col - 1, path, ref pathLength, visited) ||
                          FindPath(matrix, rows, cols, row - 1, col, path, ref pathLength, visited) ||
                          FindPath(matrix, rows, cols, row, col + 1, path, ref pathLength, visited) ||
                          FindPath(matrix, rows, cols, row + 1, col, path, ref pathLength, visited);
                if (!hasPath)
                {
                    // 找不到就退回上一个格子
                    pathLength--;
                    visited[row * cols + col] = false;
                }
            }

            return hasPath;
        }
    }
}