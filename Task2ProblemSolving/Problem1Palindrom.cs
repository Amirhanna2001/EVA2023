using System;
namespace CsSyntax
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to check if a palindrom number or not ");
            string input = Console.ReadLine();
            int number; 
            bool isNumber = int.TryParse(input,out number);

            if (isNumber)
            {
                if(IsPalindromNumber(input))
                   Console.WriteLine($"Number : {number} Is a Palindrom number ");
                else
                    Console.WriteLine($"Number : {number} Is Not a Palindrom number ");
            }
            else
                Console.WriteLine("Invalid Input, its not a number");
        }
        public static bool IsPalindromNumber(string input)
        {
            int left  = 0,right = input.Length-1;
            while (left <= right)
            {
                if (input[left] != input[right])
                    return false;

                left++;
                right--;
            }

            return true;
        }

    }
}
