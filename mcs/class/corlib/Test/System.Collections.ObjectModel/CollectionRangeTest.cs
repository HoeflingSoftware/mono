using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using NUnit.Framework;

namespace MonoTests.System.Collections.ObjectModel
{
	[TestFixture]
    public class CollectionRangeTest
    {
        [Test]
        public void Collection_AddRange_Test()
        {
            int[] expected = new [] { 1, 2, 3, 4 };
            Collection<int> collection = new Collection<int>();
            
            collection.AddRange(expected);

            Assert.NotNull(collection);
            Assert.AreEqual(expected.Length, collection.Count);
            Assert.AreEqual(expected[0], collection[0]);
            Assert.AreEqual(expected[1], collection[1]);
            Assert.AreEqual(expected[2], collection[2]);
            Assert.AreEqual(expected[3], collection[3]);          
        }

        [Test]
        public void Collection_AddRange_Empty_Test()
        {
            int[] expected = new int[0];
            Collection<int> collection = new Collection<int>();

            collection.AddRange(expected);

            Assert.NotNull(collection);
            Assert.AreEqual(expected.Length, collection.Count);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Collection_AddRange_Null_Test()
        {
            Collection<int> collection = new Collection<int>();
            collection.AddRange(null);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void Collection_AddRange_ReadOnly_Test()
        {
            int[] baseCollection = new int[] { 1, 2, 3 };
            Collection<int> collection = new Collection<int>(baseCollection);

            collection.AddRange(new int[] { 4, 5, 6 });
        }

        [Test]
        public void Collection_InsertRange_Beginning_Test()
        {
            int[] expected = new int[] { 1, 2, 3, 4, 5 };
            int[] originalCollection = new int[] { 10, 11, 12, 13 };
            List<int> baseCollection = new List<int>(originalCollection);

            int expectedLength = expected.Length + originalCollection.Length;
            Collection<int> collection = new Collection<int>(baseCollection);

            collection.InsertRange(0, expected);

            Assert.NotNull(collection);
            Assert.AreEqual(expectedLength, collection.Count);
            Assert.AreEqual(expected[0], collection[0]);
            Assert.AreEqual(expected[1], collection[1]);
            Assert.AreEqual(expected[2], collection[2]);
            Assert.AreEqual(expected[3], collection[3]);
            Assert.AreEqual(expected[4], collection[4]);
            Assert.AreEqual(originalCollection[0], collection[5]);
            Assert.AreEqual(originalCollection[1], collection[6]);
            Assert.AreEqual(originalCollection[2], collection[7]);
            Assert.AreEqual(originalCollection[3], collection[8]);
        }

        [Test]
        public void Collection_InsertRange_End_Test()
        {
            int[] expected = new int[] { 1, 2, 3, 4, 5 };
            int[] originalCollection = new int[] { 10, 11, 12, 13 };
            List<int> baseCollection = new List<int>(originalCollection);

            int expectedLength = expected.Length + originalCollection.Length;
            Collection<int> collection = new Collection<int>(baseCollection);

            collection.InsertRange(expected.Length - 1, expected);

            Assert.NotNull(collection);
            Assert.AreEqual(expectedLength, collection.Count);
            Assert.AreEqual(originalCollection[0], collection[0]);
            Assert.AreEqual(originalCollection[1], collection[1]);
            Assert.AreEqual(originalCollection[2], collection[2]);
            Assert.AreEqual(originalCollection[3], collection[3]);
            Assert.AreEqual(expected[0], collection[4]);
            Assert.AreEqual(expected[1], collection[5]);
            Assert.AreEqual(expected[2], collection[6]);
            Assert.AreEqual(expected[3], collection[7]);
            Assert.AreEqual(expected[4], collection[8]);
        }

        [Test]
        public void Collection_InsertRange_Middle_Test()
        {
            int[] expected = new int[] { 1, 2, 3, 4, 5 };
            int[] originalCollection = new int[] { 10, 11, 12, 13 };
            List<int> baseCollection = new List<int>(originalCollection);

            int expectedLength = expected.Length + originalCollection.Length;
            Collection<int> collection = new Collection<int>(baseCollection);

            collection.InsertRange(2, expected);

            Assert.NotNull(collection);
            Assert.AreEqual(expectedLength, collection.Count);
            Assert.AreEqual(originalCollection[0], collection[0]);
            Assert.AreEqual(originalCollection[1], collection[1]);       
                   
            Assert.AreEqual(expected[0], collection[2]);
            Assert.AreEqual(expected[1], collection[3]);
            Assert.AreEqual(expected[2], collection[4]);
            Assert.AreEqual(expected[3], collection[5]);
            Assert.AreEqual(expected[4], collection[6]);

            Assert.AreEqual(originalCollection[2], collection[7]);  
            Assert.AreEqual(originalCollection[3], collection[8]);
        }

        [Test]
        public void Collection_InsertRange_Empty_Test()
        {
            List<int> baseCollection = new List<int>(new [] { 10, 11, 12, 13 });
            Collection<int> collection = new Collection<int>(baseCollection);

            collection.InsertRange(0, new int[0]);

            Assert.NotNull(collection);
            Assert.AreEqual(baseCollection.Count, collection.Count);
            Assert.AreEqual(baseCollection[0], collection[0]);
            Assert.AreEqual(baseCollection[1], collection[1]);
            Assert.AreEqual(baseCollection[2], collection[2]);
            Assert.AreEqual(baseCollection[3], collection[3]);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Collection_InsertRange_Null_Test()
        {
            Collection<int> collection = new Collection<int>();
            collection.InsertRange(0, null);
        }

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void Collection_InsertRange_ReadOnly_Test()
        {
            int[] expected = new int[] { 1, 2, 3, 4 };
            int[] baseCollection = new int[] { 5, 6, 7, 8 };
            Collection<int> collection = new Collection<int>(baseCollection);
        
            collection.InsertRange(0, expected);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Collection_InsertRange_IndexLessThan0_Test()
        {
            int[] expected = new int[] { 1, 2, 3, 4 };
            Collection<int> collection = new Collection<int>();
            collection.InsertRange(-1, expected);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Collection_InsertRange_IndexGreaterThanCount_Test()
        {
            int[] expected = new int[] { 1, 2, 3, 4 };
            Collection<int> collection = new Collection<int>();
            collection.InsertRange(10, expected);
        }
    }
}