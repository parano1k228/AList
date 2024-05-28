using System;
using System.Text;
namespace LearnArray.AList
{
    public class AList1 : IList
    {
        private int size = 0;
        private int[] array = new int[10];

        public void Init(int[] ini)
        {
            if (ini == null)
            {
                throw new ArgumentNullException(nameof(ini));
            }

            size = ini.Length;
            if (size > array.Length)
            {
                array = new int[size];
            }
            for (int i = 0; i < size; i++)
            {
                array[i] = ini[i];
            }
        }

        public int Size()
        {
            return size; ;
        }

        public void Clear()
        {
            size = 0;
        }

        public int[] ToArray()
        {
            int[] result = new int[size];
            for (int i = 0; i < size; i++)
            {
                result[i] = array[i];
            }
            return result;
        }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                sb.Append(array[i]);
            }
            return sb.ToString();
        }

        public void AddStart(int value)
        {
            AddPos(0, value);
        }

        public void AddEnd(int value)
        {
            if (size >= array.Length)
            {
                int[] newArray = new int[array.Length * 2];
                for (int i = 0; i < size; i++)
                {
                    newArray[i] = array[i];
                }
                array = newArray;
            }
            array[size] = value;
            size++;
        }

        public void AddPos(int index, int value)
        {
            if (index < 0 || index > size)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (size >= array.Length)
            {
                int[] newArray = new int[array.Length * 2];
                for (int i = 0; i < size; i++)
                {
                    newArray[i] = array[i];
                }
                array = newArray;
            }
            for (int i = size; i > index; i--)
            {
                array[i] = array[i - 1];
            }
            array[index] = value;
            size++;
        }

        public int DelStart()
        {
            return DelPos(0);
        }

        public int DelEnd()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("List is empty");
            }
            int value = array[size - 1];
            size--;
            return value;
        }

        public int DelPos(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new ArgumentOutOfRangeException();
            }
            int value = array[index];
            for (int i = index; i < size - 1; i++)
            {
                array[i] = array[i + 1];
            }
            size--;
            return value;
        }

        public int Get(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new ArgumentOutOfRangeException();
            }
            return array[index];
        }

        public void Set(int index, int value)
        {
            if (index < 0 || index >= size)
            {
                throw new ArgumentOutOfRangeException();
            }
            array[index] = value;
        }

        public void Reverse()
        {
            for (int i = 0; i < size / 2; i++)
            {
                int temp = array[i];
                array[i] = array[size - 1 - i];
                array[size - 1 - i] = temp;
            }
        }

        public void HalfReverse()
        {
            int halfSize = size / 2;
            int mid = (size + 1) / 2;
            for (int i = 0; i < halfSize; i++)
            {
                int temp = array[i];
                array[i] = array[mid + i];
                array[mid + i] = temp;
            }
        }

        public int Min()
        {
            return array[IndexMin()];
        }

        public int Max()
        {
            return array[IndexMax()];
        }

        public int IndexMin()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("List is empty");
            }
            int indexMin = 0;
            for (int i = 1; i < size; i++)
            {
                if (array[i] < array[indexMin])
                {
                    indexMin = i;
                }
            }
            return indexMin;
        }

        public int IndexMax()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("List is empty");
            }
            int indexMax = 0;
            for (int i = 1; i < size; i++)
            {
                if (array[i] > array[indexMax])
                {
                    indexMax = i;
                }
            }
            return indexMax;
        }

        public void Sort()
        {
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
}