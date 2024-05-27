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
            return size;
        }

        public void Clear()
        {
            size = 0;
            array = new int[size];
        }

        public int[] ToArray()
        {
            int[] result = new int[size];
            Array.Copy(array, result, size);

            return result;
        }

        public string ToString()
        {
            if (size == 0)
            {
                return " ";
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                sb.Append(array[i]);
            }

            return sb.ToString();
        }

        public void AddStart(int value)
        {
            throw new NotImplementedException();
        }

        public void AddEnd(int value)
        {
            throw new NotImplementedException();
        }

        public void AddPos(int index, int value)
        {
            throw new NotImplementedException();
        }

        public int DelStart()
        {
            throw new NotImplementedException();
        }

        public int DelEnd()
        {
            throw new NotImplementedException();
        }

        public int DelPos(int index)
        {
            throw new NotImplementedException();
        }

        public int Get(int index)
        {
            throw new NotImplementedException();
        }

        public void Set(int index, int value)
        {
            throw new NotImplementedException();
        }
        public void Reverse()
        {
            throw new NotImplementedException();
        }

        public void HalfReverse()
        {
            throw new NotImplementedException();
        }
        public int Min()
        {
            throw new NotImplementedException();
        }

        public int Max()
        {
            throw new NotImplementedException();
        }

        public int IndexMin()
        {
            throw new NotImplementedException();
        }

        public int IndexMax()
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }
    }
}

