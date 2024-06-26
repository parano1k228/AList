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

        [Test]
        public void TestInsert()
        {
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(1);
            tree.Insert(9);
            tree.Insert(2);

            int[] expected = { 1, 2, 3, 5, 7, 9 };
            CollectionAssert.AreEqual(expected, tree.ToArray());
        }

        [Test]
        public void TestSearch()
        {
            int[] array = { 5, 3, 7, 1, 9, 2 };
            tree.Init(array);

            Assert.IsTrue(tree.Search(7));
            Assert.IsFalse(tree.Search(4));
        }

        [Test]
        public void TestDelete()
        {
            int[] array = { 5, 3, 7, 1, 9, 2 };
            tree.Init(array);

            tree.Delete(7);
            int[] expected = { 1, 2, 3, 5, 9 };
            CollectionAssert.AreEqual(expected, tree.ToArray());

            tree.Delete(3);
            expected = new int[] { 1, 2, 5, 9 };
            CollectionAssert.AreEqual(expected, tree.ToArray());
        }

        [Test]
        public void TestClear()
        {
            int[] array = { 5, 3, 7, 1, 9, 2 };
            tree.Init(array);

            tree.Clear();
            Assert.AreEqual(0, tree.Size());
            Assert.Throws<InvalidOperationException>(() => tree.Min());
        }

        [Test]
        public void TestSize()
        {
            int[] array = { 5, 3, 7, 1, 9, 2 };
            tree.Init(array);

            Assert.AreEqual(6, tree.Size());
        }

        [Test]
        public void TestToArray()
        {
            int[] array = { 5, 3, 7, 1, 9, 2 };
            tree.Init(array);

            int[] expected = { 1, 2, 3, 5, 7, 9 };
            CollectionAssert.AreEqual(expected, tree.ToArray());
        }

        [Test]
        public void TestInit()
        {
            int[] array = { 5, 3, 7, 1, 9, 2 };
            tree.Init(array);

            int[] expected = { 1, 2, 3, 5, 7, 9 };
            CollectionAssert.AreEqual(expected, tree.ToArray());
        }

        [Test]
        public void TestMin()
        {
            int[] array = { 5, 3, 7, 1, 9, 2 };
            tree.Init(array);

            Assert.AreEqual(1, tree.Min());
        }

        [Test]
        public void TestMax()
        {
            int[] array = { 5, 3, 7, 1, 9, 2 };
            tree.Init(array);

            Assert.AreEqual(9, tree.Max());
        }

        [Test]
        public void TestIndexMin()
        {
            int[] array = { 5, 3, 7, 1, 9, 2 };
            tree.Init(array);

            Assert.AreEqual(1, tree.IndexMin());
        }

        [Test]
        public void TestIndexMax()
        {
            int[] array = { 5, 3, 7, 1, 9, 2 };
            tree.Init(array);

            Assert.AreEqual(9, tree.IndexMax());
        }

        [Test]
        public void TestReverse()
        {
            int[] array = { 5, 3, 7, 1, 9, 2 };
            tree.Init(array);
            tree.Reverse();

            int[] expected = { 9, 7, 5, 3, 2, 1 };
            CollectionAssert.AreEqual(expected, tree.ToArray());
        }

        [Test]
        public void TestSort()
        {
            int[] array = { 5, 3, 7, 1, 9, 2 };
            tree.Init(array);
            tree.Sort();

            int[] expected = { 1, 2, 3, 5, 7, 9 };
            CollectionAssert.AreEqual(expected, tree.ToArray());
        }

        [Test]
        public void TestHalfReverse()
        {
            int[] array = { 1, 2, 3, 4 };
            tree.Init(array);
            tree.HalfReverse();

            int[] expected = { 1, 2, 3, 4 };
            CollectionAssert.AreEqual(expected, tree.ToArray());
        }

        [Test]
        public void TestInOrderTraversal()
        {
            int[] array = { 5, 3, 7, 1, 9, 2 };
            tree.Init(array);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                tree.InOrderTraversal();
                var result = sw.ToString().Trim();
                Assert.AreEqual("123579", result);
            }
        }

        [Test]
        public void TestPreOrderTraversal()
        {
            int[] array = { 5, 3, 7, 1, 9, 2 };
            tree.Init(array);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                tree.PreOrderTraversal();
                var result = sw.ToString().Trim();
                Assert.AreEqual("531279", result);
            }
        }

        [Test]
        public void TestPostOrderTraversal()
        {
            int[] array = { 5, 3, 7, 1, 9, 2 };
            tree.Init(array);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                tree.PostOrderTraversal();
                var result = sw.ToString().Trim();
                Assert.AreEqual("213975", result);
            }
        }
    }
}