using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distinct_Number_Array_Sum
{
    class Program
    {
        /// <summary>
        /// My current task is to find a score from an array where the highest/lowest scores have been taken away, 
        /// and if the highest/lowest occur more than once (ONLY if they occur more than once), one of them can be added:
        /// E.g. int[] scores = [4, 8, 6, 4, 8, 5]
        /// therefore the final addition will be ∑4,8,6,5=23.
        /// Another condition of the task is that LINQ cannot be used, as well as any of the System.Array methods
        /// http://codereview.stackexchange.com/questions/61025/special-summation-of-integer-array-elements
        /// </summary>
        

        static void Main(string[] args)
        {
            // take an array and sum the distinct numbers
            int[] numberArray = { 4, 8, 6, 4, 8, 5 };
            int[] numberArray2 = { 4, 4, 5, 6, 8, 8 };
            //Console.WriteLine(totalSum(numberArray).ToString());
            //Console.WriteLine(totalSum(numberArray2).ToString());
            //Console.WriteLine("sumSpecial Results below.");

            Console.WriteLine(sumSpecial(numberArray).ToString());
            Console.WriteLine(sumSpecial(numberArray).ToString());
            
            Console.ReadLine();
        }

        //static int totalSum(int[] integerArray)
        //{
        //    int total = 0;
            
        //    for (int i = 0; i < integerArray.Length; i++)
        //    {
        //        for (int j = i + 1; j < integerArray.Length; j++)
        //        {
        //            if (integerArray[i] == integerArray[j])
        //            {
        //                total -= integerArray[j];
        //            }
        //        }
        //        total += integerArray[i];
        //    }
        //    return total;
        //}

        static int getHighestScore(int[] integerArray)
        {
            var high = 0;
            foreach (int number in integerArray)
            {
                high = high < number ? number : high;
            }
            return high;
        }

        static int getLowestScore(int[] integerArray)
        {
            var low = int.MaxValue;
            foreach (int number in integerArray)
            {
                low = low > number ? number : low;
            }
            return low;
        }

        static int sumWithoutHighAndLowScores(int[] integerarray)
        {
            int sum = 0;
            int high = getHighestScore(integerarray);
            int low = getLowestScore(integerarray);
            foreach (int number in integerarray)
            {
                if (number != high && number != low)
                {
                    sum += number;
                }
            }
            return sum;
        }

        //sum of numbers using high or low only if there is a duplicate of high or low
        static int SumSpecial_old(int[] integerArray)
        {
            var sum = sumWithoutHighAndLowScores(integerArray);
            var high = getHighestScore(integerArray);
            var low = getLowestScore(integerArray);

            var highs = 0;
            var lows = 0;
            foreach (int number in integerArray)
            {
                if (number == high) { highs++; }
                if (number == low) { lows++; }
            }
            if (lows > 1) { sum += low; }
            if (highs > 1) { sum += high; }

            return sum;
        }

        static void DetermineMinAndMax(int[] integerArray, out int min, out int max)
        {
            min = Int32.MaxValue;
            max = Int32.MinValue;
            foreach (int number in integerArray)
            {
                if (number < min) { min = number; }
                else if (number > max) { max = number; }
            }
        }


    }
}
