using NUnit.Framework;
using LearnArray.Tree;
using System.Linq;

namespace LearnArray.Tests
{
    [TestFixture]
    public class RedBlackTreeTests
    {
        private RedBlackTree tree;

        [SetUp]
        public void SetUp()
        {
            tree = new RedBlackTree();
        }

        [TestCase(10, 1, new int[] { 10 }, TestName = "Insert RedBlackTree Test 1")]
        [TestCase(5, 1, new int[] { 5 }, TestName = "Insert RedBlackTree Test 2")]
        [TestCase(15, 1, new int[] { 15 }, TestName = "Insert RedBlackTree Test 3")]
        public void Insert_RedBlackTreeTest(int value, int expectedSize, int[] expectedArray)
        {
            tree.Insert(value);
            Assert.AreEqual(expectedSize, tree.Size());
            CollectionAssert.AreEqual(expectedArray, tree.ToArray());
        }

        [TestCase(10, 10, 0, new int[] { }, TestName = "Delete RedBlackTree Test 1")]
        [TestCase(5, 5, 0, new int[] { }, TestName = "Delete RedBlackTree Test 2")]
        [TestCase(15, 15, 0, new int[] { }, TestName = "Delete RedBlackTree Test 3")]
        public void Delete_RedBlackTreeTest(int insertValue, int deleteValue, int expectedSize, int[] expectedArray)
        {
            tree.Insert(insertValue);
            tree.Delete(deleteValue);
            Assert.AreEqual(expectedSize, tree.Size());
            CollectionAssert.AreEqual(expectedArray, tree.ToArray());
        }

        [TestCase(10, true, TestName = "Search RedBlackTree Test 1")]
        [TestCase(5, false, TestName = "Search RedBlackTree Test 2")]
        public void Search_RedBlackTreeTest(int searchValue, bool expectedResult)
        {
            tree.Insert(10);
            Assert.AreEqual(expectedResult, tree.Search(searchValue));
        }

        [TestCase(new int[] { 10, 5, 15 }, 5, TestName = "Min RedBlackTree Test")]
        public void Min_RedBlackTreeTest(int[] values, int expectedMin)
        {
            foreach (var value in values)
            {
                tree.Insert(value);
            }
            Assert.AreEqual(expectedMin, tree.Min());
        }

        [TestCase(new int[] { 10, 5, 15 }, 15, TestName = "Max RedBlackTree Test")]
        public void Max_RedBlackTreeTest(int[] values, int expectedMax)
        {
            foreach (var value in values)
            {
                tree.Insert(value);
            }
            Assert.AreEqual(expectedMax, tree.Max());
        }

        [TestCase(new int[] { 10, 5, 15 }, new int[] { 5, 10, 15 }, TestName = "ToArray RedBlackTree Test")]
        public void ToArray_RedBlackTreeTest(int[] insertValues, int[] expectedArray)
        {
            tree.Init(insertValues);
            int[] array = tree.ToArray();
            CollectionAssert.AreEqual(expectedArray, array);
        }

        [TestCase(new int[] { 10, 5, 15, 2, 7, 12, 20 }, TestName = "Init RedBlackTree Test")]
        public void Init_RedBlackTreeTest(int[] values)
        {
            tree.Init(values);
            int[] array = tree.ToArray();
            CollectionAssert.AreEqual(values.OrderBy(x => x).ToArray(), array);
        }

        [TestCase(new int[] { 10, 5, 15 }, new int[] { 5, 10, 15 }, TestName = "Sort RedBlackTree Test")]
        public void Sort_RedBlackTreeTest(int[] insertValues, int[] expectedArray)
        {
            tree.Init(insertValues);
            tree.Sort();
            int[] sortedArray = tree.ToArray();
            CollectionAssert.AreEqual(expectedArray, sortedArray);
        }

        [TestCase(new int[] { 10, 5, 15 }, new int[] { 15, 10, 5 }, TestName = "Reverse RedBlackTree Test")]
        public void Reverse_RedBlackTreeTest(int[] insertValues, int[] expectedArray)
        {
            tree.Init(insertValues);
            tree.Reverse();
            int[] reversedArray = tree.ToArray();
            CollectionAssert.AreEqual(expectedArray, reversedArray);
        }

        [TestCase(new int[] { 10, 5, 2, 7 }, new int[] { 2, 5, 7, 10 }, TestName = "HalfReverse RedBlackTree Test")]
        public void HalfReverse_RedBlackTreeTest(int[] insertValues, int[] expectedArray)
        {
            tree.Init(insertValues);
            tree.HalfReverse();
            int[] halfReversedArray = tree.ToArray();
            CollectionAssert.AreEqual(expectedArray, halfReversedArray);
        }

        [TestCase(new int[] { 10, 5, 15 }, TestName = "Clear RedBlackTree Test")]
        public void Clear_RedBlackTreeTest(int[] insertValues)
        {
            tree.Init(insertValues);
            tree.Clear();
            Assert.AreEqual(0, tree.Size());
            Assert.IsFalse(tree.ToArray().Any());
        }
    }
}
