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
                Console.WriteLine("Welcome to my game! Let's do some math!");
                StartSequence();
            }
            catch (Exception)
            {
                // handle general exceptions
                Console.WriteLine("Mistakes were made. Whoops.");
                throw;
            }
            finally
            {
                // signal the application is finished
                Console.WriteLine("Program COMPLETE!");
            }
        }

        private static void StartSequence()
        {
            // ask user for input
            Console.WriteLine("Please, enter a number greater than zero:");
            int arraySizer = int.Parse(Console.ReadLine());
            
            // instatiate an int array
            int[] userArray = new int[arraySizer];
          

            // call populate method
            Populate(userArray);

            // call GetSum
            GetSum(userArray);

            // call GetProduct
           GetProduct(userArray, sum);

            // call GetQuotient
            GetQuotient(product);

        }

        private static int[] Populate(int[] userArray)
        {
            //iterate through an array
            for (int i = 0; i < userArray.Length; i++)
            {
                Console.WriteLine($"Please enter number {i+1} of {userArray.Length}.");
                userArray[i] = int.Parse(Console.ReadLine());
            }
            
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
                    Console.WriteLine("Your number is toooo loooow, friend!");
                    return 0;
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

        static int GetProduct(int[] userArray)
        {
            Console.WriteLine($"Select a number between 1 and {userArray.Length}, please.");

        }

        static int GetQuotient()
        {

        }
    }
}
