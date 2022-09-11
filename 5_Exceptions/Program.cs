using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // WithoutTryCatch(); // Uncomment to test.
            ExceptionSyntax();
            Console.WriteLine();

            HandleDifferentException(Array.Empty<string>());
            Console.WriteLine();

            HandleDifferentException(new string[1]);
            Console.WriteLine();

            try
            {
                ThrowingExceptions(true);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);

                try
                {
                    ThrowingExceptions(false);
                }

                catch (Exception ex2)
                {
                    Console.WriteLine(ex2.StackTrace);
                }
            }
            Console.WriteLine();

            FinallyHandling(false);
            Console.WriteLine();

            try
            {
                FinallyHandling(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception received. {ex.Message}");
            }
            Console.WriteLine();

            UsingConcept();
            Console.WriteLine();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void WithoutTryCatch()
        {
            int denominator = 0;
            int numerator = 100;

            Console.WriteLine(numerator / denominator);
        }

        private static void ExceptionSyntax()
        {
            try
            {
                string name = null;
                bool isEqual = name.Equals("Bill Gates");

                Console.WriteLine($"{name} is Bill Gates. : {isEqual}.");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {

            }

            catch
            {
                // Catch any exceptions and don't care the details.
            }

            try
            {

            }

            catch (Exception)
            {
                // Catch specific exception and dont't care the details.
            }
        }

        private static void HandleDifferentException(string[] strings)
        {
            try
            {
                Console.WriteLine($"First item in array is {strings[0].ToString()}");
            }

            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Trying to access an out-of-range element in an array.");
            }

            catch (NullReferenceException)
            {
                Console.WriteLine($"Trying to access a null element.");
            }
        }

        private static void ThrowingExceptions(bool isThrowNewException)
        {
            try
            {
                Dictionary<int, string> names = new Dictionary<int, string>()
                {
                    { 1, "Bill Gates" },
                    { 2, "Jeff Bezos"},
                    { 3, "Mark Zukerberg" },
                    { 4, "Tim Cook" }
                };

                Console.WriteLine(names[5]);
            }

            catch
            {
                if (isThrowNewException)
                {
                    throw new Exception("You will lost stack trace if doing this.");
                }

                throw;
            }
        }

        private static void FinallyHandling(bool throwException)
        {
            try
            {
                if (throwException)
                {
                    throw new Exception("Purposely throw.");
                }

                Console.WriteLine("Codes execute normally.");
            }

            catch (Exception)
            {
                Console.WriteLine("Catch will execute first.");
                throw; // rethrow exception.
            }

            finally
            {
                Console.WriteLine("Finally will always execute.");
            }
        }

        private static void UsingConcept()
        {
            using (DisposableObject disposableObject = new DisposableObject())
            {
                disposableObject.DoSomething(false);
            }
            Console.WriteLine();

            try
            {
                using (DisposableObject disposableObject = new DisposableObject())
                {
                    disposableObject.DoSomething(true);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Exception received. {ex.Message}");
            }

            // In conclusion, using is actually a try & finally block that will always call IDisposable.Dispose() function at finally to ensure the object is always disposed.
        }
    }

    internal class DisposableObject : IDisposable
    {
        public void DoSomething(bool throwException)
        {
            if (throwException)
            {
                Console.WriteLine("Trying to throw exception.");
                throw new Exception("Throw exception while doing something.");
            }

            Console.WriteLine("Complete doing something.");
        }

        public void Dispose()
        {
            Console.WriteLine("Object will always dispose no matter there is an exception or not.");
        }
    }
}
