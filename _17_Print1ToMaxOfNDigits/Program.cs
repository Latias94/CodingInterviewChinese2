using System;

namespace _17_Print1ToMaxOfNDigits
{
    class Program
    {
        // 面试题17：打印1到最大的n位数
        // 题目：输入数字n，按顺序打印出从1最大的n位十进制数。比如输入3，则
        // 打印出1、2、3一直到最大的3位数即999。
        public static void Main(string[] args)
        {
//            Print1ToMaxOfNDigits1(3);
            Print1ToMaxOfNDigits2(3);
        }

        // 方法一 迭代
        private static void Print1ToMaxOfNDigits1(int n)
        {
            if (n <= 0) return;
            char[] number = new char[n];
            for (int i = 0; i < number.Length; i++)
            {
                number[i] = '0';
            }

            while (!Increment(number))
            {
                PrintNumber(number);
            }
        }

        // 字符串number表示一个数字，在 number上增加1
        // 如果做加法溢出，则返回true；否则为false
        private static bool Increment(char[] number)
        {
            bool isOverflow = false;
            int nTakeOver = 0;
            int length = number.Length;
            // 从个位开始计算
            for (int i = length - 1; i >= 0; i--)
            {
                int nSum = number[i] - '0' + nTakeOver;
                // 如果当前是个位，则加一
                if (i == length - 1)
                {
                    nSum++;
                }

                if (nSum >= 10)
                {
                    // 如果是最高位，且sum>=10，则代表溢出了。超过了 n 位，这时候停止
                    if (i == 0)
                    {
                        isOverflow = true;
                    }
                    else
                    {
                        // 不是最高位，则进位
                        nTakeOver = 1;
                        number[i] = '0';
                    }
                }
                else
                {
                    // 只修改需要修改的地方，修改完退出
                    number[i] = (char) ('0' + nSum);
                    break;
                }
            }

            return isOverflow;
        }

        // 字符串number表示一个数字，数字有若干个0开头
        // 打印出这个数字，并忽略开头的0
        private static void PrintNumber(char[] number)
        {
            bool isBeginning0 = true;
            int nLength = number.Length;
            for (int i = 0; i < nLength; i++)
            {
                // 忽略左边开头的0
                if (isBeginning0 && number[i] != '0')
                {
                    isBeginning0 = false;
                }

                if (!isBeginning0)
                {
                    Console.Write(number[i]);
                }
            }

            Console.WriteLine();
        }

        // 方法二 递归
        private static void Print1ToMaxOfNDigits2(int n)
        {
            if (n <= 0) return;
            char[] number = new char[n];
            for (int i = 0; i < 10; i++)
            {
                number[0] = (char) (i + '0');
                Print1ToMaxOfNDigitsRecursively(number, n, 0);
            }
        }

        // 从数字最高位到最低位递归地填数字
        private static void Print1ToMaxOfNDigitsRecursively(char[] number, int length, int index)
        {
            // 到最高位
            if (index == length - 1)
            {
                PrintNumber(number);
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                number[index + 1] = (char) (i + '0');
                Print1ToMaxOfNDigitsRecursively(number, length, index + 1);
            }
        }
    }
}