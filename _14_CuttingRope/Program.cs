using System;

namespace _14_CuttingRope
{
    class Program
    {
        // 面试题14：剪绳子
        // 题目：给你一根长度为n绳子，请把绳子剪成m段（m、n都是整数，n>1并且m≥1）。
        // 每段的绳子的长度记为k[0]、k[1]、……、k[m]。k[0]*k[1]*…*k[m]可能的最大乘
        // 积是多少？例如当绳子的长度是8时，我们把它剪成长度分别为2、3、3的三段，此
        // 时得到最大的乘积18。
        // 做完可以尝试 LeetCode 343题：https://leetcode.com/problems/integer-break/description/
        static void Main(string[] args)
        {
            Console.WriteLine(MaxProductAfterCuttingSolution1(18));
            Console.WriteLine(MaxProductAfterCuttingSolution2(18));
        }

        // 跟面试题10的斐波那契数列差不多，切第一刀的时候有n-1个选择，也就是剪出来的
        // 第一段绳子可能长度分别为 1,2...,n-1。因此f(n)=max(f(i)*f(n-i))
        // 我们不知道哪个位置是最优的解法，只好所有可能都尝试一遍。从上往下分析问题，从下往上求解问题。
        // 时间复杂度：O(n2)。空间复杂度：O(n)
        private static int MaxProductAfterCuttingSolution1(int length)
        {
            if (length <= 1) return 0;
            if (length == 2) return 1;
            if (length == 3) return 2;
            // 一位数组存小问题的最优解
            int[] products = new int[length + 1];
            products[0] = 0;
            products[1] = 1;
            products[2] = 2;
            products[3] = 3;
            // 存某个长度的最优解
            int max;
            for (int i = 4; i <= length; i++)
            {
                max = 0;
                // 遍历所有可能的长度，5的话一段绳子可能是1-2，那另一段的可能性就是1-4
                for (int j = 1; j <= i / 2; j++)
                {
                    int product = products[j] * products[i - j];
                    if (max < product) // 比较乘积最大值，并存在数组中
                        max = product;
                    products[i] = max;
                }
            }

            return products[length];
        }

        // 贪婪算法
        // 长度n>=5 时，尽可能多剪长度为 3 的绳子
        // 长度n==4 时，剪两段长度为 2 的绳子
        // 证明：2(n-2)>n 3(n-3)>n 都在 n>=5 时成立，且3(n-3)>=2(n-2)
        // 因此要尽可能多剪长度为 3 的绳子
        // 时间和空间复杂度为 O(1)
        private static int MaxProductAfterCuttingSolution2(int length)
        {
            if (length <= 1) return 0;
            if (length == 2) return 1;
            if (length == 3) return 2;
            int timesOf3 = length / 3;
            // 与其 3*3*3*..*3*1 不如 3*3*3*...*2*2 大，因为2*2>3*1
            if (length - timesOf3 * 3 == 1)
                timesOf3 -= 1;
            int timesOf2 = (length - timesOf3 * 3) / 2;
            return (int) Math.Pow(3, timesOf3) * (int) Math.Pow(2, timesOf2);
        }
    }
}