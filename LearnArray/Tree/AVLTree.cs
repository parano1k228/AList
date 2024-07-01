using System;
using System.Collections.Generic;

namespace LearnArray.Tree
{
    public class AVLNode
    {
        public int Value;
        public AVLNode Left;
        public AVLNode Right;
        public int Height;

        public AVLNode(int value)
        {
            Value = value;
            Height = 1;
        }
    }

    public class AVLTree
    {
        private AVLNode root;

        public void Insert(int value)
        {
            root = Insert(root, value);
        }

        private AVLNode Insert(AVLNode node, int value)
        {
            if (node == null)
                return new AVLNode(value);

            if (value < node.Value)
                node.Left = Insert(node.Left, value);
            else if (value > node.Value)
                node.Right = Insert(node.Right, value);
            else
                return node; // Duplicate values are not allowed

            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            int balance = GetBalance(node);

            if (balance > 1 && value < node.Left.Value)
                return RotateRight(node);

            if (balance < -1 && value > node.Right.Value)
                return RotateLeft(node);

            if (balance > 1 && value > node.Left.Value)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            if (balance < -1 && value < node.Right.Value)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        public void Delete(int value)
        {
            root = Delete(root, value);
        }

        private AVLNode Delete(AVLNode root, int value)
        {
            if (root == null)
                return root;

            if (value < root.Value)
                root.Left = Delete(root.Left, value);
            else if (value > root.Value)
                root.Right = Delete(root.Right, value);
            else
            {
                if ((root.Left == null) || (root.Right == null))
                {
                    AVLNode temp = root.Left ?? root.Right;

                    if (temp == null)
                    {
                        temp = root;
                        root = null;
                    }
                    else
                        root = temp;
                }
                else
                {
                    AVLNode temp = GetMinValueNode(root.Right);
                    root.Value = temp.Value;
                    root.Right = Delete(root.Right, temp.Value);
                }
            }

            if (root == null)
                return root;

            root.Height = 1 + Math.Max(GetHeight(root.Left), GetHeight(root.Right));

            int balance = GetBalance(root);

            if (balance > 1 && GetBalance(root.Left) >= 0)
                return RotateRight(root);

            if (balance > 1 && GetBalance(root.Left) < 0)
            {
                root.Left = RotateLeft(root.Left);
                return RotateRight(root);
            }

            if (balance < -1 && GetBalance(root.Right) <= 0)
                return RotateLeft(root);

            if (balance < -1 && GetBalance(root.Right) > 0)
            {
                root.Right = RotateRight(root.Right);
                return RotateLeft(root);
            }

            return root;
        }

        public bool Search(int value)
        {
            return Search(root, value);
        }

        private bool Search(AVLNode node, int value)
        {
            if (node == null)
                return false;

            if (node.Value == value)
                return true;

            if (value < node.Value)
                return Search(node.Left, value);

            return Search(node.Right, value);
        }

        public void Clear()
        {
            root = null;
        }

        public int Size()
        {
            return Size(root);
        }

        private int Size(AVLNode node)
        {
            if (node == null)
                return 0;
            return Size(node.Left) + 1 + Size(node.Right);
        }

        public int[] ToArray()
        {
            List<int> values = new List<int>();
            ToArray(root, values);
            return values.ToArray();
        }

        private void ToArray(AVLNode node, List<int> values)
        {
            if (node != null)
            {
                ToArray(node.Left, values);
                values.Add(node.Value);
                ToArray(node.Right, values);
            }
        }

        public void Init(int[] ini)
        {
            Clear();
            if (ini == null)
                throw new ArgumentNullException(nameof(ini));

            foreach (var value in ini)
                Insert(value);
        }

        public int Min()
        {
            if (root == null)
                throw new InvalidOperationException("Tree is empty");

            AVLNode current = root;
            while (current.Left != null)
                current = current.Left;

            return current.Value;
        }

        public int Max()
        {
            if (root == null)
                throw new InvalidOperationException("Tree is empty");

            AVLNode current = root;
            while (current.Right != null)
                current = current.Right;

            return current.Value;
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
            root = Reverse(root);
        }

        private AVLNode Reverse(AVLNode node)
        {
            if (node == null)
                return null;

            AVLNode temp = node.Left;
            node.Left = node.Right;
            node.Right = temp;

            if (node.Left != null)
                Reverse(node.Left);
            if (node.Right != null)
                Reverse(node.Right);

            return node;
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
            int half = array.Length / 2;

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
            InOrderTraversal(root);
        }

        private void InOrderTraversal(AVLNode node)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left);
                Console.Write(node.Value + " ");
                InOrderTraversal(node.Right);
            }
        }

        public void PreOrderTraversal()
        {
            PreOrderTraversal(root);
        }

        private void PreOrderTraversal(AVLNode node)
        {
            if (node != null)
            {
                Console.Write(node.Value + " ");
                PreOrderTraversal(node.Left);
                PreOrderTraversal(node.Right);
            }
        }

        public void PostOrderTraversal()
        {
            PostOrderTraversal(root);
        }

        private void PostOrderTraversal(AVLNode node)
        {
            if (node != null)
            {
                PostOrderTraversal(node.Left);
                PostOrderTraversal(node.Right);
                Console.Write(node.Value + " ");
            }
        }

        private int GetHeight(AVLNode node)
        {
            if (node == null)
                return 0;
            return node.Height;
        }

        private int GetBalance(AVLNode node)
        {
            if (node == null)
                return 0;
            return GetHeight(node.Left) - GetHeight(node.Right);
        }

        private AVLNode RotateRight(AVLNode y)
        {
            AVLNode x = y.Left;
            AVLNode T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

            return x;
        }

        private AVLNode RotateLeft(AVLNode x)
        {
            AVLNode y = x.Right;
            AVLNode T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Math.Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

            return y;
        }

        private AVLNode GetMinValueNode(AVLNode node)
        {
            AVLNode current = node;

            while (current.Left != null)
                current = current.Left;

            return current;
        }
    }
}
