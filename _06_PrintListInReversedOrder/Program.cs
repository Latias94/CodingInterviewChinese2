using System;
using System.Collections.Generic;

namespace _06_PrintListInReversedOrder
{
    class Program
    {
        private class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int x)
            {
                val = x;
            }
        }
        
        // 面试题6：从尾到头打印链表
        // 题目：输入一个链表的头结点，从尾到头反过来打印出每个结点的值。`
        static void Main(string[] args)
        {
            ListNode root = new ListNode(1);
            root.next = new ListNode(2);
            root.next.next = new ListNode(3);
            root.next.next.next = new ListNode(4);
            root.next.next.next.next = new ListNode(5);
            List<int> result = PrintListFromTailToHead(root);
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine(result[i]);
            }
        }

        // 返回从尾到头的列表值序列
        private static List<int> PrintListFromTailToHead(ListNode listNode)
        {
            Stack<int> stack = new Stack<int>();
            while (listNode != null)
            {
                stack.Push(listNode.val);
                listNode = listNode.next;
            }

            List<int> result = new List<int>();
            while (stack.Count != 0)
            {
                result.Add(stack.Pop());
            }

            return result;
        }
    }
}