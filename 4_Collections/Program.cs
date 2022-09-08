using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Arrays
            string[] names = new string[]
            {
                "Bill Gates",
                "Jeff Bezos",
                "Mark Zuckerberg",
                "Tim Cook",
                "Satya Nadella"
            };

            // Generic collections
            List<int> primeNumbers = new List<int>()
            {
                1,
                2,
                3,
                5,
                7,
                11
            };

            Console.WriteLine("The following are prime numbers.");
            for (int i = 0; i < primeNumbers.Count; i++)
            {
                Console.WriteLine(primeNumbers[i]);
            }
            Console.WriteLine();

            HashSet<string> cities = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "Johor Bahru",
                "Seremban",
                "Kuala Lumpur",
                "Kota Kinabalu",
                "Kuching",
                "Melaka"
            };

            Console.Write("Is Kuching in our cities? ");
            Console.WriteLine(cities.Contains("kuching"));
            Console.WriteLine();

            Dictionary<string, DateTime> birthDates = new Dictionary<string, DateTime>()
            {
                {"Bill Gates", new DateTime(1955, 10, 28) },
                {"Steve Jobs", new DateTime(1955, 2, 24) },
                {"Mark Zuckerberg", new DateTime(1984, 5, 14) },
                {"Jeff Bezos", new DateTime(1964, 1, 12) }
            };

            foreach (string key in birthDates.Keys)
            {
                Console.WriteLine($"{key} was born in {birthDates[key]:dd-MMM-yyyy}");
            }
            Console.WriteLine();

            SortedList<int, string> numbers = new SortedList<int, string>()
            {
                {1, "One" },
                {10, "Ten" },
                {3, "Three" },
                {5, "Five" },
                {44, "Forty-four" },
                {29, "Twenty-nine" }
            };

            foreach(int number in numbers.Keys)
            {
                Console.WriteLine($"{number} is {numbers[number]}");
            }
            Console.WriteLine();

            SortedDictionary<string, string> livingThings = new SortedDictionary<string, string>()
            {
                { "Dog", "animal" },
                { "Cat", "animal" },
                { "Oak Tree", "plant" },
                { "Dolphin", "animal" },
                { "Orchid", "plant" },
                { "Corns", "plant" }
            };

            foreach(string key in livingThings.Keys)
            {
                Console.WriteLine($"{key} is a {livingThings[key]}");
            }
            Console.WriteLine();


            // Some collection functions
            List<int> primeLessThanTen = primeNumbers
                .Where(x => x <= 10)
                .ToList();

            List<Student> students = new List<Student>()
            {
                new Student(){ Name = "Ali", Age = 10 },
                new Student(){ Name = "Abu", Age = 20 },
                new Student(){ Name = "Lee", Age = 30 }
            };

            List<int> ages = students
                .Select(x => x.Age)
                .ToList();

            int primeGreaterThan20 = primeNumbers.FirstOrDefault(x => x >= 20);
            int primeGreaterThan30 = primeNumbers.FirstOrDefault(x => x >= 30);
            bool numberGreaterThan100 = numbers.Any(x => x.Key >= 100);

            // IEnumerable stacking
            var enumerable = students.Where(x => x.Age >= 20);
            var enumerable2 = enumerable.Select(x => x.Name);
            List<string> studentFilter = enumerable2.ToList();

            List<string> studentFilterShort = students
                .Where(x => x.Age >= 20)
                .Select(x => x.Name)
                .ToList();
                

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    internal class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
