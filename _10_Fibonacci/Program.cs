using System;

namespace _10_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        // ====================方法1：递归====================
        private static ulong Fibonacci_Solution1(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;
            return Fibonacci_Solution1(n - 1) + Fibonacci_Solution1(n - 2);
        }

        // ====================方法2：循环====================
        private static ulong Fibonacci_Solution2(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;
            ulong fibNMinusOne = 1;
            ulong fibNMinusTwo = 0;
            ulong fibN = 0;
            for (int i = 2; i <= n; i++)
            {
                fibN = fibNMinusOne + fibNMinusTwo;
                fibNMinusTwo = fibNMinusOne;
                fibNMinusOne = fibN;
            }

            return fibN;
        }

        // 题目：一只青蛙一次可以跳上1级台阶，也可以跳上2级。求该青蛙跳上一个n级的台阶总共有多少种跳法。
        // 对于本题,前提只有 1 阶或者2 阶的跳法。
        // a.如果两种跳法，1阶或者2阶，那么假定第一次跳的是一阶，那么剩下的是n-1个台阶，跳法是f(n-1);
        // b.假定第一次跳的是2阶，那么剩下的是n-2个台阶，跳法是f(n-2)
        // c.由a\b假设可以得出总跳法为: f(n) = f(n-1) + f(n-2) 
        // d.然后通过实际的情况可以得出：只有一阶的时候 f(1) = 1 ,只有两阶的时候可以有 f(2) = 2
        // e.可以发现最终得出的是一个斐波那契数列：
        // 
        //            | 1, (n=1)
        //     f(n) = | 2, (n=2)
        //            | f(n-1)+f(n-2) ,(n>2,n为整数)
        // reference: https://github.com/leeguandong/Interview-code-practice-python/blob/master/%E5%89%91%E6%8C%87offer/%E9%9D%92%E8%9B%99%E8%B7%B3%E5%8F%B0%E9%98%B6.py
        private static ulong jumpFloor(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;
            ulong fibNMinusOne = 2;
            ulong fibNMinusTwo = 1;
            ulong fibN = 0;
            for (int i = 3; i <= n; i++)
            {
                fibN = fibNMinusOne + fibNMinusTwo;
                fibNMinusTwo = fibNMinusOne;
                fibNMinusOne = fibN;
            }

            return fibN;
        }

        // 题目：一只青蛙一次可以跳上1 级台阶，也可以跳上 2 级……它也可以跳上 n 级。求该青蛙跳上一个 n 级的台阶总共有多少种跳法
        // 可以用数学归纳法证明 f(n)=2^(n-1)
        // n=1 时，f(1)=1
        // n=2 时，f(2)=f(1)+f(0)=2
        // n=3 时，f(3)=f(2)+f(1)+f(0)=4
        // n=n 时，f(n)=f(n-1)+f(n-2)+...+f(n-n)=f(n-1)+..+f(1)+f(0)
        // n=n-1 时，f(n-1)=f(n-2)+f(n-3)+...+f(n-n)=f(n-2)+..+f(1)+f(0)
        // 相减得：f(n)-f(n-1)=f(n-1) => f(n)=2*f(n-1) => f(n)=2^(n-1) 
        private static ulong jumpFloorII(int n)
        {
            return Convert.ToUInt64(Math.Pow(2, n - 1));
        }
    }
}