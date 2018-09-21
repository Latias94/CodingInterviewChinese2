using System;

namespace _07_ConstructBinaryTree
{
    class Program
    {
        private class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int x)
            {
                val = x;
            }
        }

        // 面试题7：重建二叉树
        // 题目：输入某二叉树的前序遍历和中序遍历的结果，请重建出该二叉树。假设输
        // 入的前序遍历和中序遍历的结果中都不含重复的数字。例如输入前序遍历序列{1,
        // 2, 4, 7, 3, 5, 6, 8}和中序遍历序列{4, 7, 2, 1, 5, 3, 8, 6}，则重建出
        // 图2.6所示的二叉树并输出它的头结点。
        static void Main(string[] args)
        {
            int[] pre = {1, 2, 4, 7, 3, 5, 6, 8};
            int[] tin = {4, 7, 2, 1, 5, 3, 8, 6};
            TreeNode result = ReConstructBinaryTree(pre, tin);
            Console.WriteLine(result.left.left.right.val); // 7
            Console.WriteLine(result.right.right.left.val); // 8
        }


        private static TreeNode ReConstructBinaryTree(int[] pre, int[] tin)
        {
            if (pre.Length == 0 || tin.Length == 0) return null;
            TreeNode root = new TreeNode(pre[0]);
            int length = Array.IndexOf(tin, pre[0]);
            root.left = ReConstructBinaryTree(Slice(pre, 1, length + 1),
                Slice(tin, 0, length));
            root.right = ReConstructBinaryTree(Slice(pre, length + 1, pre.Length),
                Slice(tin, length + 1, tin.Length));
            return root;
        }

        private static int[] Slice(int[] arr, int from, int to)
        {
            int length = to - from;
            int[] result = new int[length];
            Array.Copy(arr, from, result, 0, length);
            return result;
        }
    }
}