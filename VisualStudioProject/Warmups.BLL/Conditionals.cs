using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Conditionals
    {
        /* We have two children, a and b, and the parameters aSmile and 
           bSmile indicate if each is smiling. We are in trouble if they 
           are both smiling or if neither of them is smiling. Return true 
           if we are in trouble. 
        */
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            if (aSmile && bSmile)
                return true;

            if (!aSmile && !bSmile)
                return true;

            return false;
        }

        /* The parameter weekday is true if it is a weekday, and the parameter 
        vacation is true if we are on vacation. 
We sleep in if it is not a weekday or we're on vacation. Return true if we sleep in. 

sleepIn(false, false) -> true
sleepIn(true, false) -> false
sleepIn(false, true) -> true

*/
        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            if (isWeekday == true)
            {
                return false;
            }
            else if (isVacation == true)
            {
                return true;
            }
            else return true;
        }

        /* Given two int values, return their sum. However, if the two values are 
        the same, then return double their sum. 

SumDouble(1, 2) -> 3
SumDouble(3, 2) -> 5
SumDouble(2, 2) -> 8

*/

        public int SumDouble(int a, int b)
        {
            if (a == b)
            {
                return (a + b) * 2;
            }
            else
            {
                return a + b;
            }
        }

        public int ParrotTrouble(int a)
        {
            throw new NotImplementedException();
        }

        /* Given an int n, return the absolute value of the difference between n 
        and 21, except 
return double the absolute value of the difference if n is over 21. 

Diff21(23) -> 4
Diff21(10) -> 11
Diff21(21) -> 0

*/

        public int Diff21(int n)
        {
            if (Math.Abs(n) < 21)
            {
                return 21 - Math.Abs(n);
            }
            else
            {
                return Math.Abs(21 - Math.Abs(n)) * 2;
            }

        }

        /* We have a loud talking parrot. The "hour" parameter is the current hour 
        time in the range 0..23. We are in trouble if the parrot is talking 
        and the hour is before 7 or after 20. Return true if we are in trouble. 

ParrotTrouble(true, 6) -> true
ParrotTrouble(true, 7) -> false
ParrotTrouble(false, 6) -> false

*/

        public bool ParrotTrouble(bool isTalking, int hour)///HELP!!! testcase?
        {
            if (isTalking == true && hour < 7 || hour > 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Given two ints, a and b, return true if one if them is 10 or if 
        their sum is 10. 

Makes10(9, 10) -> true
Makes10(9, 9) -> false
Makes10(1, 9) -> true

*/
        public bool Makes10(int a, int b)
        {
            if (a == 10 || b == 10)
            {
                return true;
            }
            else if (a + b == 10)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /* Given an int n, return true if it is within 10 of 100 or 200.
Hint: Check out the C# Math class for absolute value


NearHundred(103) -> true
NearHundred(90) -> true
NearHundred(89) -> false

*/
        public bool NearHundred(int n)
        {
            if (n >= 90 && n <= 110)
            {
                return true;
            }

            else if (n >= 190 && n <= 210)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /* Given two int values, return true if one is negative and one is positive.
        Except if the parameter "negative" is true, then return true only if both 
        are negative. 

PosNeg(1, -1, false) -> true
PosNeg(-1, 1, false) -> true
PosNeg(-4, -5, true) -> true

*/

        public bool PosNeg(int a, int b, bool negative)// HELP!!!
        {
            if (negative == true && a == -a && b == -b)
            {
                return true;
            }

            if (a == -a || b == -b && negative == false)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /* Given a string, return a new string where "not " has been added 
        to the front. However, if the string already begins with "not", return 
        the string unchanged.

Hint: Look up how to use "SubString" in c#

NotString("candy") -> "not candy"
NotString("x") -> "not x"
NotString("not bad") -> "not bad"

*/

        public string NotString(string s)
        {
            if (s.Length < 3)
            {
                return "not " + s;
            }

            else if (s.Substring(0, 3) == "not")
            {
                return s;
            }

            else
            {
                return "not " + s;
            }
        }

        /* Given a non-empty string and an int n, return a new string where the 
        char at index n has been removed. The value of n will be a valid index of 
        a char in the original string (Don't check for bad index). 

MissingChar("kitten", 1) -> "ktten"
MissingChar("kitten", 0) -> "itten"
MissingChar("kitten", 4) -> "kittn"

*/

        public string MissingChar(string str, int n)
        {
            return str.Remove(n, 1);
        }

        /* Given a string, return a new string where the first and last chars 
        have been exchanged. 

FrontBack("code") -> "eodc"
FrontBack("a") -> "a"
FrontBack("ab") -> "ba"

*/

        public string FrontBack(string str)
        {
            if (str.Length < 2)
            {
                return str;
            }
            else
            {
                return str.Substring(str.Length - 1) + str.Substring(1, (str.Length - 2))
               + str.Substring(0, 1);
            }

        }

        /* Given a string, we'll say that the front is the first 3 chars of the 
        string. If the string length is less than 3, the front is whatever is there.
        Return a new string which is 3 copies of the front. 

Front3("Microsoft") -> "MicMicMic"
Front3("Chocolate") -> "ChoChoCho"
Front3("at") -> "atatat"
*/

        public string Front3(string str)
        {
            if (str.Length < 3)
            {
                return str + str + str;
            }
            else
            {
                return str.Substring(0, 3) + str.Substring(0, 3) + str.Substring(0, 3);

            }
        }

        /* Given a string, take the last char and return a new string with the 
        last char added at the front and back, so "cat" yields "tcatt". The original
        string will be length 1 or more. 

BackAround("cat") -> "tcatt"
BackAround("Hello") -> "oHelloo"
BackAround("a") -> "aaa"
*/

        public string BackAround(string str)
        {
            return str.Substring(str.Length - 1) + str + str.Substring(str.Length - 1);

        }

        /* Return true if the given non-negative number is a multiple of 3 or 
        a multiple of 5. Use the % "mod" operator

Multiple3or5(3) -> true
Multiple3or5(10) -> true
Multiple3or5(8) -> false

*/

        public bool Multiple3or5(int number)
        {
            if (Math.Abs(number) % 3 == 0 || Math.Abs(number) % 5 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Given a string, return true if the string starts with "hi" and false 
        otherwise. 

StartHi("hi there") -> true
StartHi("hi") -> true
StartHi("high up") -> false
*/

        public bool StartHi(string str)//HELP!!!
        {
            if (str.Substring(0, 2) == "hi" && str.Length == 2)
            {
                return true;
            }

            else if (str.Substring(0, 2) == "hi" && str.Substring(3, 1) == "")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /* Given two temperatures, return true if one is less than 0 and the other 
        is greater than 100. 

IcyHot(120, -1) -> true
IcyHot(-1, 120) -> true
IcyHot(2, 120) -> false
*/

        public bool IcyHot(int temp1, int temp2)
        {
            if (temp1 < 0 && temp2 > 100)
            {
                return true;
            }
            else if (temp1 > 100 && temp2 < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Given 2 int values, return true if either of them is in the range 10..20 
        inclusive. 

Between10and20(12, 99) -> true
Between10and20(21, 12) -> true
Between10and20(8, 99) -> false

*/

        public bool Between10and20(int a, int b)
        {
            if (a >= 10 || a <= 20)
            {
                return true;
            }
            else if (b >= 10 || b <= 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* We'll say that a number is "teen" if it is in the range 13..19 inclusive.
        Given 3 int values, return true if 1 or more of them are teen. 

HasTeen(13, 20, 10) -> true
HasTeen(20, 19, 10) -> true
HasTeen(20, 10, 12) -> false
*/

        public bool HasTeen(int a, int b, int c)
        {
            if (a >= 13 && a <= 19 || b >= 13 && b <= 19 || c >= 13 && c <= 19)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* We'll say that a number is "teen" if it is in the range 13..19 inclusive.
        Given 2 int values, return true if one or the other is teen, but not both. 

SoAlone(13, 99) -> true
SoAlone(21, 19) -> true
SoAlone(13, 13) -> false
*/

        public bool SoAlone(int a, int b)
        {
            if (a >= 13 && a <= 19 && b >= 13 && b <= 19)
            {
                return false;
            }
            else if (a >= 13 && a <= 19 || b >= 13 && b <= 19)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        /* Given a string, if the string "del" appears starting at index 1, return 
        a string where that "del" has been deleted. Otherwise, return the string 
        unchanged. 

RemoveDel("adelbc") -> "abc"
RemoveDel("adelHello") -> "aHello"
RemoveDel("adedbc") -> "adedbc"
*/

        public string RemoveDel(string str)
        {
            if (str.Substring(1, 3) == "del")
            {
                return str.Remove(1, 3);
            }
            else
            {
                return str;
            }
        }

        /* Return true if the given string begins with "*ix", the '*' can be 
        anything, so "pix", "9ix" .. all count. 

IxStart("mix snacks") -> true
IxStart("pix snacks") -> true
IxStart("piz snacks") -> false
*/

        public bool IxStart(string str)
        {
            if (str.Substring(1, 2) == "ix")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
