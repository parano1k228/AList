using NUnit.Framework;
using LearnArray;
using System;
using System.Linq;
using LearnArray.AList;
using LearnArray.LList;

namespace LearnArray.Tests
{
    [TestFixture(TypeArgs = new Type[] { typeof(AList0) })]
    [TestFixture(TypeArgs = new Type[] { typeof(AList1) })]
    [TestFixture(TypeArgs = new Type[] { typeof(LList1) })]
    [TestFixture(TypeArgs = new Type[] { typeof(LList2) })]
    [TestFixture(TypeArgs = new Type[] { typeof(LListR) })]
    public class AlistTest<T> where T : IList, new()
    {
        private readonly IList list = new T();

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, TestName = "Init 1")]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 }, TestName = "Init 2")]
        [TestCase(new int[] { -1, -2, -3 }, new int[] { -1, -2, -3 }, TestName = "Init 3")]
        public void InitTest1(int[] arr, int[] expected)
        {
            list.Init(arr);

            Assert.AreEqual(expected, list.ToArray());
        }

        [Test]
        public void InitTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new int[] { 1 }, 1, TestName = "Size 1")]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, TestName = "Size 2")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 10, TestName = "Size 3")]
        [TestCase(new int[] { }, 0, TestName = "Size 4")]
        public void SizeTest1(int[] arr, int expected)
        {
            list.Init(arr);
            int result = list.Size();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SizeTest2()
        {
            Assert.Throws<ArgumentNullException>(() => list.Init(null));
        }

        [TestCase(new int[] { 1 }, new int[] { }, TestName = "Clear 1")]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { }, TestName = "Clear 2")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { }, TestName = "Clear 3")]
        public void ClearTest1(int[] arr, int[] expected)
        {
            list.Init(arr);
            list.Clear();
            var result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(0, list.Size());
        }
        
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, TestName = "ToArray 1")]
        [TestCase(new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 }, TestName = "ToArray 2")]
        [TestCase(new int[] { -1, -2, -3 }, new int[] { -1, -2, -3 }, TestName = "ToArray 3")]
        public void ToArrayTest1(int[] arr, int[] expected)
        {
            list.Init(arr);
            int[] result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
        }
        
        [TestCase(new int[] { 1, 2, 3 }, "123", TestName = "ToString 1")]
        [TestCase(new int[] { 0, 0, 0 }, "000", TestName = "ToString 2")]
        [TestCase(new int[] { -1, -2, -3 }, "-1-2-3", TestName = "ToString 3")]
        public void ToStringTest1(int[] arr, string expected)
        {
            list.Init(arr);
            string result = list.ToString();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
        }

        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] { 4, 1, 2, 3 }, TestName = "AddStart 1")]
        [TestCase(new int[] { 0, 0, 0 }, 1, new int[] { 1, 0, 0, 0 }, TestName = "AddStart 2")]
        [TestCase(new int[] { -1, -2, -3 }, -4, new int[] { -4, -1, -2, -3 }, TestName = "AddStart 3")]
        public void AddStartTest1(int[] arr, int value, int[] expected)
        {
            list.Init(arr);
            list.AddStart(value);
            int[] result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
        }

        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] { 1, 2, 3, 4 }, TestName = "AddEnd 1")]
        [TestCase(new int[] { 0, 0, 0 }, 1, new int[] { 0, 0, 0, 1 }, TestName = "AddEnd 2")]
        [TestCase(new int[] { -1, -2, -3 }, -4, new int[] { -1, -2, -3, -4 }, TestName = "AddEnd 3")]
        public void AddEndTest1(int[] arr, int value, int[] expected)
        {
            list.Init(arr);
            list.AddEnd(value);
            int[] result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
        }


        [TestCase(new int[] { 1, 2, 3 }, 2, 4, new int[] { 1, 2, 4, 3 }, TestName = "AddPos 1")]
        [TestCase(new int[] { 0, 0, 0 }, 2, 1, new int[] { 0, 0, 1, 0 }, TestName = "AddPos 2")]
        [TestCase(new int[] { -1, -2, -3 }, 1, -4, new int[] { -1, -4, -2, -3 }, TestName = "AddPos 3")]
        public void AddPosTest1(int[] arr, int index, int value, int[] expected)
        {
            list.Init(arr);
            list.AddPos(index, value);
            int[] result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
        }

        [TestCase(new int[] { 4, 1, 2, 3 }, new int[] { 1, 2, 3 }, TestName = "DelStart 1")]
        [TestCase(new int[] { 1, 0, 0, 0 }, new int[] { 0, 0, 0 }, TestName = "DelStart 2")]
        [TestCase(new int[] { -4, -1, -2, -3 }, new int[] { -1, -2, -3 }, TestName = "DelStart 3")]
        public void DelStartTest1(int[] arr, int[] expected)
        {
            list.Init(arr);
            list.DelStart();
            int[] result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 }, TestName = "DelEnd 1")]
        [TestCase(new int[] { 0, 0, 0, 1 }, new int[] { 0, 0, 0 }, TestName = "DelEnd 2")]
        [TestCase(new int[] { -1, -2, -3, -4 }, new int[] { -1, -2, -3 }, TestName = "DelEnd 3")]
        public void DelEndTest2(int[] arr, int[] expected)
        {
            list.Init(arr);
            list.DelEnd();
            int[] result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 2, new int[] { 1, 2, 4 }, TestName = "DelPos 1")]
        [TestCase(new int[] { 0, 1, 0, 0 }, 1, new int[] { 0, 0, 0 }, TestName = "DelPos 2")]
        [TestCase(new int[] { -1, -2, -3, -4, -5 }, 3, new int[] { -1, -2, -3, -5 }, TestName = "DelPos 3")]
        public void DelPosTest1(int[] arr, int pos, int[] expected)
        {
            list.Init(arr);
            list.DelPos(pos);
            int[] result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
        }

        [TestCase(new int[] { 1, 2, 3 }, 1, 4, new int[] { 1, 4, 3 }, TestName = "Set 1")]
        [TestCase(new int[] { 0, 0, 0, 0 }, 2, 1, new int[] { 0, 0, 1, 0 }, TestName = "Set 2")]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 7, new int[] { 1, 2, 3, 7, 5 }, TestName = "Set 3")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 7 }, 4, 6, new int[] { 1, 2, 3, 4, 6, 7 }, TestName = "Set 4")]
        public void SetTest1(int[] arr, int index, int value, int[] expected)
        {
            list.Init(arr);
            list.Set(index, value);
            int[] result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
        }

        [TestCase(new int[] { 2, 1, 3 }, 0, 2, TestName = "Get 1")]
        [TestCase(new int[] { 1, 2, 3 }, 1, 2, TestName = "Get 2")]
        [TestCase(new int[] { 0, 0, 1 }, 2, 1, TestName = "Get 3")]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 3, 4, TestName = "Get 4")]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 5, TestName = "Get 5")]
        public void GetTest1(int[] arr, int index, int value)
        {
            list.Init(arr);
            int expected = value;
            int result = list.Get(index);

            Assert.AreEqual(expected, result);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 }, TestName = "Reverse 1")]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 }, TestName = "Reverse 2")]
        public void ReverseTest1(int[] arr, int[] expected)
        {
            list.Init(arr);
            list.Reverse();
            int[] result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 3, 4, 1, 2 }, TestName = "HalfReverse 1")]
        [TestCase(new int[] { 0, 1, 1, 0 }, new int[] { 1, 0, 0, 1 }, TestName = "HalfReverse 2")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 }, TestName = "HalfReverse 3")]
        public void HalfReverse_Test(int[] arr, int[] expected)
        {
            list.Init(arr);
            list.HalfReverse();
            int[] result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
        }

        [TestCase(new int[] { 1, 3, 2 }, 1, TestName = "Min 1")]
        [TestCase(new int[] { 4, 5, 3, 6 }, 3, TestName = "Min 2")]
        [TestCase(new int[] { 5, 8, 7, 4 }, 4, TestName = "Min 3")]
        public void MinTest1(int[] arr, int expected)
        {
            list.Init(arr);
            int result = list.Min();

            Assert.AreEqual(expected, result);
        }

        [TestCase(new int[] { 3, 1, 2 }, 3, TestName = "Max 1")]
        [TestCase(new int[] { 4, 5, 8, 6, 7 }, 8, TestName = "Max 2")]
        [TestCase(new int[] { 3, 4, 5, 7 }, 7, TestName = "Max 3")]
        public void MaxTest1(int[] arr, int expected)
        {
            list.Init(arr);
            int result = list.Max();
            list.ToArray();

            Assert.AreEqual(expected, result);
        }

        [TestCase(new int[] { 1, 2, 3 }, 0, TestName = "IndexMin 1")]
        [TestCase(new int[] { 4, 2, 3, 1, 5, 6 }, 3, TestName = "IndexMin 2")]
        [TestCase(new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 1 }, 9, TestName = "IndexMin 3")]
        public void IndexMinTest1(int[] arr, int expected)
        {
            list.Init(arr);
            int result = list.IndexMin();

            Assert.AreEqual(expected, result);

        }

        [TestCase(new int[] { 3, 2, 1 }, 0, TestName = "IndeMax 1")]
        [TestCase(new int[] { 4, 2, 3, 6, 1, 5 }, 3, TestName = "IndexMax 2")]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 9, TestName = "IndexMax 3")]
        public void IndexMaxTest1(int[] arr, int expected)
        {
            list.Init(arr);
            int result = list.IndexMax();

            Assert.AreEqual(expected, result);
        }

        [TestCase(new int[] { 2, 1, 3 }, new int[] { 1, 2, 3 }, TestName = "Sort 1")]
        [TestCase(new int[] { 2, 1, 3, 5, 4 }, new int[] { 1, 2, 3, 4, 5 }, TestName = "Sort 2")]
        [TestCase(new int[] { 1, 2, 3, 6, 4, 5, 7, 10, 9, 8 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, TestName = "Sort 3")]
        public void SortTest1(int[] arr, int[] expected)
        {
            list.Init(arr);
            list.Sort();
            int[] result = list.ToArray();

            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected.Count(), result.Count());
        }
    }
}

