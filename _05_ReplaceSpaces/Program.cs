using System;
using System.Text;

namespace _05_ReplaceSpaces
{
    class Program
    {
        // 面试题5：替换空格
        // 题目：请实现一个函数，把字符串中的每个空格替换成"%20"。例如输入“We are happy.”，
        // 则输出“We%20are%20happy.”。
        static void Main(string[] args)
        {
            string str = "We Are Happy";
            Console.WriteLine(ReplaceSpaceWithExpandArray(str));
        }

        private static string ReplaceSpaceWithStringBuilder(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    sb.Append("%20");
                }
                else
                {
                    sb.Append(str[i]);
                }
            }

            return sb.ToString();
        }

        private static string ReplaceSpaceWithExpandArray(string str)
        {
            if (str.Length == 0) return str;
            int numberOfBlank = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                    numberOfBlank++;
            }

            char[] result = new char[str.Length + 2 * numberOfBlank];
            int left = str.Length - 1;
            int right = result.Length - 1;
            while (left >= 0)
            {
                if (str[left] != ' ')
                {
                    result[right--] = str[left];
                    left--;
                }
                else
                {
                    // find space
                    result[right--] = '0';
                    result[right--] = '2';
                    result[right--] = '%';
                    left--;
                }
            }

            return new string(result);
        }
    }
}