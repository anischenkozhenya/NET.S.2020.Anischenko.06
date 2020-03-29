using System;
using BubbleSorting;
using NUnit.Framework;

namespace BubbleSortingTests
{
    [TestFixture]
    public class BubbleSorterTests
    {
        [Test]
        public void BubbleSorterArgumentNullException()
        {
            int[][] unsortedArray1 = new int[][]
            {
                new int[]{1,2,3},null
                ,
                new int[]{1,2,3,6}
            };
            Assert.Throws<NullReferenceException>(() => unsortedArray1.OrderByAscensingSumElementsInString());
            Assert.Throws<NullReferenceException>(() => unsortedArray1.OrderByDecensingSumElementsInString());
            Assert.Throws<NullReferenceException>(() => unsortedArray1.OrderByAscensingMaxElementInString());
            Assert.Throws<NullReferenceException>(() => unsortedArray1.OrderByDecensingMaxElementInString());
            Assert.Throws<NullReferenceException>(() => unsortedArray1.OrderByAscensingMinElementInString());
            Assert.Throws<NullReferenceException>(() => unsortedArray1.OrderByDecensingMinElementInString());
        }
        [Test]
        public void BubbleSorterSumOverflowException()
        {
            int[][] unsortedArray0 = new int[][]
            {
                new int[]{int.MaxValue,2,3},
                new int[]{1,2,3,6}
            };
            int[][] unsortedArray1 = new int[][]
            {
                new int[]{-1,2,3,6},
                new int[]{int.MinValue,-2,3}
            };
            Assert.Throws<OverflowException>(() => unsortedArray0.OrderByAscensingSumElementsInString());
            Assert.Throws<OverflowException>(() => unsortedArray0.OrderByDecensingSumElementsInString());
            Assert.Throws<OverflowException>(() => unsortedArray1.OrderByAscensingSumElementsInString());
            Assert.Throws<OverflowException>(() => unsortedArray1.OrderByDecensingSumElementsInString());
        }
        [Test]
        public void BubbleSorterOrderByAscensingSumElementsInString()
        {
            int[][] unsortedArray0 = new int[][]
            {
                new int[]{4,5},
                new int[]{1,2,3,6},
                new int[]{1,2,3}
            };
            int[][] expectedArray0 = new int[][]
            {
                new int[]{1,2,3},
                new int[]{4,5},
                new int[]{1,2,3,6}
            };
            int[][] unsortedArray1 = new int[][]
            {
                new int[]{100,60,-700},//-540
                new int[]{-55,800,5},//750
                new int[]{450,-30,-600}//-180
            };
            int[][] expectedArray1 = new int[][]
            {
                new int[]{100,60,-700},//-540
                new int[]{450,-30,-600},//-180
                new int[]{-55,800,5}//750
                
            };
            var sortedArray0 = unsortedArray0.OrderByAscensingSumElementsInString();
            var sortedArray1 = unsortedArray1.OrderByAscensingSumElementsInString();
            Assert.AreEqual(expectedArray0, sortedArray0);
            Assert.AreEqual(expectedArray1, sortedArray1);
        }
        [Test]
        public void BubbleSorterOrderByDecensingSumElementsInString()
        {
            int[][] unsortedArray0 = new int[][]
            {
                new int[]{4,5},
                new int[]{1,2,3,6},
                new int[]{1,2,3}
            };
            int[][] expectedArray0 = new int[][]
            {
                new int[]{1,2,3,6},
                new int[]{4,5},
                new int[]{1,2,3}
            };
            int[][] unsortedArray1 = new int[][]
            {
                new int[]{100,60,-700},//-540
                new int[]{-55,800,5},//750
                new int[]{450,-30,-600}//-180
            };
            int[][] expectedArray1 = new int[][]
            {
                new int[]{-55,800,5},
                new int[]{450,-30,-600},
                new int[]{100,60,-700}
            };
            var sortedArray0 = unsortedArray0.OrderByDecensingSumElementsInString();
            var sortedArray1 = unsortedArray1.OrderByDecensingSumElementsInString();
            Assert.AreEqual(expectedArray0, sortedArray0);
            Assert.AreEqual(expectedArray1, sortedArray1);
        }
        [Test]
        public void BubbleSorterOrderByAscensingMaxElementsInString()
        {
            int[][] unsortedArray0 = new int[][]
            {
                new int[]{4,5},
                new int[]{1,2,3,6},
                new int[]{1,2,3}
            };
            int[][] expectedArray0 = new int[][]
            {
                new int[]{1,2,3},
                new int[]{4,5},
                new int[]{1,2,3,6}
            };
            int[][] unsortedArray1 = new int[][]
            {
                new int[]{100,60,-700},
                new int[]{-55,800,5},
                new int[]{450,-30,-600}
            };
            int[][] expectedArray1 = new int[][]
            {
                new int[]{100,60,-700},
                new int[]{450,-30,-600},
                new int[]{-55,800,5}
            };
            var sortedArray0 = unsortedArray0.OrderByAscensingMaxElementInString();
            var sortedArray1 = unsortedArray1.OrderByAscensingMaxElementInString();
            Assert.AreEqual(expectedArray0, sortedArray0);
            Assert.AreEqual(expectedArray1, sortedArray1);
        }
        [Test]
        public void BubbleSorterOrderByDecensingMaxElementsInString()
        {
            int[][] unsortedArray0 = new int[][]
            {
                new int[]{4,5},
                new int[]{1,2,3,6},
                new int[]{1,2,3}
            };
            int[][] expectedArray0 = new int[][]
            {
                new int[]{1,2,3,6},
                new int[]{4,5},
                new int[]{1,2,3}
            };
            int[][] unsortedArray1 = new int[][]
            {
                new int[]{100,60,-700},
                new int[]{-55,800,5},
                new int[]{450,-30,-600}
            };
            int[][] expectedArray1 = new int[][]
            {
                new int[]{-55,800,5},
                new int[]{450,-30,-600},
                new int[]{100,60,-700}
            };
            var sortedArray0 = unsortedArray0.OrderByDecensingMaxElementInString();
            var sortedArray1 = unsortedArray1.OrderByDecensingMaxElementInString();
            Assert.AreEqual(expectedArray0, sortedArray0);
            Assert.AreEqual(expectedArray1, sortedArray1);
        }
        [Test]
        public void BubbleSorterOrderByAscensingMinElementsInString()
        {
            int[][] unsortedArray0 = new int[][]
            {
                new int[]{4,5},
                new int[]{1,2,3,6},
                new int[]{1,2,3}
            };
            int[][] expectedArray0 = new int[][]
            {
                new int[]{1,2,3,6},
                new int[]{1,2,3},
                new int[]{4,5}
            };
            int[][] unsortedArray1 = new int[][]
            {
                new int[]{100,60,-700},
                new int[]{-55,800,5},
                new int[]{450,-30,-600}
            };
            int[][] expectedArray1 = new int[][]
            {
                new int[]{100,60,-700},
                new int[]{450,-30,-600},
                new int[]{-55,800,5}

            };
            var sortedArray0 = unsortedArray0.OrderByAscensingMinElementInString();
            var sortedArray1 = unsortedArray1.OrderByAscensingMinElementInString();
            Assert.AreEqual(expectedArray0, sortedArray0);
            Assert.AreEqual(expectedArray1, sortedArray1);
        }
        [Test]
        public void BubbleSorterOrderByDecensingMinElementsInString()
        {
            int[][] unsortedArray0 = new int[][]
            {
                new int[]{4,5},
                new int[]{1,2,3,6},
                new int[]{1,2,3}
            };
            int[][] expectedArray0 = new int[][]
            {
                new int[]{4,5},
                new int[]{1,2,3,6},
                new int[]{1,2,3}
            };
            int[][] unsortedArray1 = new int[][]
            {
                new int[]{100,60,-700},
                new int[]{-55,800,5},
                new int[]{450,-30,-600}
            };
            int[][] expectedArray1 = new int[][]
            {
                new int[]{-55,800,5},
                new int[]{450,-30,-600},
                new int[]{100,60,-700}

            };
            var sortedArray0 = unsortedArray0.OrderByDecensingMinElementInString();
            var sortedArray1 = unsortedArray1.OrderByDecensingMinElementInString();
            Assert.AreEqual(expectedArray0, sortedArray0);
            Assert.AreEqual(expectedArray1, sortedArray1);
        }
    }
}
