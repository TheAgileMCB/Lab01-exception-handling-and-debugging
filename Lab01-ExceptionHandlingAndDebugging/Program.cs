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
                Console.WriteLine("DOGS OF WAR");
                Console.WriteLine("Welcome to the war room, General. You are our last hope. You will need to learn quickly to face the foes before us. Or our culture shall be swallowed by the Darkness.");
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
            // set int user input to array size to 0 to set while loop
            int arraySizer = 0;
            while (arraySizer == 0)
            {
                // ask user for input
                Console.WriteLine("Prepare for battle, General. How many battalions do you require today?");
                arraySizer = Convert.ToInt32(Console.ReadLine());
            }
            
            // instatiate an int array
            int[] userArray = new int[arraySizer];
          

            // call populate method
            Populate(userArray);

            // call GetSum
            int sum = GetSum(userArray);

            // output adjusted sum
            Console.WriteLine($"Your enhanced troop count is {sum}");

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
                Console.WriteLine($"Please number the undead troops of battalion {i+1} of {userArray.Length}.");
                userArray[i] = int.Parse(Console.ReadLine());
            }
            // output user results and return them
            Console.WriteLine($"Your battalions number as follows: {String.Join(", ", userArray)}");
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
                    Console.WriteLine($"Your an optimist, I see. But you over-estimate your abilities! You will ceratinly require more troops than {sum}.");
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
                Console.WriteLine("Nice try General, but you aren't getting out of this one.");
                throw;
            }
        }

        static int GetProduct(int[] userArray, int sum)
        {
            try
            {
                // prompt the user for input
                Console.WriteLine($"You will need far more troops than you can comprehend to win this war, General. Select a multiplier between 1 and {userArray.Length} and the necromancers shall grant it.");
                // take user input and adjust for index consideration
                int userIndex = int.Parse(Console.ReadLine()) - 1;
                // multiply the value at the chose index with the sum of all values 
                int product = sum * userArray[userIndex];
                // output the results
                Console.WriteLine($"Yes-- {product} --NOW a suitable army.");
                //return the results
                return product;
            }
            // catch potential errors
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("You're not getting out of this one, General!");
                throw;
           
            }

        }

        static decimal GetQuotient(int product)
        {
            try
            {
                //ask for user input
                Console.WriteLine($"Enter a number by which to divide your staggering {product} undead soldiers.");
                // parse user input
                int dividend = int.Parse(Console.ReadLine());
                // declare decimal variable
                decimal quotient = decimal.Divide(product, dividend);
                Console.WriteLine($"Only {quotient} soldiers survived this day. But the war is won; you served your kingdom well. The Board is sorry you had to sacrifice your life for the cause of our culture. Statues shall be errected in your honor and our independence day shall be celebrated in your name.");
                // return quotient
                return quotient;
            }
            // catch exceptions with custom message
            catch (DivideByZeroException)
            {
                Console.WriteLine("Don't you know you can't divide by 0, man?!");
                return 0;
            }
        }
    }
}
