using NUnit.Framework;
using Warmups.BLL;

namespace Warmups.Tests
{
    [TestFixture]
    public class ArrayTests
    {
        [TestCase(new int[] { 1, 2, 6 }, true)]
        [TestCase(new int[] { 6, 1, 2, 3 }, true)]
        [TestCase(new int[] { 13, 6, 1, 2, 3 }, false)]
        public void FirstLast6Test(int[] numbers, bool expected)
        {
            // arrange
            Arrays obj = new Arrays();

            // act
            bool actual = obj.FirstLast6(numbers);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 6 }, false)]
        [TestCase(new int[] { 1, 2, 3, 1 }, true)]
        [TestCase(new int[] { 1, 2, 1 }, true)]
        public void SameFirstLastTest(int[] a, bool expected)
        {
            Arrays obj = new Arrays();

            bool actual = obj.SameFirstLast(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 3, 1, 4 })]
        public void MakePiTest(int a, int[] expected)
        {
            Arrays obj = new Arrays();

            int[] actual = obj.MakePi(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 7, 3 }, true)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 7, 3, 2 }, false)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 3 }, true)]
        public void commonEnd(int[] a, int[] b, bool expected)
        {
            Arrays obj = new Arrays();

            bool actual = obj.commonEnd(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 6)]
        [TestCase(new int[] { 5, 11, 2 }, 18)]
        [TestCase(new int[] { 7, 0, 0 }, 7)]
        public void Sum(int[] a, int expected)
        {
            Arrays obj = new Arrays();

            int actual = obj.Sum(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3, 1 })]
        [TestCase(new int[] { 5, 11, 9 }, new int[] { 11, 9, 5 })]
        [TestCase(new int[] { 7, 0, 0 }, new int[] { 0, 0, 7 })]
        public void RotateLeftTest(int[] a, int[] expected)
        {
            Arrays obj = new Arrays();

            int[] actual = obj.RotateLeft(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        public void Reverse(int[] a, int[] expected)
        {
            Arrays obj = new Arrays();

            int[] actual = obj.Reverse(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 3, 3 })]
        [TestCase(new int[] { 11, 5, 9 }, new int[] { 11, 11, 11 })]
        [TestCase(new int[] { 2, 11, 3 }, new int[] { 3, 3, 3 })]
        public void HigherWinsTest(int[] a, int[] expected)
        {
            Arrays obj = new Arrays();

            int[] actual = obj.HigherWins(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 2, 5 })]
        [TestCase(new int[] { 7, 7, 7 }, new int[] { 3, 8, 0 }, new int[] { 7, 8 })]
        [TestCase(new int[] { 5, 2, 9 }, new int[] { 1, 4, 5 }, new int[] { 2, 4 })]
        public void GetMiddleTest(int[] a, int[] b, int[] expected)
        {
            Arrays obj = new Arrays();

            int[] actual = obj.GetMiddle(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 5 }, true)]
        [TestCase(new int[] { 4, 3 }, true)]
        [TestCase(new int[] { 7, 5 }, false)]
        public void HasEvenTest(int[] a, bool expected)
        {
            Arrays obj = new Arrays();

            bool actual = obj.HasEven(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 4, 5, 6 }, new int[] { 0, 0, 0, 0, 0, 6})]
        [TestCase(new int[] { 1, 2 }, new int[] { 0, 0, 0, 2})]
        [TestCase(new int[] { 3 }, new int[] { 0, 3})]
        public void KeepLastTest(int[] a, int[] expected)
        {
            Arrays obj = new Arrays();

            int[] actual = obj.KeepLast(a);

            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(new int[] { 2, 2, 3}, true)]
        [TestCase(new int[] { 3, 4, 5, 3 }, true)]
        [TestCase(new int[] { 2, 3, 2, 2 }, false)]
        public void Double23Test(int[] a, bool expected)
        {
            Arrays obj = new Arrays();

            bool actual = obj.Double23(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 0})]
        [TestCase(new int[] { 2, 3, 5 }, new int[] { 2, 0, 5 })]
        [TestCase(new int[] { 1, 2, 1 }, new int[] { 1, 2, 1 })]
        public void Fix23Test(int[] a, int[] expected)
        {
            Arrays obj = new Arrays();

            int[] actual = obj.Fix23(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 3, 4, 5 }, true)]
        [TestCase(new int[] { 2, 1, 3, 4, 5 }, true)]
        [TestCase(new int[] { 1, 1, 1 }, false)]
        public void Unlucky1Test(int[] a, bool expected)
        {
            Arrays obj = new Arrays();

            bool actual = obj.Unlucky1(a);

            Assert.AreEqual(expected, actual);
        }

       // [TestCase(new int[] { 4, 5 }, new int[] { 1, 2, 3 }, new int[] { 4, 5})]
        [TestCase(new int[] { 4 }, new int[] { 1, 2, 3 }, new int[] { 4, 1 })]
       // [TestCase(new int[] {}, new int[] { 1, 2 }, new int[] { 1, 2 })]
        public void Make2Test(int[] a, int[] b, int[] expected)
        { 
            Arrays obj = new Arrays();

            int[] actual = obj.make2(a, b);

            Assert.AreEqual(expected, actual);
        }



    }
}
