using System;

namespace LearnArray.Tree
{
    public class BinaryTree
    {
        public class Node
        {
            public int data;
            public Node left;
            public Node right;

            public Node(int data)
            {
                this.data = data;
                left = null;
                right = null;
            }
        }

        private Node root;

        public BinaryTree()
        {
            root = null;
        }

        public void Insert(int data)
        {
            root = Insert(root, data);
        }

        private Node Insert(Node root, int data)
        {
            if (root == null)
            {
                root = new Node(data);
                return root;
            }

            if (data < root.data)
                root.left = Insert(root.left, data);
            else if (data > root.data)
                root.right = Insert(root.right, data);

            return root;
        }

        public bool Search(int data)
        {
            return Search(root, data);
        }

        private bool Search(Node root, int data)
        {
            if (root == null)
                return false;
            if (root.data == data)
                return true;
            if (data < root.data)
                return Search(root.left, data);
            else
                return Search(root.right, data);
        }

        public void InOrderTraversal()
        {
            InOrderTraversal(root);
        }

        private void InOrderTraversal(Node root)
        {
            if (root != null)
            {
                InOrderTraversal(root.left);
                Console.Write(root.data + " ");
                InOrderTraversal(root.right);
            }
        }
    }
}