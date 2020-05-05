using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Lab01_ExceptionHandlingAndDebugging
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                // call StartSequence
                Console.WriteLine("Welcome to the war games. Are the odds in your favor?");
                StartSequence();
            }
            catch (Exception)
            {
                // handle general exceptions
                Console.WriteLine("Mistakes were made. Men have died.");
                throw;
            }
            finally
            {
                // signal the application is finished
                Console.WriteLine("MISSION COMPLETE!");
            }
        }

        private static void StartSequence()
        {
            // ask user for input
            Console.WriteLine("The death toll is much higher than zero. Just how many measures? Try to guess.");
            int arraySizer = int.Parse(Console.ReadLine());
            
            // instatiate an int array
            int[] userArray = new int[arraySizer];
          

            // call populate method
            Populate(userArray);

            // call GetSum
            int sum = GetSum(userArray);

            // call GetProduct
           int product = GetProduct(userArray, sum);

            // call GetQuotient
            decimal quotient = GetQuotient(product);

        }

        private static int[] Populate(int[] userArray)
        {
            //iterate through an array
            for (int i = 0; i < userArray.Length; i++)
            {
                Console.WriteLine($"Please enter number {i+1} of {userArray.Length}.");
                userArray[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"Your numbers are: {String.Join(", ", userArray)}");
            return userArray;
        }

        private static int GetSum(int[] userArray)
        {
            // declare sum variable
            int sum = 0;

            try
            {
                // iterate through array and sum all elements

                Array.ForEach(userArray, i => sum += i);

                Console.WriteLine(sum);
                if (sum < 20)
                {
                    Console.WriteLine($"Your an optimist, I see. Try a higher number than {sum}");
                    return 156441;
                }
                else
                {
                    return sum;
                }
            }
            catch (ArgumentNullException)
            {

                throw;
            }
        }

        static int GetProduct(int[] userArray, int sum)
        {
            try
            {
                Console.WriteLine($"Select a number between 1 and {userArray.Length}. Or die trying.");
                int userIndex = int.Parse(Console.ReadLine()) - 1;
                int product = sum * userArray[userIndex];
                Console.WriteLine($"Your product: {product}");
                return product;
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }

        }

        static decimal GetQuotient(int product)
        {
            try
            {
                //ask for user input
                Console.WriteLine($"Enter a number to divide your staggering {product} undead soldiers by.");
                // parse user input
                int dividend = int.Parse(Console.ReadLine());
                // declare decimal variable
                decimal quotient = decimal.Divide(product, dividend);
                Console.WriteLine($"Your quotient: {quotient}");
                // return quotient
                return quotient;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Don't you know you can't divide by 0, man?");
                throw;
            }
        }
    }
}
