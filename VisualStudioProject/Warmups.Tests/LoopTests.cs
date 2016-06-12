using NUnit.Framework;
using Warmups.BLL;

namespace Warmups.Tests
{
    [TestFixture]
    public class LoopTests
    {
        [TestCase("Hi", 2, "HiHi")]
        [TestCase("Hi", 3, "HiHiHi")]
        [TestCase("Hi", 1, "Hi")]
        public void StringTimesTest(string str, int n, string expected)
        {
            // arrange
            Loops obj = new Loops();

            // act
            string actual = obj.StringTimes(str, n);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Chocolate", 2, "ChoCho")]
        [TestCase("Chocolate", 3, "ChoChoCho")]
        [TestCase("Abc", 3, "AbcAbcAbc")]
        public void FrontTimesTest(string str, int n, string expected)
        {
            Loops obj = new Loops();

            string actual = obj.FrontTimes(str, n);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("abcxx", 1)]
        [TestCase("xxx", 2)]
        [TestCase("xxxx", 3)]
        public void CountXXTest(string a, int expected) 
        {
            Loops obj = new Loops();

            int actual = obj.CountXX(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("axxbb", true)]
        [TestCase("axaxxax", false)]
        [TestCase("xxxxx", true)]
        public void DoubleXTest(string a, bool expected)
        {
            Loops obj = new Loops();

            bool actual = obj.DoubleX(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", "Hlo")]
        [TestCase("Hi", "H")]
        [TestCase("Heeololeo", "Hello")]
        public void EveryOtherTest(string a, string expected)
        {
            Loops obj = new Loops();

            string actual = obj.EveryOther(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Code", "CCoCodCode")]
        [TestCase("abc", "aababc")]
        [TestCase("ab", "aab")]
        public void StringSplosionTest(string a, string expected)
        {
            Loops obj = new Loops();

            string actual = obj.StringSplosion(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("hixxhi", 1)]
        [TestCase("xaxxaxaxx", 1)]
        [TestCase("axxxaaxx", 2)]
        public void CountLast2Test(string a, int expected)
        {
            Loops obj = new Loops();

            int actual = obj.CountLast2(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 9}, 1)]
        [TestCase(new int[] { 1, 9, 9 }, 2)]
        [TestCase(new int[] { 1, 9, 9, 3, 9 }, 3)]
        public void Count9Test(int[] a, int expected)
        {
            Loops obj = new Loops();

            int actual = obj.Count9(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 9, 3, 4 }, true)]
        [TestCase(new int[] { 1, 2, 3, 4, 9 }, false)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, false)]
        public void ArrayFront9Test(int[] a, bool expected)
        {
            Loops obj = new Loops();

            bool actual = obj.ArrayFront9(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 1, 2, 3, 1 }, true)]
        [TestCase(new int[] { 1, 1, 2, 4, 1 }, false)]
        [TestCase(new int[] { 1, 1, 2, 1, 2, 3 }, true)]
        public void Array123Test(int[] a, bool expected)
        {
            Loops obj = new Loops();

            bool actual = obj.Array123(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("xxcaazz", "xxbaaz", 3)]
        [TestCase("abc", "abc", 2)]
        [TestCase("abc", "axc", 0)]
        public void SubStringMatchTest(string a, string b, int expected)
        {
            Loops obj = new Loops();

            int actual = obj.SubStringMatch(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("xxHxix", "xHix")]
        [TestCase("abxxxcd", "abcd")]
        [TestCase("xabxxxcdx", "xabcdx")]
        public void StringXTest(string a, string expected)
        {
            Loops obj = new Loops();

            string actual = obj.StringX(a);

            Assert.AreEqual(expected, actual);
        }






    }
}
