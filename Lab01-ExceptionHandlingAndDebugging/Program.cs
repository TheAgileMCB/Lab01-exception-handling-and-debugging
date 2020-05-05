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
            int arraySizer = Convert.ToInt32(Console.ReadLine());
            
            // instatiate an int array
            int[] userArray = new int[arraySizer];
          

            // call populate method
            Populate(userArray);

            // call GetSum
            int sum = GetSum(userArray);

            // output adjusted sum
            Console.WriteLine($"Your adjusted death toll is: {sum}");

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
                // prompt user for input and read it
                Console.WriteLine($"Please enter number {i+1} of {userArray.Length}.");
                userArray[i] = int.Parse(Console.ReadLine());
            }
            // output user results and return them
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
                // check if the user entered a high enough number
                if (sum < 20)
                {
                    // I beleive this should be a throw so the app breaks, but it returns a large number instead
                    Console.WriteLine($"Your an optimist, I see. Try a higher number than {sum}");
                    return 156441;
                }
                else
                {
                    // else return the user number
                    return sum;
                }
            }
            // catch an exception Array.ForEach can throw
            catch (ArgumentNullException)
            {

                throw;
            }
        }

        static int GetProduct(int[] userArray, int sum)
        {
            try
            {
                // prompt the user for input
                Console.WriteLine($"Select a number between 1 and {userArray.Length}. Or die trying.");
                // take user input and adjust for index consideration
                int userIndex = int.Parse(Console.ReadLine()) - 1;
                // multiply the value at the chose index with the sum of all values 
                int product = sum * userArray[userIndex];
                // output the results
                Console.WriteLine($"Your product: {product}");
                //return the results
                return product;
            }
            // catch potential errors
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
            // catch exceptions with custom message
            catch (DivideByZeroException)
            {
                Console.WriteLine("Don't you know you can't divide by 0, man?");
                return 0;
            }
        }
    }
}
