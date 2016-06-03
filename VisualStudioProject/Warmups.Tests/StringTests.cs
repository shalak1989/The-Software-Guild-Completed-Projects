using NUnit.Framework;
using Warmups.BLL;

namespace Warmups.Tests
{
    [TestFixture]
    public class StringTests
    { 
        [TestCase("Bob", "Hello Bob!")]
        [TestCase("Alice", "Hello Alice!")]
        [TestCase("X", "Hello X!")]
        public void SayHiTest(string name, string expected)
        {
            // arrange
            Strings obj = new Strings();

            // act
            string actual = obj.SayHi(name);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hi", "Bye", "HiByeByeHi")]
        [TestCase("Yo" , "Alice" , "YoAliceAliceYo")]
        [TestCase("What" , "Up", "WhatUpUpWhat")]
        public void Abba(string a, string b, string expected)
        {
            Strings obj = new Strings();

            string actual = obj.Abba(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("i", "Yay", "<i>Yay</i>")]
        [TestCase("i", "Hello", "<i>Hello</i>")]
        [TestCase("cite", "Yay", "<cite>Yay</cite>")]
        public void MakeTags(string a, string b, string expected)
        {
            Strings obj = new Strings(); //making a variable called objects, with class of Strings
                                          //strings is a custom class in this project

            string actual = obj.MakeTags(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("<<>>" , "Yay", "<<Yay>>")]
        [TestCase("<<>>", "WooHoo" , "<<WooHoo>>")]
        [TestCase("[[]]", "word" , "[[word]]")]
        public void InsertWord(string a, string b, string expected)
        {
            Strings obj = new Strings();

            string actual = obj.InsertWord(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", "lololo")]
        [TestCase("ab", "ababab")]
        [TestCase("Hi", "HiHiHi")]
        public void MultipleEndings(string a, string expected)
        {
            Strings obj = new Strings();

            string actual = obj.MultipleEndings(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("WooHoo", "Woo")]
        [TestCase("HelloThere", "Hello")]
        [TestCase("abcdef", "abc")]
        public void FirstHalf(string a, string expected)
        {
            Strings obj = new Strings();

            string actual = obj.FirstHalf(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", "ell")]
        [TestCase("java", "av")]
        [TestCase("coding", "odin")]
        public void TrimOne(string a, string expected)
        {
            Strings obj = new Strings();

            string actual = obj.TrimOne(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", "hi", "hiHellohi")]
        [TestCase("hi", "Hello", "hiHellohi")]
        [TestCase("aaa", "b", "baaab")]
        public void LongInMiddle(string a, string b, string expected)
        {
            Strings obj = new Strings();

            string actual = obj.LongInMiddle( a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", "lloHe")]
        [TestCase("java", "vaja")]
        [TestCase("Hi", "Hi")]
        public void RotateLeft2(string a, string expected)
        {
            Strings obj = new Strings();

            string actual = obj.Rotateleft2(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", "loHel")]
        [TestCase("java", "vaja")]
        [TestCase("Hi", "Hi")]
        public void RotateRight2(string a, string expected)
        {
            Strings obj = new Strings();

            string actual = obj.RotateRight2(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", true, "H")]
        [TestCase("Hello", false, "o")]
        [TestCase("oh", true, "o")]
        public void TakeOne(string a, bool b, string expected)
        {
            Strings obj = new Strings();

            string actual = obj.TakeOne(a, b);

            Assert.AreEqual(expected, actual);

        }

        //MiddleTwo("string") -> "ri"
        //MiddleTwo("code") -> "od"
        //MiddleTwo("Practice") -> "ct"
        [TestCase("string", "ri")]
        [TestCase("code", "od")]
        [TestCase("Practice", "ct")]
        public void MiddleTwo(string a, string expected)
        {
            Strings obj = new Strings();

            string actual = obj.MiddleTwo(a);

            Assert.AreEqual(expected, actual);
        }

        /*

        EndsWithLy("oddly") -> true
        EndsWithLy("y") -> false
        EndsWithLy("oddy") -> false
        */

        [TestCase("oddly", true)]
        [TestCase("y", false)]
        [TestCase("oddy", false)]
        public void EndsWithLy(string a, bool expected)
        {
            Strings obj = new Strings();

            bool actual = obj.EndsWithLy(a);

            Assert.AreEqual(expected, actual);

        }

        [TestCase("Hello", 2, "Helo")]
        [TestCase("Chocolate", 3, "Choate")]
        [TestCase("Chocolate", 1, "Ce")]
        public void FrontAndBack(string a, int n, string expected)
        {
            Strings obj = new Strings();

            string actual = obj.FrontAndBack(a, n);

            Assert.AreEqual(expected, actual);
        }

        /* Given a string and an index, return a string length 2 starting at the given index. If the index is too big or too small to define a string length 2, use the first 2 chars. The string length will be at least 2. 

TakeTwoFromPosition("java", 0) -> "ja"
TakeTwoFromPosition("java", 2) -> "va"
TakeTwoFromPosition("java", 3) -> "ja"

*/
        [TestCase("java", 0, "ja")]
        [TestCase("java", 2, "va")]
        [TestCase("java", 3, "ja")]
        public void TakeTwoFromPosition(string a, int b, string expected)
        {
            Strings obj = new Strings();

            string actual = obj.TakeTwoFromPosition(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("badxx", true)]
        [TestCase("xbadxx", true)]
        [TestCase("xxbadxx", false)]
        public void HasBad(string a, bool expected)
        {
            Strings obj = new Strings();

            bool actual = obj.HasBad(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("hello", "he")]
        [TestCase("hi", "hi")]
        [TestCase("h", "h@")]
        public void AtFirst(string a, string expected)
        {
            Strings obj = new Strings();

            string actual = obj.AtFirst(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("last", "chars", "ls")]
        [TestCase("yo", "mama", "ya")]
        [TestCase("hi", "", "h@")]
        public void LastChars(string a, string b, string expected)
        {
            Strings obj = new Strings();

            string actual = obj.LastChars(a, b);

            Assert.AreEqual(expected, actual);

        }

        [TestCase("abc", "cat", "abcat")]
        [TestCase("dog", "cat", "dogcat")]
        [TestCase("abc", "", "abc")]
        public void ConCat(string a, string b, string expected)
        {
            Strings obj = new Strings();

            string actual = obj.ConCat(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("coding", "codign")]
        [TestCase("cat", "cta")]
        [TestCase("ab", "ba")]
        public void SwapLast(string a, string expected)
        {
            Strings obj = new Strings();

            string actual = obj.SwapLast(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("edited", true)]
        [TestCase("edit", false)]
        [TestCase("ed", true)]
        public void FrontAgain(string a, bool expected)
        {
            Strings obj = new Strings();

            bool actual = obj.FrontAgain(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", "Hi", "loHi")]
        [TestCase("Hello", "java", "ellojava")]
        [TestCase("java", "hello", "javaello")]
        public void MinCat(string a, string b, string expected)
        {
            Strings obj = new Strings();

            string actual = obj.MinCat(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("Hello", "llo")]
        [TestCase("away", "aay")]
        [TestCase("abed", "abed")]
        public void TweakFront(string a, string expected)
        {
            Strings obj = new Strings();

            string actual = obj.TweakFront(a);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("xHix", "Hi")]
        [TestCase("xHi", "Hi")]
        [TestCase("Hxix", "Hxi")]
        public void StripX(string a, string expected)
        {

        }


    }
}
