using System;

namespace _08_NextNodeInBinaryTrees
{
    class Program
    {
        private class TreeNode
        {
            public char val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode parent;

            public TreeNode(char x, TreeNode parent)
            {
                val = x;
                this.parent = parent;
            }
        }

        // 面试题8：二叉树的下一个结点
        // 题目：给定一棵二叉树和其中的一个结点，如何找出中序遍历顺序的下一个结点？
        // 树中的结点除了有两个分别指向左右子结点的指针以外，还有一个指向父结点的指针。
        static void Main(string[] args)
        {
            // e.g. 中序遍历 {d, b, h, e, i, a, f, c, g}
            TreeNode root = new TreeNode('a', null);
            root.left = new TreeNode('b', root);
            root.left.left = new TreeNode('d', root.left);
            root.left.right = new TreeNode('e', root.left);
            root.left.right.left = new TreeNode('h', root.left.right);
            root.left.right.right = new TreeNode('i', root.left.right);
            root.right = new TreeNode('c', root);
            root.right.left = new TreeNode('f', root.right);
            root.right.right = new TreeNode('g', root.right);
            Console.WriteLine(GetNextNode(root.left).val); // h
            Console.WriteLine(GetNextNode(root.left.left).val); // b
            Console.WriteLine(GetNextNode(root.left.right.right).val); // a
        }

        private static TreeNode GetNextNode(TreeNode node)
        {
            if (node == null) return null;
            // 如果一个节点有右子树，那么它的下一个节点就是它的右子树中的最左子节点
            if (node.right != null)
            {
                TreeNode right = node.right;
                while (right.left != null)
                {
                    right = right.left;
                }

                return right;
            }

            // 如果一个节点没有右子树，如果节点是它父节点的左子节点，那么它的下一个节点就是它的父节点
            if (node.parent != null && node == node.parent.left)
            {
                return node.parent;
            }

            // 如果一个节点既没有右子树，并且它还是它父节点的右子节点，那么就比较复杂。
            // 我们可以沿着指向父节点的指针一直向上遍历，直到找到一个是它父节点的左子节点的节点。
            // 如果这样的节点存在，那么这个节点的父节点就是我们要找的下一个节点。
            if (node.parent != null)
            {
                TreeNode parent = node.parent;
                while (parent != parent.parent.left)
                {
                    parent = parent.parent;
                }

                return parent.parent;
            }

            return null;
        }
    }
}