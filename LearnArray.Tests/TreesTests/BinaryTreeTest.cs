using NUnit.Framework;
using System;
using LearnArray.Tree;
using System.IO;

namespace LearnArray.Tests
{
    [TestFixture]
    public class BinaryTreeTests
    {
        private BinaryTree tree;

        [SetUp]
        public void Setup()
        {
            tree = new BinaryTree();
        }

        [TestCase(new int[] { 5, 3, 7, 1, 9, 2 }, new int[] { 1, 2, 3, 5, 7, 9 }, TestName = "Insert BinaryTree Test")]
        public void Insert_BinaryTreeTest(int[] values, int[] expected)
        {
            foreach (var value in values)
                tree.Insert(value);

            CollectionAssert.AreEqual(expected, tree.ToArray());
        }

        [TestCase(new int[] { 5, 3, 7, 1, 9, 2 }, 7, true, TestName = "Search BinaryTree Test 1")]
        [TestCase(new int[] { 5, 3, 7, 1, 9, 2 }, 4, false, TestName = "Search BinaryTree Test 2")]
        public void Search_BinaryTreeTest(int[] values, int searchValue, bool expectedResult)
        {
            tree.Init(values);
            Assert.AreEqual(expectedResult, tree.Search(searchValue));
        }

        [TestCase(new int[] { 5, 3, 7, 1, 9, 2 }, 7, new int[] { 1, 2, 3, 5, 9 }, TestName = "Delete BinaryTree Test 1")]
        [TestCase(new int[] { 5, 3, 7, 1, 9, 2 }, 3, new int[] { 1, 2, 5, 7, 9 }, TestName = "Delete BinaryTree Test 2")]
        public void Delete_BinaryTreeTest(int[] values, int deleteValue, int[] expected)
        {
            tree.Init(values);
            tree.Delete(deleteValue);
            CollectionAssert.AreEqual(expected, tree.ToArray());
        }

        [TestCase(new int[] { 5, 3, 7, 1, 9, 2 }, TestName = "Clear BinaryTree Test")]
        public void Clear_BinaryTreeTest(int[] values)
        {
            tree.Init(values);
            tree.Clear();
            Assert.AreEqual(0, tree.Size());
            Assert.Throws<InvalidOperationException>(() => tree.Min());
        }

        [TestCase(new int[] { 5, 3, 7, 1, 9, 2 }, 6, TestName = "Size BinaryTree Test")]
        public void Size_BinaryTreeTest(int[] values, int expectedSize)
        {
            tree.Init(values);
            Assert.AreEqual(expectedSize, tree.Size());
        }

        [TestCase(new int[] { 5, 3, 7, 1, 9, 2 }, new int[] { 1, 2, 3, 5, 7, 9 }, TestName = "ToArray BinaryTree Test")]
        public void ToArray_BinaryTreeTest(int[] values, int[] expected)
        {
            tree.Init(values);
            CollectionAssert.AreEqual(expected, tree.ToArray());
        }

        [TestCase(new int[] { 5, 3, 7, 1, 9, 2 }, new int[] { 1, 2, 3, 5, 7, 9 }, TestName = "Init BinaryTree Test")]
        public void Init_BinaryTreeTest(int[] values, int[] expected)
        {
            tree.Init(values);
            CollectionAssert.AreEqual(expected, tree.ToArray());
        }

        [TestCase(new int[] { 5, 3, 7, 1, 9, 2 }, 1, TestName = "Min BinaryTree Test")]
        public void Min_BinaryTreeTest(int[] values, int expected)
        {
            tree.Init(values);
            Assert.AreEqual(expected, tree.Min());
        }

        [TestCase(new int[] { 5, 3, 7, 1, 9, 2 }, 9, TestName = "Max BinaryTree Test")]
        public void Max_BinaryTreeTest(int[] values, int expected)
        {
            tree.Init(values);
            Assert.AreEqual(expected, tree.Max());
        }

        [TestCase(new int[] { 5, 3, 7, 1, 9, 2 }, 1, TestName = "IndexMin BinaryTree Test")]
        public void IndexMin_BinaryTreeTest(int[] values, int expected)
        {
            tree.Init(values);
            Assert.AreEqual(expected, tree.IndexMin());
        }

        [TestCase(new int[] { 5, 3, 7, 1, 9, 2 }, 9, TestName = "IndexMax BinaryTree Test")]
        public void IndexMax_BinaryTreeTest(int[] values, int expected)
        {
            tree.Init(values);
            Assert.AreEqual(expected, tree.IndexMax());
        }

        [TestCase(new int[] { 5, 3, 7, 1, 9, 2 }, new int[] { 9, 7, 5, 3, 2, 1 }, TestName = "Reverse BinaryTree Test")]
        public void Reverse_BinaryTreeTest(int[] values, int[] expected)
        {
            tree.Init(values);
            tree.Reverse();
            CollectionAssert.AreEqual(expected, tree.ToArray());
        }

        [TestCase(new int[] { 5, 3, 7, 1, 9, 2 }, new int[] { 1, 2, 3, 5, 7, 9 }, TestName = "Sort BinaryTree Test")]
        public void Sort_BinaryTreeTest(int[] values, int[] expected)
        {
            tree.Init(values);
            tree.Sort();
            CollectionAssert.AreEqual(expected, tree.ToArray());
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 }, TestName = "HalfReverse BinaryTree Test")]
        public void HalfReverse_BinaryTreeTest(int[] values, int[] expected)
        {
            tree.Init(values);
            tree.HalfReverse();
            CollectionAssert.AreEqual(expected, tree.ToArray());
        }

        [TestCase(new int[] { 5, 3, 7, 1, 9, 2 }, "123579", TestName = "InOrderTraversal BinaryTree Test")]
        public void InOrderTraversal_BinaryTreeTest(int[] values, string expected)
        {
            tree.Init(values);
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                tree.InOrderTraversal();
                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }

        [TestCase(new int[] { 5, 3, 7, 1, 9, 2 }, "531279", TestName = " PreOrderTraversal BinaryTree Test")]
        public void PreOrderTraversal_BinaryTreeTest(int[] values, string expected)
        {
            tree.Init(values);
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                tree.PreOrderTraversal();
                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }

        [TestCase(new int[] { 5, 3, 7, 1, 9, 2 }, "213975", TestName = "PostOrderTraversal BinaryTree Test")]
        public void PostOrderTraversal_BinaryTreeTest(int[] values, string expected)
        {
            tree.Init(values);
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                tree.PostOrderTraversal();
                var result = sw.ToString().Trim();
                Assert.AreEqual(expected, result);
            }
        }
    }
}
