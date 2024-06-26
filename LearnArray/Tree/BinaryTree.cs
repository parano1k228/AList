using System;
using System.Collections.Generic;
using System.Text;

namespace LearnArray.Tree
{
    public class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int value)
        {
            this.value = value;
        }

        public Node(int value, Node left)
        {
            this.value = value;
            this.left = null;
        }

        public Node(int value,Node left, Node right)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }
    }

    public class BinaryTree
    {
        public Node root = null;

        public void Insert(int value)
        {
            root = InsertRec(root, value);
        }

        private Node InsertRec(Node root, int value)
        {
            if (root == null)
            {
                root = new Node(value);
                return root;
            }

            if (value < root.value)
                root.left = InsertRec(root.left, value);
            else if (value > root.value)
                root.right = InsertRec(root.right, value);

            return root;
        }

        public bool Search(int value)
        {
            return SearchRec(root, value);
        }

        private bool SearchRec(Node root, int value)
        {
            if (root == null)
                return false;

            if (root.value == value)
                return true;

            if (value < root.value)
                return SearchRec(root.left, value);

            return SearchRec(root.right, value);
        }

        public void Delete(int value)
        {
            root = DeleteRec(root, value);
        }

        private Node DeleteRec(Node root, int value)
        {
            if (root == null)
                return root;

            if (value < root.value)
                root.left = DeleteRec(root.left, value);
            else if (value > root.value)
                root.right = DeleteRec(root.right, value);
            else
            {
                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;

                root.value = MinValue(root.right);
                root.right = DeleteRec(root.right, root.value);
            }

            return root;
        }

        public void Add(int value)
        {
            if (root == null)
            {
                root = new Node(value);
            }
            else
            {
                AddRec(root, value);
            }
        }

        private void AddRec(Node node, int value)
        {
            if (value < node.value)
            {
                if (node.left == null)
                {
                    node.left = new Node(value);
                }
                else
                {
                    AddRec(node.left, value);
                }
            }
            else
            {
                if (node.right == null)
                {
                    node.right = new Node(value);
                }
                else
                {
                    AddRec(node.right, value);
                }
            }
        }


        private int MinValue(Node root)
        {
            int minv = root.value;
            while (root.left != null)
            {
                minv = root.left.value;
                root = root.left;
            }
            return minv;
        }

        public void Clear()
        {
            root = null;
        }

        public int Size()
        {
            return SizeRec(root);
        }

        private int SizeRec(Node root)
        {
            if (root == null)
                return 0;
            else
                return (SizeRec(root.left) + 1 + SizeRec(root.right));
        }

        public int[] ToArray()
        {
            List<int> list = new List<int>();
            ToArrayRec(root, list);
            return list.ToArray();
        }

        private void ToArrayRec(Node root, List<int> list)
        {
            if (root != null)
            {
                ToArrayRec(root.left, list);
                list.Add(root.value);
                ToArrayRec(root.right, list);
            }
        }

        public void Init(int[] ini)
        {
            Clear();
            if (ini == null)
                throw new ArgumentNullException(nameof(ini));

            foreach (int value in ini)
            {
                Insert(value);
            }
        }

        public int Min()
        {
            if (root == null)
                throw new InvalidOperationException("Tree is empty");

            Node current = root;
            while (current.left != null)
            {
                current = current.left;
            }
            return current.value;
        }

        public int Max()
        {
            if (root == null)
                throw new InvalidOperationException("Tree is empty");

            Node current = root;
            while (current.right != null)
            {
                current = current.right;
            }
            return current.value;
        }

        public int IndexMin()
        {
            return Min();
        }

        public int IndexMax()
        {
            return Max();
        }

        public void Reverse()
        {
            root = ReverseRec(root);
        }

        private Node ReverseRec(Node root)
        {
            if (root == null)
                return null;

            Node temp = root.left;
            root.left = root.right;
            root.right = temp;

            if (root.left != null)
                ReverseRec(root.left);
            if (root.right != null)
                ReverseRec(root.right);

            return root;
        }

        public void Sort()
        {
            int[] array = ToArray();
            Array.Sort(array);
            Clear();
            Init(array);
        }

        public void HalfReverse()
        {
            int[] array = ToArray();
            int n = array.Length;
            int half = n / 2;

            for (int i = 0; i < half; i++)
            {
                int temp = array[i];
                array[i] = array[half + i];
                array[half + i] = temp;
            }

            Clear();
            Init(array);
        }

        public void InOrderTraversal()
        {
            InOrderRec(root);
        }

        private void InOrderRec(Node root)
        {
            if (root != null)
            {
                InOrderRec(root.left);
                Console.Write(root.value);
                InOrderRec(root.right);
            }
        }

        public void PreOrderTraversal()
        {
            PreOrderRec(root);
        }

        private void PreOrderRec(Node root)
        {
            if (root != null)
            {
                Console.Write(root.value);
                PreOrderRec(root.left);
                PreOrderRec(root.right);
            }
        }

        public void PostOrderTraversal()
        {
            PostOrderRec(root);
        }

        private void PostOrderRec(Node root)
        {
            if (root != null)
            {
                PostOrderRec(root.left);
                PostOrderRec(root.right);
                Console.Write(root.value);
            }
        }
    }
}