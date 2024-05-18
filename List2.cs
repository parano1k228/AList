using System;
using System.Collections.Generic;

namespace LearnArray
{
    public class List2 : IList
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
        public Node tail = null;

        public void Init(int[] ini)
        {
            Clear();
            if (ini == null)
                throw new ArgumentNullException(nameof(ini));

            foreach (int value in ini)
            {
                Node newNode = new Node(value);
                if (root == null)
                {
                    root = newNode;
                    tail = root;
                }
                else
                {
                    tail.next = newNode;
                    newNode.prev = tail;
                    tail = newNode;
                }
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
            tail = null;
        }

        public int[] ToArray()
        {
            List<int> result = new List<int>();
            Node current = root;
            while (current != null)
            {
                result.Add(current.value);
                current = current.next;
            }
            return result.ToArray();
        }

        public override string ToString()
        {
            return string.Join("", ToArray());
        }

        public void AddStart(int value)
        {
            Node newNode = new Node(value);
            if (root == null)
            {
                root = newNode;
                tail = newNode;
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
            if (tail == null)
            {
                root = newNode;
                tail = newNode;
            }
            else
            {
                newNode.prev = tail;
                tail.next = newNode;
                tail = newNode;
            }
        }

        public void AddPos(int index, int value)
        {
            if (index < 0 || index > Size())
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                AddStart(value);
                return;
            }

            if (index == Size())
            {
                AddEnd(value);
                return;
            }

            Node current = root;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.next;
            }
            Node newNode = new Node(value);
            newNode.next = current.next;
            newNode.prev = current;
            current.next.prev = newNode;
            current.next = newNode;
        }

        public int DelStart()
        {
            if (root == null)
                throw new InvalidOperationException("List is empty");

            int value = root.value;
            root = root.next;
            if (root != null)
                root.prev = null;
            else
                tail = null;

            return value;
        }

        public int DelEnd()
        {
            if (tail == null)
                throw new InvalidOperationException("List is empty");

            int value = tail.value;
            tail = tail.prev;
            if (tail != null)
                tail.next = null;
            else
                root = null;

            return value;
        }

        public int DelPos(int index)
        {
            if (index < 0 || index >= Size())
                throw new IndexOutOfRangeException();

            if (index == 0)
                return DelStart();

            if (index == Size() - 1)
                return DelEnd();

            Node current = root;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            int value = current.value;
            current.prev.next = current.next;
            current.next.prev = current.prev;

            return value;
        }

        public void Set(int index, int value)
        {
            if (index < 0 || index >= Size())
                throw new IndexOutOfRangeException();

            Node current = root;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            current.value = value;
        }

        public int Get(int index)
        {
            if (index < 0 || index >= Size())
                throw new IndexOutOfRangeException();

            Node current = root;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            return current.value;
        }

        public void Reverse()
        {
            Node current = root;
            Node temp = null;

            while (current != null)
            {
                temp = current.prev;
                current.prev = current.next;
                current.next = temp;
                current = current.prev;
            }

            if (temp != null)
                root = temp.prev;
        }

        public void HalfReverse()
        {
            int size = Size();
            if (size < 2)
                return; 

            int halfSize = size / 2;
            int lastIndex = size - 1;

            for (int i = 0; i < halfSize; i++)
            {
                int temp = Get(i);
                Set(i, Get(halfSize + i));
                Set(halfSize + i, temp);
            }
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
            int minIndex = 0;
            Node current = root.next;
            int index = 1;
            while (current != null)
            {
                if (current.value < min)
                {
                    min = current.value;
                    minIndex = index;
                }
                current = current.next;
                index++;
            }
            return minIndex;
        }

        public int IndexMax()
        {
            if (root == null)
                throw new InvalidOperationException("List is empty");

            int maxIndex = 0;
            int maxValue = root.value;
            Node current = root.next;
            int currentIndex = 1;

            while (current != null)
            {
                if (current.value > maxValue)
                {
                    maxValue = current.value;
                    maxIndex = currentIndex;
                }
                current = current.next;
                currentIndex++;
            }

            return maxIndex;
        }

        public void Sort()
        {
            if (root == null || root.next == null)
                return;

            Node sorted = null;
            Node current = root;

            while (current != null)
            {
                Node next = current.next;

                if (sorted == null || current.value < sorted.value)
                {
                    current.next = sorted;
                    current.prev = null;
                    if (sorted != null)
                        sorted.prev = current;
                    sorted = current;
                }
                else
                {
                    Node search = sorted;
                    while (search.next != null && search.next.value < current.value)
                    {
                        search = search.next;
                    }
                    current.next = search.next;
                    if (search.next != null)
                        search.next.prev = current;
                    search.next = current;
                    current.prev = search;
                }

                current = next;
            }

            root = sorted;
            while (sorted.next != null)
            {
                sorted = sorted.next;
            }
            tail = sorted;
        }
    }
}
