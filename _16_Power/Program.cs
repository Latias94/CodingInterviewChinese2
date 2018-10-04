using System;

namespace _16_Power
{
    class Program
    {
        // 面试题16：数值的整数次方
        // 题目：实现函数double Power(double base, int exponent)，求base的exponent
        // 次方。不得使用库函数，同时不需要考虑大数问题。
        static void Main(string[] args)
        {
            Console.WriteLine(Power1(2, 3));
        }

        private static double Power1(double thebase, int exponent)
        {
            if (thebase == 0) return 0;
            if (thebase == 1) return 1;
            double result;
            if (exponent < 0)
            {
                result = 1 / PowerWithoutCheckError2(thebase, -exponent);
            }
            else
            {
                result = PowerWithoutCheckError2(thebase, exponent);
            }

            return result;
        }

        // 迭代
        private static double PowerWithoutCheckError1(double thebase, int exponent)
        {
            double result = 1.0;
            for (int i = 0; i < exponent; i++)
            {
                result *= thebase;
            }

            return result;
        }

        // 累乘法
        // n 为偶数时， a^n = a^(n/2) * a^(n/2)
        // n 为奇数时， a^n = a^(n-1/2) * a^(n-1/2) * a
        // 递归要注意，小心栈溢出
        private static double PowerWithoutCheckError2(double thebase, int exponent)
        {
            if (exponent == 0) return 1;
            if (exponent == 1) return thebase;
            double result = PowerWithoutCheckError2(thebase, exponent >> 1);
            result *= result;
            // 如果是奇数
            if ((exponent & 1) == 1)
                result *= thebase;
            return result;
        }
    }
}