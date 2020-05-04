using System;

namespace Lab01_ExceptionHandlingAndDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
                Console.WriteLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Mistakes were made. Whoops.");
                throw;
            }
            finally
            {
                Console.WriteLine("Program COMPLETE!");
            }
        }

        static void StartSequence()
        {

        }

        static void Populate()
        {

        }

        static int GetSum()
        {

        }

        static int GetProduct()
        {

        }

        static int GetQuotient()
        {

        }
    }
}
