using System;

namespace _18_01_DeleteNodeInList
{
    class Program
    {
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int x)
            {
                val = x;
            }
        }

        // 面试题18（一）：在O(1)时间删除链表结点
        // 题目：给定单向链表的头指针和一个结点指针，定义一个函数在O(1)时间删除该
        // 结点。
        public static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            ListNode toBeDeleted = new ListNode(3);
            head.next.next = toBeDeleted;
//            head.next.next.next = new ListNode(4);
            DeleteNode(ref head, toBeDeleted);

            if (head != null)
            {
                Console.Write(head.val);
                while (head.next != null)
                {
                    Console.Write(" -> ");
                    Console.Write(head.next.val);
                    head = head.next;
                }
            }
            else
            {
                Console.WriteLine("head = null");
            }
        }

        private static void DeleteNode(ref ListNode head, ListNode toBeDeleted)
        {
            if (head == null || toBeDeleted == null) return;
            // 要删除的结点不是尾结点
            if (toBeDeleted.next != null)
            {
                ListNode next = toBeDeleted.next;
                toBeDeleted.val = next.val;
                toBeDeleted.next = next.next;
            }
            // 要删除的结点是尾结点，同时是头结点
            else if (head == toBeDeleted)
            {
                head = null;
            }
            // 要删除的结点是尾结点，且前面还有多个结点
            else
            {
                ListNode node = head;
                while (node.next != toBeDeleted)
                {
                    node = node.next;
                }

                node.next = null;
            }
        }
    }
}