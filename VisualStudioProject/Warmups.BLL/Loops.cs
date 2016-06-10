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












    }
}
