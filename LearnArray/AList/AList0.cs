using System;
using System.Text;

namespace LearnArray.AList
{
    public class AList0 : IList
    {
        private int[] arr = new int[0];

        public void AddEnd(int value)
        {
            int[] newArr = new int[arr.Length + 1];
            Array.Copy(arr, newArr, arr.Length);
            newArr[arr.Length] = value;
            arr = newArr;
        }

        public void AddPos(int index, int value)
        {
            if (index < 0 || index > arr.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            int[] newArr = new int[arr.Length + 1];
            Array.Copy(arr, newArr, index);
            newArr[index] = value;
            Array.Copy(arr, index, newArr, index + 1, arr.Length - index);
            arr = newArr;
        }

        public void AddStart(int value)
        {
            AddPos(0, value);
        }

        public void Clear()
        {
            arr = new int[0];
        }

        public int DelEnd()
        {
            if (arr.Length == 0)
            {
                throw new InvalidOperationException("The array is empty.");
            }

            int value = arr[arr.Length - 1];
            int[] newArr = new int[arr.Length - 1];
            Array.Copy(arr, newArr, arr.Length - 1);
            arr = newArr;
            return value;
        }

        public int DelPos(int index)
        {
            if (index < 0 || index >= arr.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            int value = arr[index];
            int[] newArr = new int[arr.Length - 1];
            Array.Copy(arr, newArr, index);
            Array.Copy(arr, index + 1, newArr, index, arr.Length - index - 1);
            arr = newArr;
            return value;
        }

        public int DelStart()
        {
            if (arr.Length == 0)
            {
                throw new InvalidOperationException("The array is empty.");
            }

            return DelPos(0);
        }

        public int Get(int index)
        {
            if (index < 0 || index >= arr.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return arr[index];
        }

        public void HalfReverse()
        {
            int mid = arr.Length / 2;
            int start = 0;
            int end = arr.Length % 2 == 0 ? mid : mid + 1;

            while (start < mid)
            {
                int temp = arr[start];
                arr[start] = arr[end];
                arr[end] = temp;
                start++;
                end++;
            }
        }

        public int IndexMax()
        {
            if (arr.Length == 0)
            {
                throw new InvalidOperationException("The array is empty.");
            }

            int maxIndex = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > arr[maxIndex])
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        public int IndexMin()
        {
            if (arr.Length == 0)
            {
                throw new InvalidOperationException("The array is empty.");
            }

            int minIndex = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[minIndex])
                {
                    minIndex = i;
                }
            }

            return minIndex;
        }

        public void Init(int[] ini)
        {
            if (ini == null)
            {
                throw new ArgumentNullException(nameof(ini));
            }

            arr = new int[ini.Length];
            Array.Copy(ini, arr, ini.Length);
        }

        public int Max()
        {
            if (arr.Length == 0)
            {
                throw new InvalidOperationException("The array is empty.");
            }

            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            return max;
        }

        public int Min()
        {
            if (arr.Length == 0)
            {
                throw new InvalidOperationException("The array is empty.");
            }

            int min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }

            return min;
        }

        public void Reverse()
        {
            for (int i = 0, j = arr.Length - 1; i < j; i++, j--)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        public void Set(int index, int value)
        {
            if (index < 0 || index >= arr.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            arr[index] = value;
        }

        public int Size()
        {
            return arr.Length;
        }

        public void Sort()
        {
            Array.Sort(arr);
        }

        public int[] ToArray()
        {
            int[] newArr = new int[arr.Length];
            Array.Copy(arr, newArr, arr.Length);
            return newArr;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                sb.Append(arr[i]);
            }
           return sb.ToString();
        }
    }
}