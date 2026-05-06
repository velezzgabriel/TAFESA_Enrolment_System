using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TAFESA_Enrolment_System.Model;

namespace TAFESA_Enrolment_System.Tests
{
    // =========================================================================
    // SINGLY LINKED LIST TESTS
    // =========================================================================
    [TestFixture]
    public class SingleLinkedListTests
    {   // Declaration at class level so all tests can use the same variables without needing to re-declare them
        private SinglyLinkedList<Student> list;
        private Student s1001;
        private Student s2001;
        private Student s3001;
        private Student s4001;
        private Student s5001;


        // SetUp method runs before each test, so we get a fresh list and new Student objects for every test case
        [SetUp]
        public void SetUp()
        {
            list = new SinglyLinkedList<Student>();
            s1001 = new Student("S1001");
            s2001 = new Student("S2001");
            s3001 = new Student("S3001");
            s4001 = new Student("S4001");
            s5001 = new Student("S5001");
        }

        // Algorithm:    Single Linked List – AddFirst
        // Test Case:    Add Student S1001 to the Head of an empty list
        // Expected:     Head.Value.StudentID == "S1001", Count == 1
        [Test]
        public void AddFirst_ToEmptyList_HeadIsCorrectAndCountIsOne()
        {
            try
            {
                // Act
                list.AddFirst(s1001);

                // Assert
                Assert.That(list.Head.Value.StudentID, Is.EqualTo("S1001"),
                    "Head should be S1001 after AddFirst on empty list");
                Assert.That(list.Count, Is.EqualTo(1),
                    "Count should be 1 after adding one node");
            }
            catch (Exception ex)
            {
                // An unexpected exception in AddFirst
                Console.WriteLine("Unexpected error in AddFirst test: " + ex.Message);
                Assert.Fail("AddFirst threw an unexpected exception: " + ex.Message);
            }
        }

        // Algorithm:    Single Linked List – AddLast
        // Test Case:    Add Student S5001 to the Tail of a list already
        //               containing S1001
        // Expected:     Tail.Value.StudentID == "S5001", Count == 2
        [Test]
        public void AddLast_ToExistingList_TailIsCorrectAndCountIsTwo()
        {
            try
            {
                // Arrange
                list.AddFirst(s1001);

                // Act
                list.AddLast(s5001);

                // Assert
                Assert.That(list.Tail.Value.StudentID, Is.EqualTo("S5001"),
                    "Tail should be S5001 after AddLast");
                Assert.That(list.Count, Is.EqualTo(2),
                    "Count should be 2 after adding two nodes");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error in AddLast test: " + ex.Message);
                Assert.Fail("AddLast threw an unexpected exception: " + ex.Message);
            }
        }

        // Algorithm:    Single Linked List – Contains (found)
        // Test Case:    Call Contains() for a Student that exists in the list
        // Expected:     Returns true
        [Test]
        public void Contains_StudentThatExists_ReturnsTrue()
        {
            try
            {
                // Arrange
                list.Add(s1001);
                list.Add(s2001);
                list.Add(s3001);

                // Act
                bool result = list.Contains(s3001);

                // Assert
                Assert.That(result, Is.True,
                    "Contains should return true for a Student that is in the list");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error in Contains (found) test: " + ex.Message);
                Assert.Fail("Contains threw an unexpected exception: " + ex.Message);
            }
        }


        // Algorithm:    Single Linked List – RemoveFirst
        // Test Case:    Remove the Head node from a 3-node list
        // Expected:     Head.Value.StudentID is the second node,
        //               Count decrements by 1
        [Test]
        public void RemoveFirst_FromThreeNodeList_HeadUpdatesAndCountDecrements()
        {
            try
            {
                // Arrange
                list.Add(s1001);
                list.Add(s2001);
                list.Add(s3001);

                // Act
                list.RemoveFirst();

                // Assert
                Assert.That(list.Head.Value.StudentID, Is.EqualTo("S2001"),
                    "After RemoveFirst, S2001 should be the new Head");
                Assert.That(list.Count, Is.EqualTo(2),
                    "Count should decrement from 3 to 2 after RemoveFirst");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error in RemoveFirst test: " + ex.Message);
                Assert.Fail("RemoveFirst threw an unexpected exception: " + ex.Message);
            }
        }

        // Algorithm:    Single Linked List – RemoveLast
        // Test Case:    Remove the Tail node from a 3-node list
        // Expected:     Tail.Value.StudentID is the second-to-last node,
        //               Count decrements by 1
        [Test]
        public void RemoveLast_FromThreeNodeList_TailUpdatesAndCountDecrements()
        {
            try
            {
                // Arrange
                list.Add(s1001);
                list.Add(s2001);
                list.Add(s3001);

                // Act
                list.RemoveLast();

                // Assert
                Assert.That(list.Tail.Value.StudentID, Is.EqualTo("S2001"),
                    "After RemoveLast, S2001 should be the new Tail");
                Assert.That(list.Count, Is.EqualTo(2),
                    "Count should decrement from 3 to 2 after RemoveLast");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error in RemoveLast test: " + ex.Message);
                Assert.Fail("RemoveLast threw an unexpected exception: " + ex.Message);
            }
        }
    }


    // =========================================================================
    // DOUBLY LINKED LIST TESTS
    // =========================================================================
    [TestFixture]
    public class DoublyLinkedListTests
    {
        private DoublyLinkedList<Student> list;
        private Student s1001;
        private Student s2001;
        private Student s3001;
        private Student s4001;
        private Student s5001;

        [SetUp]
        public void SetUp()
        {
            list = new DoublyLinkedList<Student>();
            s1001 = new Student("S1001");
            s2001 = new Student("S2001");
            s3001 = new Student("S3001");
            s4001 = new Student("S4001");
            s5001 = new Student("S5001");
        }

        // Algorithm:    Doubly Linked List – AddFirst
        // Test Case:    Add Student S1001 to the Head of an empty list
        // Expected:     Head.Value.StudentID == "S1001",
        //               Head.Previous == null, Count == 1
        [Test]
        public void AddFirst_ToEmptyList_HeadIsCorrectPreviousIsNullAndCountIsOne()
        {
            try
            {
                // Act
                list.AddFirst(s1001);

                // Assert
                Assert.That(list.Head.Value.StudentID, Is.EqualTo("S1001"),
                    "Head should be S1001 after AddFirst on empty list");
                Assert.That(list.Head.Previous, Is.Null,
                    "Head.Previous should always be null — nothing comes before Head");
                Assert.That(list.Count, Is.EqualTo(1),
                    "Count should be 1 after adding one node");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error in AddFirst test: " + ex.Message);
                Assert.Fail("AddFirst threw an unexpected exception: " + ex.Message);
            }
        }

        // Algorithm:    Doubly Linked List – AddLast
        // Test Case:    Add Student S5001 to the Tail of a 1-node list
        // Expected:     Tail.Value.StudentID == "S5001",
        //               Tail.Previous.Value.StudentID == "S1001", Count == 2
        [Test]
        public void AddLast_ToOneNodeList_TailCorrectPreviousCorrectAndCountIsTwo()
        {
            try
            {
                // Arrange
                list.AddFirst(s1001);

                // Act
                list.AddLast(s5001);

                // Assert
                Assert.That(list.Tail.Value.StudentID, Is.EqualTo("S5001"),
                    "Tail should be S5001 after AddLast");
                Assert.That(list.Tail.Previous.Value.StudentID, Is.EqualTo("S1001"),
                    "Tail.Previous should point back to S1001");
                Assert.That(list.Count, Is.EqualTo(2),
                    "Count should be 2 after adding two nodes");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error in AddLast test: " + ex.Message);
                Assert.Fail("AddLast threw an unexpected exception: " + ex.Message);
            }
        }

        // Algorithm:    Doubly Linked List – Contains (found)
        // Expected:     Returns true
        [Test]
        public void Contains_StudentThatExists_ReturnsTrue()
        {
            try
            {
                // Arrange
                list.Add(s1001);
                list.Add(s2001);
                list.Add(s3001);

                // Act
                bool result = list.Contains(s3001);

                // Assert
                Assert.That(result, Is.True,
                    "Contains should return true for a Student that is in the list");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error in Contains (found) test: " + ex.Message);
                Assert.Fail("Contains threw an unexpected exception: " + ex.Message);
            }
        }


        // Algorithm:    Doubly Linked List – RemoveFirst
        // Expected:     New Head.Previous == null, Count decrements by 1
        [Test]
        public void RemoveFirst_FromThreeNodeList_NewHeadPreviousIsNullAndCountDecrements()
        {
            try
            {
                // Arrange
                list.Add(s1001);
                list.Add(s2001);
                list.Add(s3001);

                // Act
                list.RemoveFirst();

                // Assert
                Assert.That(list.Head.Value.StudentID, Is.EqualTo("S2001"),
                    "After RemoveFirst, S2001 should be the new Head");
                Assert.That(list.Head.Previous, Is.Null,
                    "New Head.Previous must be null — key doubly linked list check");
                Assert.That(list.Count, Is.EqualTo(2),
                    "Count should decrement from 3 to 2 after RemoveFirst");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error in RemoveFirst test: " + ex.Message);
                Assert.Fail("RemoveFirst threw an unexpected exception: " + ex.Message);
            }
        }

        // Algorithm:    Doubly Linked List – RemoveLast
        // Expected:     New Tail.Next == null, Count decrements by 1
        [Test]
        public void RemoveLast_FromThreeNodeList_NewTailNextIsNullAndCountDecrements()
        {
            try
            {
                // Arrange
                list.Add(s1001);
                list.Add(s2001);
                list.Add(s3001);

                // Act
                list.RemoveLast();

                // Assert
                Assert.That(list.Tail.Value.StudentID, Is.EqualTo("S2001"),
                    "After RemoveLast, S2001 should be the new Tail");
                Assert.That(list.Tail.Next, Is.Null,
                    "New Tail.Next must be null — key doubly linked list check");
                Assert.That(list.Count, Is.EqualTo(2),
                    "Count should decrement from 3 to 2 after RemoveLast");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error in RemoveLast test: " + ex.Message);
                Assert.Fail("RemoveLast threw an unexpected exception: " + ex.Message);
            }
        }
    }


    // =========================================================================
    // BINARY SEARCH TREE TESTS
    // =========================================================================
    [TestFixture]
    public class BinarySearchTreeTests
    {
        private BinarySearchTree<Student> bst;

        // Seven students inserted to produce a perfectly balanced tree:
        //
        //                [S4001]
        //               /       \
        //          [S2001]     [S6001]
        //          /     \     /     \
        //      [S1001][S3001][S5001][S7001]


        [SetUp]
        public void SetUp()
        {
            bst = new BinarySearchTree<Student>();
            bst.Add(new Student("S4001"));  
            bst.Add(new Student("S2001"));  
            bst.Add(new Student("S6001")); 
            bst.Add(new Student("S1001"));  
            bst.Add(new Student("S3001"));  
            bst.Add(new Student("S5001"));  
            bst.Add(new Student("S7001"));  
        }

        // Algorithm:    BST – InOrder
        // Expected:     S1001, S2001, S3001, S4001, S5001, S6001, S7001
        [Test]
        public void InOrder_SevenNodes_ReturnsAscendingOrder()
        {
            try
            {
                // Act
                List<string> result = bst.InOrder()
                                         .Select(s => s.StudentID)
                                         .ToList();

                // Assert
                List<string> expected = new List<string>
                {
                    "S1001", "S2001", "S3001", "S4001", "S5001", "S6001", "S7001"
                };

                Assert.That(result, Is.EqualTo(expected),
                    "InOrder traversal must return all StudentIDs in ascending order");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error in InOrder test: " + ex.Message);
                Assert.Fail("InOrder threw an unexpected exception: " + ex.Message);
            }
        }

        // Algorithm:    BST – PreOrder
        // Expected:     S4001, S2001, S1001, S3001, S6001, S5001, S7001
        [Test]
        public void PreOrder_SevenNodes_ReturnsRootFirstThenSubtrees()
        {
            try
            {
                // Act
                List<string> result = bst.PreOrder()
                                         .Select(s => s.StudentID)
                                         .ToList();

                // Assert
                List<string> expected = new List<string>
                {
                    "S4001", "S2001", "S1001", "S3001", "S6001", "S5001", "S7001"
                };

                Assert.That(result, Is.EqualTo(expected),
                    "PreOrder traversal must visit current node before its children");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error in PreOrder test: " + ex.Message);
                Assert.Fail("PreOrder threw an unexpected exception: " + ex.Message);
            }
        }

        // Algorithm:    BST – PostOrder
        // Expected:     S1001, S3001, S2001, S5001, S7001, S6001, S4001
        [Test]
        public void PostOrder_SevenNodes_ReturnsRootLast()
        {
            try
            {
                // Act
                List<string> result = bst.PostOrder()
                                         .Select(s => s.StudentID)
                                         .ToList();

                // Assert
                List<string> expected = new List<string>
                {
                    "S1001", "S3001", "S2001", "S5001", "S7001", "S6001", "S4001"
                };

                Assert.That(result, Is.EqualTo(expected),
                    "PostOrder traversal must visit all children before their parent");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error in PostOrder test: " + ex.Message);
                Assert.Fail("PostOrder threw an unexpected exception: " + ex.Message);
            }
        }

    }
}