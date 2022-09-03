using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicCSharp.Object;

namespace BasicCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Types
            // Value Type
            int integer = 0;
            float floatingNum = 0f;
            double doubleNum = 0d;
            decimal decimalNum = 0m;
            bool boolean = true;
            byte byteValue = 0;
            char character = 'a';
            DateTime dateTime = DateTime.Now;

            // Reference Type
            string message = "Hello C#!";
            Student student = new Student("Bill", "Gates", new DateTime(1995, 10, 28));

            Console.WriteLine($"Current number is {integer}");
            ChangeValue(integer);
            Console.WriteLine($"Current number is {integer}");
            Console.WriteLine();

            Console.WriteLine($"Current number is {integer}");
            ChangeValue(ref integer);
            Console.WriteLine($"Current number is {integer}");
            Console.WriteLine();

            Console.WriteLine($"{student.FirstName} {student.LastName} was born in {student.BirthDate.ToString("yyyy-MMM-dd")}");
            ChangeStudent(student);
            Console.WriteLine($"{student.FirstName} {student.LastName} was born in {student.BirthDate.ToString("yyyy-MMM-dd")}");
            Console.WriteLine();

            Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            ChangeValue(student.Age);
            Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            Console.WriteLine();
            #endregion

            #region SyntaxIntro
            int[] numbers = new int[100];
            string[] names = new string[]
            {
                "Bill Gates",
                "Elon Musk",
                "Mark Zuckerberg",
                "Warren Buffett",
                "Jeff Bezos",
                "Sundar Pichai",
                "Tim Cook"
            };

            List<string> planets = new List<string>()
            {
                "Mercury",
                "Venus",
                "Earth",
                "Mars",
                "Saturn",
                "Jupiter",
                "Uranus",
                "Neptune"
            };

            SyntaxIntro syntaxIntro = new SyntaxIntro();

            syntaxIntro.VoidFunction("Learning C# is fun.");
            Console.WriteLine();
            syntaxIntro.IsDividable(10, 2);
            Console.WriteLine();

            syntaxIntro.IfElseCondition();
            Console.WriteLine();
            syntaxIntro.SwitchCondition("C#");
            Console.WriteLine();

            syntaxIntro.ForLoop(names);
            Console.WriteLine();
            syntaxIntro.ForeachLoop(names);
            Console.WriteLine();

            syntaxIntro.WhileLoop(planets);
            Console.WriteLine();
            syntaxIntro.DoWhileLoop(planets);
            Console.WriteLine();
            #endregion

            #region Namespaces
            Classroom classroom = new Classroom();
            //UnknowmNamespace unknown = new UnknownNamespace.UnknowmNamespace();
            #endregion

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void ChangeStudent(Student student)
        {
            // Reference type is always pass by reference.
            student.FirstName = "Satya";
            student.LastName = "Nadella";
            student.BirthDate = new DateTime(1967, 8, 19);
            student.Age = DateTime.Today.Year - student.BirthDate.Year;
        }

        public static void ChangeValue(int integer)
        {
            // Value type always pass by value.
            integer = int.MaxValue;
        }

        public static void ChangeValue(ref int integer)
        {
            // This function enforce the parameter to pass by reference.
            integer = int.MaxValue;
        }
    }
}
