using System;
using LearnArray.Tree;
using NUnit.Framework;

namespace LearnArray.Tests
{
    [TestFixture]
    public class BinaryTreeTests
    {
        [Test]
        public void Insert_ValuesInsertedInOrder_TraversalMatches()
        {
            BinaryTree tree = new BinaryTree();

            // Insert values
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(8);
            tree.Insert(1);
            tree.Insert(4);
            tree.Insert(7);
            tree.Insert(9);

            // Expected in-order traversal
            int[] expected = { 1, 3, 4, 5, 7, 8, 9 };

            // Perform in-order traversal
            int[] actual = PerformInOrderTraversal(tree);

            // Compare traversal result with expected
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Search_ValueExists_ReturnsTrue()
        {
            BinaryTree tree = new BinaryTree();

            // Insert values
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(8);
            tree.Insert(1);
            tree.Insert(4);
            tree.Insert(7);
            tree.Insert(9);

            // Search for existing value
            int searchValue = 7;
            bool isFound = tree.Search(searchValue);

            // Assert
            Assert.IsTrue(isFound);
        }

        [Test]
        public void Search_ValueDoesNotExist_ReturnsFalse()
        {
            BinaryTree tree = new BinaryTree();

            // Insert values
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(8);
            tree.Insert(1);
            tree.Insert(4);
            tree.Insert(7);
            tree.Insert(9);

            // Search for non-existing value
            int searchValue = 6;
            bool isFound = tree.Search(searchValue);

            // Assert
            Assert.IsFalse(isFound);
        }

        private int[] PerformInOrderTraversal(BinaryTree tree)
        {
            var output = new System.IO.StringWriter();
            Console.SetOut(output);

            tree.InOrderTraversal();

            return Array.ConvertAll(output.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
        }
    }
}
