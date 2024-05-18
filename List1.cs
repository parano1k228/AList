using System;
using System.Text;

namespace LearnArray
{
    public class List1 : IList
    {
        public class Node
        {
            public int value;
            public Node next;

            public Node(int value)
            {
                this.value = value;
            }

            public Node(int value, Node next)
            {
                this.value = value;
                this.next = next;
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
            int size = 0;
            Node current = root;
            while (current != null)
            {
                size++;
                current = current.next;
            }
            return size;
        }

        public void Clear()
        {
            root = null;
        }

        public int[] ToArray()
        {
            int[] array = new int[Size()];
            Node current = root;
            int index = 0;
            while (current != null)
            {
                array[index++] = current.value;
                current = current.next;
            }
            return array;
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
            root = new Node(value, root);
        }

        public void AddEnd(int value)
        {
            if (root == null)
            {
                root = new Node(value);
            }
            else
            {
                Node current = root;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = new Node(value);
            }
        }

        public void AddPos(int index, int value)
        {
            if (index < 0 || index > Size())
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
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
                Node current = root;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.next;
                }
                current.next = new Node(value, current.next);
            }
        }

        public int DelStart()
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            int value = root.value;
            root = root.next;
            return value;
        }

        public int DelEnd()
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
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
            int lastValue = current.next.value;
            current.next = null;
            return lastValue;
        }

        public int DelPos(int index)
        {
            if (index < 0 || index >= Size())
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
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
                int deletedValue = current.next.value;
                current.next = current.next.next;
                return deletedValue;
            }
        }

        public void Set(int index, int value)
        {
            if (index < 0 || index >= Size())
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
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
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            Node current = root;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            return current.value;
        }

        public void Reverse()
        {
            Node previous = null;
            Node current = root;
            while (current != null)
            {
                Node next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }
            root = previous;
        }

        public void HalfReverse()
        {
            if (root == null || root.next == null)
                return;

            int size = Size();
            Node tmp = root;
            Node mid = null;
            int i = 0;
            while (tmp.next != null)
            {
                i++;
                if (i == size / 2)
                {
                    mid = tmp;
                }
                tmp = tmp.next;
            }
            if (size % 2 != 0)
            {
                Node x = mid.next;
                mid.next = mid.next.next;
                x.next = root;
                root = x;
            }
            tmp.next = root;
            root = mid.next;
            mid.next = null;
        }

        public int Min()
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            int min = root.value;
            Node current = root.next;
            while (current != null)
            {
                if (current.value < min)
                {
                    min = current.value;
                }
                current = current.next;
            }
            return min;
        }

        public int Max()
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            int max = root.value;
            Node current = root.next;
            while (current != null)
            {
                if (current.value > max)
                {
                    max = current.value;
                }
                current = current.next;
            }
            return max;
        }

        public int IndexMin()
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            int minIndex = 0;
            int min = root.value;
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
            {
                throw new ArgumentNullException(nameof(root));
            }
            int maxIndex = 0;
            int max = root.value;
            Node current = root.next;
            int index = 1;
            while (current != null)
            {
                if (current.value > max)
                {
                    max = current.value;
                    maxIndex = index;
                }
                current = current.next;
                index++;
            }
            return maxIndex;
        }

        public void Sort()
        {
            if (root == null || root.next == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            bool swapped;
            do
            {
                swapped = false;
                Node current = root;
                Node previous = null;

                while (current.next != null)
                {
                    if (current.value > current.next.value)
                    {
                        int temp = current.value;
                        current.value = current.next.value;
                        current.next.value = temp;
                        swapped = true;
                    }
                    previous = current;
                    current = current.next;
                }
            } while (swapped);
        }  
    }
}
