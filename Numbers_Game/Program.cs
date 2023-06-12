using System;

namespace Numbers_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartSequence();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void StartSequence()
        {
            Console.WriteLine("Welcome to my game! Let's do some math! Please enter a number greater than zero");
            string userInput = Console.ReadLine();

            try
            {
                int intUserInput = Convert.ToInt32(userInput);
                int[] userArr = new int[intUserInput];
                Populate(userArr);
                int sum = GetSum(userArr);
                int product = GetProduct(userArr, sum);
                decimal quotient = GetQuotient(product);

                Console.WriteLine($"\nYour array is size: {userArr.Length}");
                Console.Write("The numbers in the array are: ");
                for (int i = 0; i < userArr.Length; i++)
                {
                    Console.Write($"{userArr[i]}");
                    if (i < userArr.Length - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine($"\nThe sum of the array is: {sum}");
                Console.WriteLine($"The product of the sum and the randomly selected number is: {product}");
                Console.WriteLine($"The quotient of the product and the entered number is: {quotient}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid input format. Please enter a valid integer.");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Input exceeds the valid range of integers.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Program is complete.");
            }
        }

        static void Populate(int[] userArr)
        {
            for (int i = 0; i < userArr.Length; i++)
            {
                Console.WriteLine($"Please enter number {i + 1} of {userArr.Length}:");
                string userInput = Console.ReadLine();
                userArr[i] = Convert.ToInt32(userInput);
            }
        }

        static int GetSum(int[] userArr)
        {
            int sum = 0;
            for (int i = 0; i < userArr.Length; i++)
            {
                sum += userArr[i];
            }
            if (sum < 20)
                throw new Exception($"Value of sum: {sum} is too low");
            return sum;
        }

        static int GetProduct(int[] userArr, int sum)
        {
            Console.WriteLine($"\nPlease select a random number between 1 and {userArr.Length}:");
            string userInput = Console.ReadLine();
            int randomNumber = Convert.ToInt32(userInput);
            if (randomNumber < 1 || randomNumber > userArr.Length)
            {
                throw new IndexOutOfRangeException("Invalid random number selection");
            }
            int product = sum * userArr[randomNumber - 1];
            return product;
        }

        static decimal GetQuotient(int product)
        {
            Console.WriteLine($"\nPlease enter a number to divide your product {product} by:");
            string userInput = Console.ReadLine();
            int dividend = Convert.ToInt32(userInput);
            try
            {
                decimal quotient = decimal.Divide(product, dividend);
                return quotient;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return 0;
            }
        }
    }
}
