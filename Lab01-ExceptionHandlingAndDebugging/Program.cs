using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Lab01_ExceptionHandlingAndDebugging
{
    class Program
    {
        static void Main(string[] args)
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

        static void StartSequence()
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
           //GetProduct(userArray, sum);

            // call GetQuotient
            //GetQuotient(product);

        }

        static int[] Populate(int[] popArray)
        {
            //iterate through an array
            for (int i = 0; i < popArray.Length; i++)
            {
                Console.WriteLine($"Please enter number {i+1} of {popArray.Length}");
                popArray[i] = int.Parse(Console.ReadLine());
            }
            
            return popArray;
        }

        static int GetSum(int[] sumArray)
        {
            // declare sum variable
            int sum = 0;

            // iterate through array and sum all elements
            try
            {
                Array.ForEach(sumArray, i => sum += i);

                Console.WriteLine(sum);
                return sum;

            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("This ain't a number. It's null.");
                throw;
            }
            finally
            {
                Console.WriteLine("Dooone");
            }
              


        }

        //static int GetProduct()
        //{

        //}

        //static int GetQuotient()
        //{

        //}
    }
}
