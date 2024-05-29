using NUnit.Framework;
using System;
using LearnArray.AList;
using LearnArray.LList;

namespace LearnArray.Tests
{
    [TestFixture(TypeArgs = new Type[] { typeof(AList0) })]
    [TestFixture(TypeArgs = new Type[] { typeof(AList1) })]
    [TestFixture(TypeArgs = new Type[] { typeof(LList1) })]
  //[TestFixture(TypeArgs = new Type[] { typeof(LList2) })]
    [TestFixture(TypeArgs = new Type[] { typeof(LListR) })]
    public class ComplexCheckTest<T> where T : IList, new()
    {
        private readonly IList list = new T();

        [Test]
        public void ComplexCheck1()
        {
            int[] testData1 = { 1, 2, 3, 4 };

            list.Init(testData1);
            list.AddEnd(4);
            list.AddStart(0);
            list.AddPos(2, 99);
            list.Set(1, 8);
            list.DelPos(1);
            list.DelStart();
            list.DelEnd();
            list.Reverse();
            list.Sort();
            list.HalfReverse();
            Assert.AreEqual(new int[] { 4, 99, 2, 3 }, list.ToArray(), "HalfReverse.");

            //Min, Max, IndexMin, IndexMax
            Assert.AreEqual(2, list.Min(), "Min.");
            Assert.AreEqual(99, list.Max(), "Max.");
            Assert.AreEqual(2, list.IndexMin(), "IndexMin.");
            Assert.AreEqual(1, list.IndexMax(), "IndexMax.");
        }

        [Test]
        public void ComplexCheck2()
        {
            int[] testData2 = { 1, 2, 3, 5, 4 };

            list.Init(testData2);
            list.DelPos(1);
            list.DelStart();
            list.DelEnd();
            list.Reverse();
            list.AddEnd(4);
            list.AddStart(0);
            list.AddPos(2, 99);
            list.Set(1, 8);
            list.HalfReverse();
            list.Sort();

            //Min, Max, IndexMin, IndexMax
            Assert.AreEqual(0, list.Min(), "Min.");
            Assert.AreEqual(99, list.Max(), "Max.");
            Assert.AreEqual(0, list.IndexMin(), "IndexMin.");
            Assert.AreEqual(4, list.IndexMax(), "IndexMax.");
        }

        [Test]
        public void ComplexCheck3()
        {
            int[] testData3 = { 1, 2, 3, 5, 4 };

            list.Init(testData3);
            list.Reverse();
            list.AddEnd(4);
            list.AddStart(0);
            list.AddPos(2, 99);
            list.Set(1, 8);
            list.HalfReverse();
            list.DelPos(1);
            list.DelStart();
            list.DelEnd();
            //Min, Max, IndexMin, IndexMax
            Assert.AreEqual(0, list.Min(), "Min.");
            Assert.AreEqual(99, list.Max(), "Max.");
            Assert.AreEqual(2, list.IndexMin(), "IndexMin.");
            Assert.AreEqual(4, list.IndexMax(), "IndexMax.");
        }
    }
}