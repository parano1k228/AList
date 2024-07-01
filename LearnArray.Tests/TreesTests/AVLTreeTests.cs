using NUnit.Framework;
using LearnArray.Tree;
using System.Linq;

namespace LearnArray.Tests
{
    [TestFixture]
    public class AVLTreeTests
    {
        private AVLTree tree;

        [SetUp]
        public void SetUp()
        {
            tree = new AVLTree();
        }

        [TestCase(new int[] { 10 }, 1, new int[] { 10 }, TestName = "Insert AVLTree Test")]
        public void Insert_AVLTreeTest(int[] values, int expectedSize, int[] expectedArray)
        {
            foreach (var value in values)
                tree.Insert(value);

            Assert.AreEqual(expectedSize, tree.Size());
            CollectionAssert.AreEqual(expectedArray, tree.ToArray());
        }

        [TestCase(new int[] { 10 }, new int[] { 10 }, 0, new int[] { }, TestName = "Delete AVLTree Test")]
        public void Delete_AVLTreeTest(int[] initialValues, int[] deleteValues, int expectedSize, int[] expectedArray)
        {
            tree.Init(initialValues);
            foreach (var value in deleteValues)
                tree.Delete(value);

            Assert.AreEqual(expectedSize, tree.Size());
            CollectionAssert.AreEqual(expectedArray, tree.ToArray());
        }

        [TestCase(new int[] { 10 }, 10, true, TestName = "Search AVLTree Test 1")]
        [TestCase(new int[] { 10 }, 5, false, TestName = "Search AVLTree Test 2")]
        public void Search_AVLTreeTest(int[] values, int searchValue, bool expectedResult)
        {
            tree.Init(values);
            Assert.AreEqual(expectedResult, tree.Search(searchValue));
        }

        [TestCase(new int[] { 10, 5, 15 }, 5, TestName = "Min AVLTree Test")]
        public void Min_AVLTreeTest(int[] values, int expectedMin)
        {
            tree.Init(values);
            Assert.AreEqual(expectedMin, tree.Min());
        }

        [TestCase(new int[] { 10, 5, 15 }, 15, TestName = "Max AVLTree Test")]
        public void Max_AVLTreeTest(int[] values, int expectedMax)
        {
            tree.Init(values);
            Assert.AreEqual(expectedMax, tree.Max());

        }

        [TestCase(new int[] { 10, 5, 15 }, new int[] { 5, 10, 15 }, TestName = "ToArray AVLTree Test")]
        public void ToArray_AVLTreeTest(int[] values, int[] expectedArray)
        {
            tree.Init(values);
            CollectionAssert.AreEqual(expectedArray, tree.ToArray());
        }

        [TestCase(new int[] { 10, 5, 15 }, new int[] { 5, 10, 15 }, TestName = "Init AVLTree Test")]
        public void Init_AVLTreeTest(int[] values, int[] expectedArray)
        {
            tree.Init(values);
            CollectionAssert.AreEqual(expectedArray.OrderBy(x => x).ToArray(), tree.ToArray());
        }

        [TestCase(new int[] { 10, 5, 15 }, new int[] { 5, 10, 15 }, TestName = "Sort AVLTree Test")]
        public void Sort_AVLTreeTest(int[] values, int[] expectedArray)
        {
            tree.Init(values);
            tree.Sort();
            CollectionAssert.AreEqual(expectedArray, tree.ToArray());
        }

        [TestCase(new int[] { 10, 5, 15 }, new int[] { 15, 10, 5 }, TestName = "Reverse AVLTree Test")]
        public void Reverse_AVLTreeTest(int[] values, int[] expectedArray)
        {
            tree.Init(values);
            tree.Reverse();
            CollectionAssert.AreEqual(expectedArray, tree.ToArray());
        }

        [TestCase(new int[] { 10, 5, 15, 2, 7 }, new int[] { 2, 5, 7, 10, 15}, TestName = "HalfReverse AVLTree Test")]
        public void HalfReverse_AVLTreeTest(int[] values, int[] expectedArray)
        {
            tree.Init(values);
            tree.HalfReverse();
            CollectionAssert.AreEqual(expectedArray, tree.ToArray());
        }

        [TestCase(new int[] { 10, 5 }, 0, TestName = "Clear AVLTree Test")]
        public void Clear_AVLTreeTest(int[] values, int expectedSize)
        {
            tree.Init(values);
            tree.Clear();
            Assert.AreEqual(expectedSize, tree.Size());
            Assert.IsFalse(tree.ToArray().Any());
        }
    }
}
