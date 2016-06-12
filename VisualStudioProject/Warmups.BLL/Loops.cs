using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Loops
    {
        /* Given a string and a non-negative int n, return a 
           larger string that is n copies of the original string. 
        */
        public string StringTimes(string str, int n)
        {
            string result = "";

            for (int i = 1; i <= n; i++)
            {
                result = result + str;
            }

            return result;
        }

        /* Given a string and a non-negative int n, we'll say that the front of the string
        is the first 3 chars, or whatever is there if the string is less than length 3. 
        Return n copies of the front; 

FrontTimes("Chocolate", 2) -> "ChoCho"
FrontTimes("Chocolate", 3) -> "ChoChoCho"
FrontTimes("Abc", 3) -> "AbcAbcAbc"
   */

        public string FrontTimes(string str, int n)
        {
            string result = "";

            for (int i = 0; i < n; i++)
            {
                result = result + str.Substring(0, 3);
            }

            return result;
        }

        /* Count the number of "xx" in the given string. We'll say that overlapping 
is allowed, so "xxx" contains 2 "xx". 

CountXX("abcxx") -> 1
CountXX("xxx") -> 2
CountXX("xxxx") -> 3
*/

        public int CountXX(string str)
        {
            int xCount = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == 'x' && str[i+1] == 'x')
                {
                    xCount++;
                }
     
            }
            return xCount;
        }

        /* Given a string, return true if the first instance of "x" in the string is immediately followed 
        by another "x". 

DoubleX("axxbb") -> true
DoubleX("axaxxax") -> false
DoubleX("xxxxx") -> true
*/

        public bool DoubleX(string str)
        {
            if (str[str.IndexOf("x") + 1] == 'x')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Given a string, return a new string made of every other char starting with the first, 
        so "Hello" yields "Hlo". 

EveryOther("Hello") -> "Hlo"
EveryOther("Hi") -> "H"
EveryOther("Heeololeo") -> "Hello"
*/

        public string EveryOther(string str)
        {
            string newEveryOther = "";

            for (int i = 0; i < str.Length; i+=2)
            {
                newEveryOther = newEveryOther + str.Substring(i, 1);
            }
            return newEveryOther;
        }

        /* Given a non-empty string like "Code" return a string like "CCoCodCode".  
        (first char, first two, first 3, etc)

StringSplosion("Code") -> "CCoCodCode"
StringSplosion("abc") -> "aababc"
StringSplosion("ab") -> "aab"

            take the first char and show it
            show the first and second chars
            show the first, second, and third chars,
            etc....

*/

        public string StringSplosion(string str)
        {
            string newString = "";

            for (int i = 0; i < str.Length; i++)
            {
                newString = newString + str.Substring(0, i + 1);
            }
            return newString;
        }

        /* Given a string, return the count of the number of times that a substring length 2 
        appears in the string and also as the last 2 chars of the string, so "hixxxhi" yields 1 
        (we won't count the end substring). 

CountLast2("hixxhi") -> 1
CountLast2("xaxxaxaxx") -> 1
CountLast2("axxxaaxx") -> 2
*/

        public int CountLast2(string str)
        {
            int stringCount = 0;

            for (int i = 0; i < str.Length - 2; i++)
            {
                if (str.Substring(i, 2) == str.Substring((str.Length-2), 2) )
                {
                    stringCount++;
                }
            }
                return stringCount;
        }

        /* Given an array of ints, return the number of 9's in the array. 

Count9({1, 2, 9}) -> 1
Count9({1, 9, 9}) -> 2
Count9({1, 9, 9, 3, 9}) -> 3
*/

        public int Count9(int[] numbers)
        {
            int nineCount = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 9)
                {
                    nineCount++;
                }

            }
            return nineCount;
        }

        /* Given an array of ints, return true if one of the first 4 elements in the array is a 9. 
        The array length may be less than 4. 

ArrayFront9({1, 2, 9, 3, 4}) -> true
ArrayFront9({1, 2, 3, 4, 9}) -> false
ArrayFront9({1, 2, 3, 4, 5}) -> false
*/

        public bool ArrayFront9(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 9 && i < 4)
                {
                    return true;
                }
            }
            return false;
        }

        /* Given an array of ints, return true if .. 1, 2, 3, .. appears in the array somewhere. 

Array123({1, 1, 2, 3, 1}) -> true
Array123({1, 1, 2, 4, 1}) -> false
Array123({1, 1, 2, 1, 2, 3}) -> true
*/

        public bool Array123(int[] numbers)
        {
            string numbersStorage = "";
            for (int i = 0; i < numbers.Length; i++)
            {
                numbersStorage = numbersStorage + numbers[i].ToString();
            }
            if (numbersStorage.Contains("123"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Given 2 strings, a and b, return the number of the positions where they contain the same 
        length 2 substring. So "xxcaazz" and "xxbaaz" yields 3, since the "xx", "aa", and "az" substrings 
        appear in the same place in both strings. 

SubStringMatch("xxcaazz", "xxbaaz") -> 3
SubStringMatch("abc", "abc") -> 2
SubStringMatch("abc", "axc") -> 0
*/

        public int SubStringMatch(string a, string b)
        {
            int lengthCountStorage = 0;
            for (int i = 0; i < a.Length - 1 && i < b.Length - 1; i++)
            {
                if (a.Substring(i, 2) == b.Substring(i, 2))
                {
                    lengthCountStorage++;
                }
            }
            return lengthCountStorage;
        }

        /* Given a string, return a version where all the "x" have been removed. Except an "x" at the very 
        start or end should not be removed. 

StringX("xxHxix") -> "xHix"
StringX("abxxxcd") -> "abcd"
StringX("xabxxxcdx") -> "xabcdx"
*/

        public string StringX(string str)
        {
            string beginX = "";
            string endX = "";
            string newStringX = "";
            if (str.Substring(0, 1) == "x" && str.Substring((str.Length - 1), 1) == "x")
            {
                beginX = "x";
                endX = "x";
            }
            else if (str.Substring(0, 1) == "x" && str.Substring((str.Length - 1), 1) != "x")
            {
                beginX = "x";
            }
            else if (str.Substring(0, 1) != "x" && str.Substring((str.Length - 1), 1) == "x")
            {
                endX = "x";
            }
            for (int i = 0; i < str.Length; i++)
            {
                str.Substring(i, 1);
                if (str.Substring(i, 1) == "x")
                {
                    str.Remove(i, 1);
                }
                else
                {
                    newStringX = newStringX + str.Substring(i, 1);
                }
            }
            return beginX + newStringX + endX;
        }

















    }
}
