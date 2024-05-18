using System;
using System.Collections.Generic;
using System.Text;

namespace LearnArray
{
    public class ListR : IList
    {
        public class Node
        {
            public int value;
            public Node next;
            public Node prev;

            public Node(int value)
            {
                this.value = value;
            }

            public Node(int value, Node next)
            {
                this.value = value;
                this.next = next;
            }

            public Node(int value, Node next, Node prev)
            {
                this.value = value;
                this.next = next;
                this.prev = prev;
            }
        }

        public Node root = null;

        public void Init(int[] ini)
        {
            Clear();
            if (ini == null)
                throw new ArgumentNullException(nameof(ini));

            foreach (int value in ini)
            {
                AddEnd(value);
            }
        }

        public int Size()
        {
            int count = 0;
            Node current = root;
            while (current != null)
            {
                count++;
                current = current.next;
            }
            return count;
        }

        public void Clear()
        {
            root = null;
        }

        public int[] ToArray()
        {
            List<int> list = new List<int>();
            Node current = root;
            while (current != null)
            {
                list.Add(current.value);
                current = current.next;
            }
            return list.ToArray();
        }

        public string ToString()
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            StringBuilder result = new StringBuilder();

            Node current = root;
            while (current != null)
            {
                result.AppendFormat("{0}", current.value);
                if (current.next != null)
                {
                    result.Append("");
                }
                current = current.next;
            }
            return result.ToString();
        }

        public void AddStart(int value)
        {
            Node newNode = new Node(value);
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                newNode.next = root;
                root.prev = newNode;
                root = newNode;
            }
        }

        public void AddEnd(int value)
        {
            Node newNode = new Node(value);
            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Node current = root;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newNode;
                newNode.prev = current;
            }
        }

        public void AddPos(int index, int value)
        {
            if (index < 0 || index > Size())
                throw new ArgumentOutOfRangeException(nameof(index));

            if (index == 0)
            {
                AddStart(value);
            }
            else if (index == Size())
            {
                AddEnd(value);
            }
            else
            {
                Node newNode = new Node(value);
                Node current = root;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.next;
                }
                newNode.next = current.next;
                newNode.prev = current;
                current.next.prev = newNode;
                current.next = newNode;
            }
        }

        public int DelStart()
        {
            if (root == null)
                throw new InvalidOperationException("List is empty");

            int value = root.value;
            root = root.next;
            if (root != null)
            {
                root.prev = null;
            }
            return value;
        }

        public int DelEnd()
        {
            if (root == null)
                throw new InvalidOperationException("List is empty");

            if (root.next == null)
            {
                int value = root.value;
                root = null;
                return value;
            }

            Node current = root;
            while (current.next.next != null)
            {
                current = current.next;
            }
            int endValue = current.next.value;
            current.next = null;
            return endValue;
        }

        public int DelPos(int index)
        {
            if (index < 0 || index >= Size())
                throw new ArgumentOutOfRangeException(nameof(index));

            if (index == 0)
            {
                return DelStart();
            }
            else if (index == Size() - 1)
            {
                return DelEnd();
            }
            else
            {
                Node current = root;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.next;
                }
                int value = current.next.value;
                current.next = current.next.next;
                current.next.prev = current;
                return value;
            }
        }

        public int Get(int index)
        {
            if (index < 0 || index >= Size())
                throw new ArgumentOutOfRangeException(nameof(index));

            Node current = root;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            return current.value;
        }

        public void Set(int index, int value)
        {
            if (index < 0 || index >= Size())
                throw new ArgumentOutOfRangeException(nameof(index));

            Node current = root;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            current.value = value;
        }

        public void Reverse()
        {
            Node prev = null;
            Node current = root;
            Node next = null;
            while (current != null)
            {
                next = current.next;
                current.next = prev;
                current.prev = next; 
                prev = current;
                current = next;
            }
            root = prev;
        }

        public void HalfReverse()
        {
            int size = Size();
            if (size <= 1)
                return;

            int mid = size / 2;
            Node current = root;
            for (int i = 0; i < mid; i++)
            {
                current = current.next;
            }

            Node firstHalfEnd = current.prev;
            Node secondHalfStart = current;

            firstHalfEnd.next = null;
            secondHalfStart.prev = null;

            Node lastNode = secondHalfStart;
            while (lastNode.next != null)
            {
                lastNode = lastNode.next;
            }
            lastNode.next = root;
            root.prev = lastNode;

            root = secondHalfStart;
        }

        public int Min()
        {
            if (root == null)
                throw new InvalidOperationException("List is empty");

            int min = root.value;
            Node current = root.next;
            while (current != null)
            {
                if (current.value < min)
                    min = current.value;
                current = current.next;
            }
            return min;
        }

        public int Max()
        {
            if (root == null)
                throw new InvalidOperationException("List is empty");

            int max = root.value;
            Node current = root.next;
            while (current != null)
            {
                if (current.value > max)
                    max = current.value;
                current = current.next;
            }
            return max;
        }

        public int IndexMin()
        {
            if (root == null)
                throw new InvalidOperationException("List is empty");

            int min = root.value;
            int index = 0;
            int minIndex = 0;
            Node current = root.next;
            while (current != null)
            {
                index++;
                if (current.value < min)
                {
                    min = current.value;
                    minIndex = index;
                }
                current = current.next;
            }
            return minIndex;
        }

        public int IndexMax()
        {
            if (root == null)
                throw new InvalidOperationException("List is empty");

            int max = root.value;
            int index = 0;
            int maxIndex = 0;
            Node current = root.next;
            while (current != null)
            {
                index++;
                if (current.value > max)
                {
                    max = current.value;
                    maxIndex = index;
                }
                current = current.next;
            }
            return maxIndex;
        }

        public void Sort()
        {
            int size = Size();
            if (size <= 1)
                return;

            for (int i = 0; i < size - 1; i++)
            {
                Node current = root;
                for (int j = 0; j < size - i - 1; j++)
                {
                    if (current.value > current.next.value)
                    {
                        int temp = current.value;
                        current.value = current.next.value;
                        current.next.value = temp;
                    }
                    current = current.next;
                }
            }
        }
    }
}
