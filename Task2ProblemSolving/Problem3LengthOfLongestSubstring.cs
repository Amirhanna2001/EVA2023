using System;
using System.Collections.Generic;

namespace CsSyntax
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string");
            string input = Console.ReadLine();

            int result = LengthOfLongestSubstring(input);
            Console.WriteLine(result);
        }

        public static int LengthOfLongestSubstring(string input)
        {
            int maxLength = 0;
            int start = 0;
            int index = 0;
            HashSet<char> uniqueChars = new ();

            while (index < input.Length)
            {
                char currentChar = input[index];

                if (uniqueChars.Contains(currentChar))
                {
                    uniqueChars.Remove(input[start]);
                    ++start;
                }
                else
                {
                    uniqueChars.Add(currentChar);
                    maxLength = Math.Max(maxLength, index - start + 1);
                    ++index;
                }
            }

            return maxLength;
        }




    }
}
