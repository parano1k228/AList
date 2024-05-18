using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnArray
{
    public interface IList
    {
        void Init(int[] ini);
        int Size();
        void Clear();
        int[] ToArray();
        string ToString();
        void AddStart(int value);
        void AddEnd(int value);
        void AddPos(int index, int value);
        int DelStart();
        int DelEnd();
        int DelPos(int index);
        void Set(int index, int value);
        int Get(int index); 
        void Reverse();
        void HalfReverse();
        int Min();
        int Max();
        int IndexMin();
        int IndexMax();
        void Sort();
    }
}
