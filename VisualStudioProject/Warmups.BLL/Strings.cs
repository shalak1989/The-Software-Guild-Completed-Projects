using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Strings 
    {
        // Given a string name, e.g. "Bob", return a greeting of the form "Hello Bob!". 
        public string SayHi(string name)
        {
            return string.Format("Hello {0}!", name);
        }

        /* Given two strings, a and b, return the result of putting them together in the order abba, e.g. "Hi" and "Bye" returns "HiByeByeHi". 

         Abba("Hi", "Bye") -> "HiByeByeHi"
         Abba("Yo", "Alice") -> "YoAliceAliceYo"
         Abba("What", "Up") -> "WhatUpUpWhat"*/

        public string Abba(string a, string b)
        {
            return a + b + b + a;
        }

        /*The web is built with HTML strings like "<i>Yay</i>" which draws Yay as italic text.
        In this example, the "i" tag makes <i> and</i> which surround the word "Yay". 
        Given tag and word strings, create the HTML string with tags around the word, e.g. 
        "<i>Yay</i>". 

            //MakeTags("i", "Yay") -> "<i>Yay</i>"
            //MakeTags("i", "Hello") -> "<i>Hello</i>"
            //MakeTags("cite", "Yay") -> "<cite>Yay</cite>" */

        public string MakeTags(string tag, string content)
        {
            return "<" + tag + ">" + content + "</" + tag + ">";
        }

        /* Given an "out" string length 4, such as "<<>>", and a word, return a new string 
        where the word is in the middle of the out string, e.g. "<<word>>".

        Hint: Substrings are your friend here 

        InsertWord("<<>>", "Yay") -> "<<Yay>>"
        InsertWord("<<>>", "WooHoo") -> "<<WooHoo>>"
        InsertWord("[[]]", "word") -> "[[word]]" */

        public string InsertWord(string container, string word)
        {
            return container.Substring(0, 2) + word.Substring(0) + container.Substring(2, 2);/* subString in C#
            , first argument is start index and second is number of indexes you want inclusive.*/

        }

        /*Given a string, return a new string made of 3 copies of the last 2 chars 
        of the original string. The string length will be at least 2. 

            MultipleEndings("Hello") -> "lololo"
            MultipleEndings("ab") -> "ababab"
            MultipleEndings("Hi") -> "HiHiHi" 
            
            Get last two chars of a string, then return a new string mad eof 3 copies
            
            */

        public string MultipleEndings(string str)
        {
            if (str.Length >= 2)
            {
                return str.Substring(str.Length - 2, 2) + str.Substring(str.Length - 2, 2) +
                str.Substring(str.Length - 2, 2);
            }

            return "The string has to be at least 2 long!";
        }

        /* Given a string of even length, return the first half. So the string 
        "WooHoo" yields "Woo". 

        FirstHalf("WooHoo") -> "Woo"
        FirstHalf("HelloThere") -> "Hello"
        FirstHalf("abcdef") -> "abc"

        */

        //determine length of string, divide by two, generate as many arrays as the
        //string length /2, EX. str.Length / 2 = return str.Substring

        public string FirstHalf(string str)
        {
            int stringLength = 0;
            stringLength = (str.Length / 2);
            return str.Substring(0, stringLength);
        }

        /* Given a string, return a version without the first and last char, so "Hello" 
        yields "ell". 
        The string length will be at least 2. 

        TrimOne("Hello") -> "ell"
        TrimOne("java") -> "av"
        TrimOne("coding") -> "odin"

        */

        public string TrimOne(string str)
        {
            int stringLengthMax = 0;
            stringLengthMax = str.Length - 2; //Is str.Length inclusive?
            return str.Substring(1, stringLengthMax);
        }

        /* Given 2 strings, a and b, return a string of the form short+long+short, 
        with the shorter string on the outside and the longer string on the inside. 
        The strings will not be the same length, but they may be empty (length 0). 

        LongInMiddle("Hello", "hi") -> "hiHellohi"
        LongInMiddle("hi", "Hello") -> "hiHellohi"
        LongInMiddle("aaa", "b") -> "baaab"
        */

        public string LongInMiddle(string a, string b)
        {
            if (a.Length < b.Length)
            {
                return a + b + a;
            }

            else
            {
                return b + a + b;
            }
        }

        // Given a string, return a "rotated left 2" version where the first 2 chars are 
        //moved to the end.The string length will be at least 2. 

        //Rotateleft2("Hello") -> "lloHe"
        //Rotateleft2("java") -> "vaja"
        //Rotateleft2("Hi") -> "Hi"

        public string Rotateleft2(string str)
        {
            string firstTwoChars = str.Substring(0, 2);
            return str.Remove(0, 2) + firstTwoChars;
        }
        //Given a string, return a "rotated right 2" version where the last 2 
        //chars are moved to the start.The string length will be at least 2. 

        //RotateRight2("Hello") -> "loHel"
        //RotateRight2("java") -> "vaja"
        //RotateRight2("Hi") -> "Hi"

        public string RotateRight2(string str)
        {
            return str.Substring(str.Length - 2) + str.Remove(str.Length - 2);
        }

        ////        Given a string, return a string length 1 from its front, unless front is false, 
        //            in which case return a string length 1 from its back.The string will be non-empty.

        //            //TakeOne("Hello", true) -> "H"
        //            //TakeOne("Hello", false) -> "o"
        //            //TakeOne("oh", true) -> "o"

        public string TakeOne(string str, bool fromFront)
        {
            if (fromFront == true)
            {
                return str.Substring(0, 1);
            }
            else
            {
                return str.Substring(str.Length - 1);
            }
        }

        /* Given a string of even length, return a string made of the middle two chars, so 
        the string "string" yields "ri". The string length will be at least 2. 

        MiddleTwo("string") -> "ri"
        MiddleTwo("code") -> "od"
        MiddleTwo("Practice") -> "ct"

        */
        public string MiddleTwo(string str)
        {
            int middleTwoLength = ((str.Length / 2) - 1);
            return str.Substring(middleTwoLength, 2);
        }

        /*Given a string, return true if it ends in "ly". 

         EndsWithLy("oddly") -> true
         EndsWithLy("y") -> false
         EndsWithLy("oddy") -> false

         */

        public bool EndsWithLy(string str)
        {   
            if (str.Length < 2)
            {
                return false;
            }
            int endsWithLength = (str.Length - 2);
            string endsString = str.Substring(endsWithLength);

            if (str.Length > 2 && endsString == "ly")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /* Given a string and an int n, return a string made of the first and last n chars 
        from the string. The string length will be at least n. 

        FrontAndBack("Hello", 2) -> "Helo"
        FrontAndBack("Chocolate", 3) -> "Choate"
        FrontAndBack("Chocolate", 1) -> "Ce"

          1. I need to get the first (n) and last (n) chars of a string
          2. Then I need to return a string made up of the first character (n) and 
          the number of N characters from the last part of the string.

        */

        public string FrontAndBack(string str, int n)
        {   
            return str.Substring(0, n) + str.Substring(str.Length - n);
        }

        /* Given a string and an index, return a string length 2 starting at the given index. 
        If the index is too big or too small to define a string length 2, use 
        the first 2 chars. The string length will be at least 2. 

            TakeTwoFromPosition("java", 0) -> "ja"
            TakeTwoFromPosition("java", 2) -> "va"
            TakeTwoFromPosition("java", 3) -> "ja"

            */

        public string TakeTwoFromPosition(string str, int n)
        {
            if ((str.Length - n) < 2)
            {
                return str.Substring(0, 2);
            }
            else
            {
                return str.Substring(n, 2);
            }
 
        }

        /* Given a string, return true if "bad" appears starting at index 0 or 1 
        in the string, such as with "badxxx" or "xbadxx" but not "xxbadxx". 
        The string may be any length, including 0.

HasBad("badxx") -> true
HasBad("xbadxx") -> true
HasBad("xxbadxx") -> false

*/
        public bool HasBad(string str)
        {
            if (str.Substring(0, 3) == "bad" || str.Substring(1,3) == "bad")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /* Given a string, return a string length 2 made of its first 2 chars. 
        If the string length is less than 2, use '@' for the missing chars. 

        AtFirst("hello") -> "he"
        AtFirst("hi") -> "hi"
        AtFirst("h") -> "h@"

        */

        public string AtFirst(string str)
        {
            if (str.Length < 2)
            {
                return str.Substring(0) + "@";
            }
            else
            {
                return str.Substring(0, 2);
            }
        }

        /* Given 2 strings, a and b, return a new string made of the first char 
        of a and the last char of b, so "yo" and "java" yields "ya". If either 
        string is length 0, use '@' for its missing char. 

        LastChars("last", "chars") -> "ls"
        LastChars("yo", "mama") -> "ya"
        LastChars("hi", "") -> "h@"

        */
        public string LastChars(string str, string b)
        {
            if (str.Length == 0)
            {
                return "@" + b.Substring(b.Length, 1);
            }
            else if (b.Length == 0)
            {
                return str.Substring(0, 1) + "@";
            }
            else
            {
                int LastCharLetter = (b.Length - 1);
                return str.Substring(0, 1) + b.Substring(LastCharLetter, 1);
            }
            
        }

        /* Given two strings, append them together (known as "concatenation") 
        and return the result. However, if the concatenation creates a double-char, 
        then omit one of the chars, so "abc" and "cat" yields "abcat". 

ConCat("abc", "cat") -> "abcat"
ConCat("dog", "cat") -> "dogcat"
ConCat("abc", "") -> "abc"

*/
        public string ConCat(string a, string b)
        {

            if (a.Substring(a.Length - 1) == b.Substring(0, 1))
            {
                return a.Substring(0, 2) + b.Substring(0);
            }
            else
            {
                return a + b;
            }
                     
        }

        /* Given a string of any length, return a new string where the last 2 chars
        , if present, are swapped, so "coding" yields "codign". 

        SwapLast("coding") -> "codign"
        SwapLast("cat") -> "cta"
        SwapLast("ab") -> "ba"

        */

        public string SwapLast(string str)
        {
           if (str.Length >= 2)
            {
                string lastStringChar = str.Substring(str.Length - 1, 1);
                string secondLastStringChar = str.Substring(str.Length - 2, 1);
                return str.Substring(0, (str.Length - 2)) + lastStringChar + secondLastStringChar;
                
            }
            else
            {
                return str.Substring(0);
            }
        }

        /* Given a string, return true if the first 2 chars in the string also 
        appear at the end of the string, such as with "edited". 

FrontAgain("edited") -> true
FrontAgain("edit") -> false
FrontAgain("ed") -> true

*/
        public bool FrontAgain(string str)
        {
            if (str.Substring(0, 2) == str.Substring((str.Length - 2), 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Given two strings, append them together (known as "concatenation") 
        and return the result. However, if the strings are different lengths, 
        omit chars from the longer string so it is the same length as the shorter 
        string. So "Hello" and "Hi" yield "loHi". The strings may be any length. 

MinCat("Hello", "Hi") -> "loHi"
MinCat("Hello", "java") -> "ellojava"
MinCat("java", "Hello") -> "javaello"

            I need to subtract the length of the smaller string off the front
            of the bigger string.

*/

        public string MinCat(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return a.Substring(a.Length - b.Length, b.Length) + b;
            }
            else if (b.Length > a.Length)
            {
                return a + b.Substring(b.Length - a.Length, a.Length);
            }
            else
            {
                return a + b;
            }
            
        }
        /*

Given a string, return a version without the first 2 chars. Except keep the first 
char if it is 'a' and keep the second char if it is 'b'. The string may be any 
length.

TweakFront("Hello") -> "llo"
TweakFront("away") -> "aay"
TweakFront("abed") -> "abed"

*/
        public string TweakFront(string str)
        {

           if (str.Substring(0, 1) == "a" && str.Substring(1, 1) == "b")
            {
                return str.Substring(0, str.Length);
            }
            
            else if (str.Substring(0, 1) == "a")
            {
                return str.Substring(0, 1) + str.Substring(2, (str.Length - 2));
            }
                
            else if (str.Substring(0, 1) == "b")
            {
                return str.Substring(0, 1) + str.Substring(2, (str.Length - 2));
            }
    
           else
            {
                return str.Substring(2, (str.Length - 2));
            }

        }

        /* Given a string, if the first or last chars are 'x', 
        return the string 
        without those 'x' chars, and otherwise return the 
        string unchanged. 

StripX("xHix") -> "Hi"
StripX("xHi") -> "Hi"
StripX("Hxix") -> "Hxi"

*/

        public string StripX(string str)
        {
            if (str.Substring(0,1) == "x" && str.Substring((str.Length - 1), 1) == "x")
            {
                return str.Substring(1, (str.Length -2));
            }
            else if (str.Substring(0,1) == "x")
            {
                return str.Substring(1);
            }
            else if (str.Substring((str.Length -1), 1) == "x")
            {
                return str.Substring(0, (str.Length - 2));
            }
            else
            {
                return str.Substring(0);
            }
        }

    }
}
