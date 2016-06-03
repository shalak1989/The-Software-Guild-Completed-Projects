using NUnit.Framework;
using Warmups.BLL;

namespace Warmups.Tests
{
    [TestFixture]
    public class ArrayTests
    {
        [TestCase(new int[] { 1, 2, 6}, true)]
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
    }
}
