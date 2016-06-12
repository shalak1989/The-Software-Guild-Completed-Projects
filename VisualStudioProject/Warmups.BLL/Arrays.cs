﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Arrays
    {
        /* Given an array of ints, return true if 6 appears 
           as either the first or last element in the array. 
           The array will be length 1 or more. 
        */
        public bool FirstLast6(int[] numbers)
        {
            // 0 is always the first index and 
            // Length - 1 of an array is always the last index
            return (numbers[0] == 6 || numbers[numbers.Length - 1] == 6);
        }


        /* Given an array of ints, return true if the array is 
        length 1 or more, and the first element and the last 
        element are equal. 

    SameFirstLast({1, 2, 3}) -> false
    SameFirstLast({1, 2, 3, 1}) -> true
    SameFirstLast({1, 2, 1}) -> true
    */

        public bool SameFirstLast(int[] numbers)
        {
            if (numbers.Length >= 1 && (numbers[0] == numbers[(numbers.Length - 1)]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Return an int array length n containing the first n 
        digits of pi.

MakePi(3) -> {3, 1, 4}
*/
        public int[] MakePi(int n)
        {
            string newPi = Math.PI.ToString().Remove(1, 1);
            int[] intArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                intArray[i] = int.Parse(newPi.Substring(i, 1));
            }
            return intArray;

        }
        /* Given 2 arrays of ints, a and b, return true if they have 
        the same first element or they have the same last element. Both 
        arrays will be length 1 or more. 

CommonEnd({1, 2, 3}, {7, 3}) -> true
CommonEnd({1, 2, 3}, {7, 3, 2}) -> false
CommonEnd({1, 2, 3}, {1, 3}) -> true
*/

        public bool commonEnd(int[] a, int[] b)
        {
            if (a[0] == b[0] || a[(a.Length - 1)] == b[(b.Length - 1)])
            {
                return true;
            }
            else return false;
        }

        /* Given an array of ints, return the sum of all the elements. 

Sum({1, 2, 3}) -> 6
Sum({5, 11, 2}) -> 18
Sum({7, 0, 0}) -> 7
*/

        public int Sum(int[] numbers)
        {
            return numbers.Sum();
        }

        /* Given an array of ints, return an array with the elements 
        "rotated left" so {1, 2, 3} yields {2, 3, 1}. 

RotateLeft({1, 2, 3}) -> {2, 3, 1}
RotateLeft({5, 11, 9}) -> {11, 9, 5}
RotateLeft({7, 0, 0}) -> {0, 0, 7}
*/

        public int[] RotateLeft(int[] numbers)
        {
            int[] arrayData = new int[numbers.Length];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                arrayData[i] = numbers[i + 1];
            }
            arrayData[(arrayData.Length - 1)] = numbers[0];
            return arrayData;

        }

        /* Given an array of ints length 3, return a new array with the 
        elements in reverse order, so for example {1, 2, 3} becomes {3, 2, 1}. 

*/
        public int[] Reverse(int[] numbers)
        {
            Array.Reverse(numbers);

            return numbers;
        }

        /* Given an array of ints, figure out which is larger 
        between the first and last elements in the array, and set all 
        the other elements to be that value. Return the changed array. 

HigherWins({1, 2, 3}) -> {3, 3, 3}
HigherWins({11, 5, 9}) -> {11, 11, 11}
HigherWins({2, 11, 3}) -> {3, 3, 3}

*/

        public int[] HigherWins(int[] numbers)
        {
            int newArrayNumber = numbers[0];
            if (numbers[0] > numbers[numbers.Length - 1])
            {
                newArrayNumber = numbers[0];
            }
            else if (numbers[0] < numbers[numbers.Length - 1])
            {
                newArrayNumber = numbers[(numbers.Length - 1)];
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = newArrayNumber;
            }
            return numbers;
        }

        /*Given 2 int arrays, a and b, each length 3, return a new array length 2 
        containing their middle elements. 

GetMiddle({1, 2, 3}, {4, 5, 6}) -> {2, 5}
GetMiddle({7, 7, 7}, {3, 8, 0}) -> {7, 8}
GetMiddle({5, 2, 9}, {1, 4, 5}) -> {2, 4}
*/

        public int[] GetMiddle(int[] a, int[] b)
        {
            int aInt = a[a.Length / 2];
            int bInt = b[b.Length / 2];
            int[] arrayInt = { aInt, bInt };
            //int[] numbers = new int[3];//
            return arrayInt;
        }

        /* Given an int array , return true if it contains an even number 
(HINT: Use Mod (%)). 

HasEven({2, 5}) -> true
HasEven({4, 3}) -> true
HasEven({7, 5}) -> false
*/

        public bool HasEven(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    return true;
                }
            }
            return false;
        }

        /* Given an int array, return a new array with double the length where its last element is the 
        same as the original array, and all the other elements are 0. The original array will be length 1 or more. 
        Note: by default, a new int array contains all 0's. 

KeepLast({4, 5, 6}) -> {0, 0, 0, 0, 0, 6}
KeepLast({1, 2}) -> {0, 0, 0, 2}
KeepLast({3}) -> {0, 3}
*/

        //int[] numbers = new int[3];//

        public int[] KeepLast(int[] numbers)
        {
            int[] newArray = new int[numbers.Length*2];
            newArray[newArray.Length - 1] = numbers[numbers.Length - 1];
            return newArray;
        }

        /* Given an int array, return true if the array contains 2 twice, or 3 twice. 

Double23({2, 2, 3}) -> true
Double23({3, 4, 5, 3}) -> true
Double23({2, 3, 2, 2}) -> false
*/

        public bool Double23(int[] numbers)
        {
            int numberTwoChar = 0;
            int numberTwoCharCount = 0;
            int numberThreeChar = 0;
            int numberThreeCharCount = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                numberTwoChar = numbers[i];
                numberThreeChar = numbers[i];

                if (numberTwoChar == 2)
                {
                    numberTwoCharCount++;
                }
                else if (numberThreeChar == 3)
                {
                    numberThreeCharCount++;
                }   
            }

            if (numberTwoCharCount == 2 && numberTwoCharCount < 3 || numberThreeCharCount == 2 && numberThreeCharCount < 3)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        /* Given an int array length 3, if there is a 2 in the array immediately followed by a 3, 
        set the 3 element to 0. Return the changed array. 

Fix23({1, 2, 3}) ->{1, 2, 0}
Fix23({2, 3, 5}) -> {2, 0, 5}
Fix23({1, 2, 1}) -> {1, 2, 1}
*/

        public int[] Fix23(int[] numbers)
        {
            if (numbers[0] == 2 && numbers [1] == 3)
            {
                numbers[1] = 0;
            }
            else if (numbers[1] == 2 && numbers [2] == 3)
            {
                numbers[2] = 0;
            }
            return numbers;
        }

        /* We'll say that a 1 immediately followed by a 3 in an array is an "unlucky" 1. 
Return true if the given array contains an unlucky 1 in the first 2 or last 2 positions in the array. 

Unlucky1({1, 3, 4, 5}) -> true
Unlucky1({2, 1, 3, 4, 5}) -> true
Unlucky1({1, 1, 1}) -> false
*/

        public bool Unlucky1(int[] numbers)
        {
            if (numbers[numbers.Length-2] == 1 && numbers[numbers.Length-1] == 3)
            {
                return true;
            }
            else if (numbers[0] == 1 && numbers[1] == 3 || numbers[1] == 1 && numbers[2] == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Given 2 int arrays, a and b, return a new array length 2 containing, as much as will fit, 
        the elements from a followed by the elements from b. The arrays may be any length, including 0,
        but there will be 2 or more elements available between the 2 arrays. 

Make2({4, 5}, {1, 2, 3}) -> {4, 5}
Make2({4}, {1, 2, 3}) -> {4, 1}
Make2({}, {1, 2}) -> {1, 2}
*/

        public int[] make2(int[] a, int[] b)
        {
           int[] numbers2 = new int[2];

            for (int i = 0; i < numbers2.Length; i++)
            {
                if (i < a.Length && a.Length > 0)
                {
                    numbers2[i] = a[i];
                    if (a.Length == 1)
                    {
                        numbers2[1] = b[0];
                        break;
                    }
                }
                
                else
                {
                    numbers2[i] = b[i];
                }                
            }
            return numbers2;
        }
















    }
  }
