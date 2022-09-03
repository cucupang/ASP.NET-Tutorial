using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCSharp
{
    public class SyntaxIntro
    {
        #region Functions
        // This section introduce the way to write a function in C#

        public void VoidFunction(string value)
        {
            Console.WriteLine($"The parameter value is: {value}");
            Console.WriteLine("This is a function that does not return anything.");
        }

        public bool IsDividable(int numerator, int denominator)
        {
            bool isDividable = (numerator % denominator) == 0;

            Console.WriteLine(String.Format("{0} is dividable by {1}", numerator, denominator));

            return isDividable;
        }
        #endregion

        #region Conditions
        public void IfElseCondition()
        {
            // Operators
            // == equals
            // ! not
            // != not equals
            // > greater than
            // >= greater or equals
            // < less than
            // <= less than or equals
            // && and
            // || or
            // () group condition

            int num1 = 10, num2 = 20;

            // If else condition.
            if (num1 > num2)
            {
                Console.WriteLine(num1 + " is greater than " + num2);
            }

            else if(num1 < num2)
            {
                Console.WriteLine(num1 + " is less than " + num2);
            }

            else
            {
                Console.WriteLine(num1 + " is equals to " + num2);
            }

            // Complex condition.
            bool isDog = false;
            bool isCat = true;

            if (isDog && isCat)
            {
                Console.WriteLine("This is a cat.");
            }

            else if (isDog || isCat)
            {
                Console.WriteLine("This is a cat or an animal.");
            }

            Console.WriteLine();
        }

        public void SwitchCondition(string language)
        {
            switch (language)
            {
                case "Java":
                    Console.WriteLine("Welcome to Java.");
                    break;
                case "C#":
                    {
                        Console.WriteLine("Welcome to C#.");
                        break;
                    }
                case "C++":
                    Console.WriteLine("Welcome to C++.");
                    break;
                case "JavaScript":
                case "HTML":
                    Console.WriteLine("Welcome to web development.");
                    break;
                default:
                    Console.WriteLine("No matching languages.");
                    break;
            }
        }
        #endregion

        #region Looping
        public void ForLoop(string[] array)
        {
            Console.WriteLine("Below are the contents of array:");
            for (int i = 0; i < array.Length; ++i)
            {
                Console.WriteLine($"{array[i]}");
            }
        }

        public void ForeachLoop(string[] array)
        {
            Console.WriteLine("Below are the contents of array:");
            foreach (string item in array)
            {
                Console.WriteLine(item);
            }
        }

        public void WhileLoop(List<string> strings)
        {
            // While loop
            List<string>.Enumerator enumerator = strings.GetEnumerator();

            Console.WriteLine("Below are the contents of array:");
            while (enumerator.MoveNext())
            {
                Console.WriteLine($"{enumerator.Current}");
            }
        }

        public void DoWhileLoop(List<string> strings)
        {
            List<string>.Enumerator enumerator = strings.GetEnumerator();

            Console.WriteLine("Below are the contents of array:");
            do
            {
                if (enumerator.Current != null)
                {
                    Console.WriteLine($"{enumerator.Current}");
                }
            } while (enumerator.MoveNext());
        }
        #endregion
    }
}
