using System;
using System.Collections.Generic;

namespace _09_QueueWithTwoStacks
{
    class Program
    {
        // 面试题9：用两个栈实现队列
        // 题目：用两个栈实现一个队列。队列的声明如下，请实现它的两个函数appendTail
        // 和deleteHead，分别完成在队列尾部插入结点和在队列头部删除结点的功能。
        static void Main(string[] args)
        {
            push(1);
            push(2);
            push(3);
            Console.WriteLine(pop()); // 1
            Console.WriteLine(pop()); // 2
            push(4);
            Console.WriteLine(pop()); // 3
            Console.WriteLine(pop()); // 4
        }

        private static Stack<int> stack1 = new Stack<int>();
        private static Stack<int> stack2 = new Stack<int>();

        private static void push(int node)
        {
            stack1.Push(node);
        }

        private static int pop()
        {
            if (stack2.Count == 0)
            {
                while (stack1.Count != 0)
                {
                    stack2.Push(stack1.Pop());
                }
            }

            return stack2.Pop();
        }
    }
}