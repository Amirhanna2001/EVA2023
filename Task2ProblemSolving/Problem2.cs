using System;
namespace CsSyntax
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the array of numbers (separated by white space)");
            string input = Console.ReadLine();

            string[] numbersInStringFormat = input.Split();

            Console.WriteLine("Enter target number ");
            input = Console.ReadLine();

            int[] numbers = new int[numbersInStringFormat.Length];
            int taregt;
            bool aNumber;
            for(int i=0;i<numbers.Length;++i) {
                aNumber = int.TryParse(numbersInStringFormat[i], out numbers[i]);

                if (!aNumber)
                {
                    Console.WriteLine($"Invalid input {numbersInStringFormat[i]} is not a number");
                    break;
                }
            }
            
            aNumber = int.TryParse(input,out taregt );
            if (aNumber)
            {
                int[] result = IndexesOfNumberInArray(numbers, taregt);
                if (result[0] == -1)
                    Console.WriteLine($"No Two Elements in the array equals {taregt}");
                else
                    Console.WriteLine($"The Results are :Positions ({result[0]} and {result[1]})");
            }
            else
                Console.WriteLine($"Invalid Input , {input} is not a number");
        }

        public static int[] IndexesOfNumberInArray(int[] numbers, int target)
        {
            int[] result = { -1, -1 };

            for (int i = 0; i < numbers.Length - 1; ++i)
                for (int j = i + 1; j < numbers.Length; ++j)
                    if ((numbers[j] + numbers[i]) == target)
                    {
                        result[0] = i;
                        result[1] = j;
                        return result;
                    }
            return result;
        }

    }
}
