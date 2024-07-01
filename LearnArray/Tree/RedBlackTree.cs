using System;
using System.Collections.Generic;

namespace LearnArray.Tree
{
    public enum Color { Red, Black }

    public class NodeRedBlack
    {
        public int value;
        public Color color;
        public NodeRedBlack left;
        public NodeRedBlack right;
        public NodeRedBlack parent;

        public NodeRedBlack(int value)
        {
            this.value = value;
            this.color = Color.Red;
        }
    }

    public class RedBlackTree
    {
        public NodeRedBlack root;
        private NodeRedBlack TNULL;

        public RedBlackTree()
        {
            TNULL = new NodeRedBlack(0);
            TNULL.color = Color.Black;
            TNULL.left = null;
            TNULL.right = null;
            root = TNULL;
        }

        public void Insert(int key)
        {
            NodeRedBlack node = new NodeRedBlack(key);
            node.parent = null;
            node.value = key;
            node.left = TNULL;
            node.right = TNULL;
            node.color = Color.Red;

            NodeRedBlack y = null;
            NodeRedBlack x = this.root;

            while (x != TNULL)
            {
                y = x;
                if (node.value < x.value)
                {
                    x = x.left;
                }
                else
                {
                    x = x.right;
                }
            }

            node.parent = y;
            if (y == null)
            {
                root = node;
            }
            else if (node.value < y.value)
            {
                y.left = node;
            }
            else
            {
                y.right = node;
            }

            if (node.parent == null)
            {
                node.color = Color.Black;
                return;
            }

            if (node.parent.parent == null)
            {
                return;
            }

            FixInsert(node);
        }

        private void FixInsert(NodeRedBlack k)
        {
            NodeRedBlack u;
            while (k.parent.color == Color.Red)
            {
                if (k.parent == k.parent.parent.right)
                {
                    u = k.parent.parent.left;
                    if (u.color == Color.Red)
                    {
                        u.color = Color.Black;
                        k.parent.color = Color.Black;
                        k.parent.parent.color = Color.Red;
                        k = k.parent.parent;
                    }
                    else
                    {
                        if (k == k.parent.left)
                        {
                            k = k.parent;
                            RightRotate(k);
                        }
                        k.parent.color = Color.Black;
                        k.parent.parent.color = Color.Red;
                        LeftRotate(k.parent.parent);
                    }
                }
                else
                {
                    u = k.parent.parent.right;

                    if (u.color == Color.Red)
                    {
                        u.color = Color.Black;
                        k.parent.color = Color.Black;
                        k.parent.parent.color = Color.Red;
                        k = k.parent.parent;
                    }
                    else
                    {
                        if (k == k.parent.right)
                        {
                            k = k.parent;
                            LeftRotate(k);
                        }
                        k.parent.color = Color.Black;
                        k.parent.parent.color = Color.Red;
                        RightRotate(k.parent.parent);
                    }
                }
                if (k == root)
                {
                    break;
                }
            }
            root.color = Color.Black;
        }

        private void LeftRotate(NodeRedBlack x)
        {
            NodeRedBlack y = x.right;
            x.right = y.left;
            if (y.left != TNULL)
            {
                y.left.parent = x;
            }
            y.parent = x.parent;
            if (x.parent == null)
            {
                this.root = y;
            }
            else if (x == x.parent.left)
            {
                x.parent.left = y;
            }
            else
            {
                x.parent.right = y;
            }
            y.left = x;
            x.parent = y;
        }

        private void RightRotate(NodeRedBlack y)
        {
            NodeRedBlack x = y.left;
            y.left = x.right;
            if (x.right != TNULL)
            {
                x.right.parent = y;
            }
            x.parent = y.parent;
            if (y.parent == null)
            {
                this.root = x;
            }
            else if (y == y.parent.right)
            {
                y.parent.right = x;
            }
            else
            {
                y.parent.left = x;
            }
            x.right = y;
            y.parent = x;
        }

        public void Delete(int key)
        {
            DeleteNodeHelper(this.root, key);
        }

        private void DeleteNodeHelper(NodeRedBlack node, int key)
        {
            NodeRedBlack z = TNULL;
            NodeRedBlack x, y;
            while (node != TNULL)
            {
                if (node.value == key)
                {
                    z = node;
                }

                if (node.value <= key)
                {
                    node = node.right;
                }
                else
                {
                    node = node.left;
                }
            }

            if (z == TNULL)
            {
                Console.WriteLine("Couldn't find key in the tree");
                return;
            }

            y = z;
            Color yOriginalColor = y.color;
            if (z.left == TNULL)
            {
                x = z.right;
                Transplant(z, z.right);
            }
            else if (z.right == TNULL)
            {
                x = z.left;
                Transplant(z, z.left);
            }
            else
            {
                y = Minimum(z.right);
                yOriginalColor = y.color;
                x = y.right;
                if (y.parent == z)
                {
                    x.parent = y;
                }
                else
                {
                    Transplant(y, y.right);
                    y.right = z.right;
                    y.right.parent = y;
                }

                Transplant(z, y);
                y.left = z.left;
                y.left.parent = y;
                y.color = z.color;
            }
            if (yOriginalColor == Color.Black)
            {
                FixDelete(x);
            }
        }

        private void FixDelete(NodeRedBlack x)
        {
            NodeRedBlack s;
            while (x != root && x.color == Color.Black)
            {
                if (x == x.parent.left)
                {
                    s = x.parent.right;
                    if (s.color == Color.Red)
                    {
                        s.color = Color.Black;
                        x.parent.color = Color.Red;
                        LeftRotate(x.parent);
                        s = x.parent.right;
                    }

                    if (s.left.color == Color.Black && s.right.color == Color.Black)
                    {
                        s.color = Color.Red;
                        x = x.parent;
                    }
                    else
                    {
                        if (s.right.color == Color.Black)
                        {
                            s.left.color = Color.Black;
                            s.color = Color.Red;
                            RightRotate(s);
                            s = x.parent.right;
                        }

                        s.color = x.parent.color;
                        x.parent.color = Color.Black;
                        s.right.color = Color.Black;
                        LeftRotate(x.parent);
                        x = root;
                    }
                }
                else
                {
                    s = x.parent.left;
                    if (s.color == Color.Red)
                    {
                        s.color = Color.Black;
                        x.parent.color = Color.Red;
                        RightRotate(x.parent);
                        s = x.parent.left;
                    }

                    if (s.left.color == Color.Black && s.right.color == Color.Black)
                    {
                        s.color = Color.Red;
                        x = x.parent;
                    }
                    else
                    {
                        if (s.left.color == Color.Black)
                        {
                            s.right.color = Color.Black;
                            s.color = Color.Red;
                            LeftRotate(s);
                            s = x.parent.left;
                        }

                        s.color = x.parent.color;
                        x.parent.color = Color.Black;
                        s.left.color = Color.Black;
                        RightRotate(x.parent);
                        x = root;
                    }
                }
            }
            x.color = Color.Black;
        }

        private void Transplant(NodeRedBlack u, NodeRedBlack v)
        {
            if (u.parent == null)
            {
                root = v;
            }
            else if (u == u.parent.left)
            {
                u.parent.left = v;
            }
            else
            {
                u.parent.right = v;
            }
            v.parent = u.parent;
        }

        private NodeRedBlack Minimum(NodeRedBlack node)
        {
            while (node.left != TNULL)
            {
                node = node.left;
            }
            return node;
        }

        public bool Search(int key)
        {
            return SearchNode(root, key) != TNULL;
        }

        private NodeRedBlack SearchNode(NodeRedBlack node, int key)
        {
            if (node == TNULL || key == node.value)
            {
                return node;
            }

            if (key < node.value)
            {
                return SearchNode(node.left, key);
            }
            return SearchNode(node.right, key);
        }

        public void InOrderTraversal()
        {
            InOrderRec(root);
        }

        private void InOrderRec(NodeRedBlack root)
        {
            if (root != TNULL)
            {
                InOrderRec(root.left);
                Console.Write(root.value + " ");
                InOrderRec(root.right);
            }
        }

        public void Clear()
        {
            root = TNULL;
        }

        public int Size()
        {
            return SizeRec(root);
        }

        private int SizeRec(NodeRedBlack root)
        {
            if (root == TNULL)
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

        private void ToArrayRec(NodeRedBlack root, List<int> list)
        {
            if (root != TNULL)
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
            if (root == TNULL)
                throw new InvalidOperationException("Tree is empty");

            NodeRedBlack current = root;
            while (current.left != TNULL)
            {
                current = current.left;
            }
            return current.value;
        }

        public int Max()
        {
            if (root == TNULL)
                throw new InvalidOperationException("Tree is empty");

            NodeRedBlack current = root;
            while (current.right != TNULL)
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

        private NodeRedBlack ReverseRec(NodeRedBlack root)
        {
            if (root == TNULL)
                return TNULL;

            NodeRedBlack temp = root.left;
            root.left = ReverseRec(root.right);
            root.right = ReverseRec(temp);

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

        public void PreOrderTraversal()
        {
            PreOrderRec(root);
        }

        private void PreOrderRec(NodeRedBlack root)
        {
            if (root != TNULL)
            {
                Console.Write(root.value + " ");
                PreOrderRec(root.left);
                PreOrderRec(root.right);
            }
        }

        public void PostOrderTraversal()
        {
            PostOrderRec(root);
        }

        private void PostOrderRec(NodeRedBlack root)
        {
            if (root != TNULL)
            {
                PostOrderRec(root.left);
                PostOrderRec(root.right);
                Console.Write(root.value + " ");
            }
        }
    }
}