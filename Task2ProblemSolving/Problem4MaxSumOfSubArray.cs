using System;
using System.Collections.Generic;

namespace CsSyntax
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter array numbers (seperated by white space) ");
            string input = Console.ReadLine();

            bool isNumber = true;
            string[] numsInStringFormat = input.Split();
            int [] numbers = new int[numsInStringFormat.Length];

            for(int i = 0; i < numbers.Length; ++i)
            {
                isNumber = int.TryParse(numsInStringFormat[i], out numbers[i]);
                if (!isNumber)
                    break;
            }
            if (isNumber)
                Console.WriteLine($"Max Sum in the array is {MaxSumOfSubArray(numbers)}");
            else
                Console.WriteLine("Invalid input ");
            
        }

        public static int MaxSumOfSubArray(int[] numbers)
        {
            int maxSum = int.MinValue;
            int currentSum = 0;

            for (int i=0;i<numbers.Length;++i)
            {
                currentSum = Math.Max(numbers[i], currentSum + numbers[i]);
                maxSum = Math.Max(maxSum, currentSum);
            }

            return maxSum;
        }





    }
}
