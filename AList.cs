﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnArray
{
    public class AList : IList
    {
        int[] array = new int[0];

        public void Init(int[] ini)
        {
            if (ini == null)
            {
                throw new ArgumentNullException(nameof(ini));
            }

            if (ini.Length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(ini));
            }

            array = new int[ini.Length];
            for (int i = 0; i < ini.Length; i++)
            {
                array[i] = ini[i];
            }
        }
        public int Size()
        {
            return array.Length;
        }

        public void Clear()
        {
            array = Array.Empty<int>();
        }

        public int[] ToArray()
        {
            int[] result = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = array[i];
            }

            return result;
        }

        public string ToString()
        {
            StringBuilder result = new StringBuilder();
            for(int i = 0; i < array.Length; i++)
            {
                result.AppendFormat("{0}", array[i]);
            }

            return result.ToString();
        }

        public void AddStart(int value)
        {
            int[] newArray = new int[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i + 1] = array[i];
            }
            newArray[0] = value;
            array = newArray;
        }

        public void AddEnd(int value)
        {
            int[] newArray = new int[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            newArray[array.Length] = value;
            array = newArray;
        }

        public void AddPos(int pos, int value)
        {
            if (array == null || array.Length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            if (pos < 0 || pos > array.Length)
            {
                throw new IndexOutOfRangeException(nameof(pos));
            }

            int[] newArray = new int[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                if (i < pos)
                {
                    newArray[i] = array[i];
                }
                if (i >= pos)
                {
                    newArray[i + 1] = array[i];
                }
            }

            newArray[pos] = value;
            array = newArray;
        }

        public int DelStart()
        {
            if (array == null || array.Length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            int removedElement = array[0]; 
            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }

            Array.Resize(ref array, array.Length - 1);

            return removedElement;
        }

        public int DelEnd()
        {
            if (array == null || array.Length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            int removedElement = array[array.Length - 1]; 
            Array.Resize(ref array, array.Length - 1); 

            return removedElement;
        }

        public int DelPos(int pos)
        {
            if (array == null || array.Length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            if (pos < 0 || pos >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(pos));
            }

            int deletedElement = array[pos];

            for (int i = pos; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }

            Array.Resize(ref array, array.Length - 1);

            return deletedElement;
        }

        public void Set(int index, int value)
        {
            if (index >= 0 && index < array.Length)
            {
                array[index] = value;
            }
            else
            {
                Console.WriteLine("Index out of range");
            }
        }

        public int Get(int index)
        {
            if (index >= 0 && index < array.Length)
            {
                return array[index];
            }
            else
            {
                Console.WriteLine("Index out of range");
                return -1;
            }
        }

        public void Reverse()
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            int reversedArray;
            for (var i = array.Length - 1; i >= 0; i--)
            {
                reversedArray = array[i];
            }
        }

        public void HalfReverse()
        {
            int length = array.Length;
            int halfLength = length / 2;

            for (int i = 0; i < halfLength; i++)
            {
                int temp = array[i];
                array[i] = array[length - halfLength + i];
                array[length - halfLength + i] = temp;
            }
        }

        public int Min()
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            int minElement = array[0];
            foreach (int element in array)
            {
                if (element < minElement)
                    minElement = element;
            }

            return minElement;
        }

        public int Max()
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            int maxElement = array[0];

            foreach (int element in array)
            {
                if (element > maxElement)
                    maxElement = element;
            }

            return maxElement;
        }

        public int IndexMin()
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            var index = 0;
            var minValue = int.MaxValue;

            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] <= minValue)
                {
                    index = i;
                    minValue = array[i];
                }
            }

            return index;
        }

        public int IndexMax()
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            var index = 0;
            var maxValue = int.MinValue;

            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] >= maxValue)
                {
                    index = i;
                    maxValue = array[i];
                }
            }

            return index;
        }

        public void Sort()
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
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
