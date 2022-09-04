using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = new Shape[]
            {
                new Square(2),
                new Triangle(5, 10),
                new Circle(5)
            };

            // Only can use functions from abstract class Shape.
            for (int i = 0; i < shapes.Length; i++)
            {
                Console.WriteLine($"This is a {shapes[i].Name}");
                Console.WriteLine($"Perimeter: {shapes[i].GetPerimeter()} cm");
                Console.WriteLine($"Area: {shapes[i].GetArea()} cm2");
                Console.WriteLine();
            }

            // Casting
            for (int i = 0; i < shapes.Length; i++)
            {
                Square square = shapes[i] as Square;

                if (square != null)
                {
                    Console.WriteLine($"Item No.{i + 1} is a {square.Name} with each sides equals to {square.Length}.");
                }

                try
                {
                    Square square2 = (Square)shapes[i];
                }

                catch(Exception ex)
                {
                    Console.WriteLine($"Trying to cast a {shapes[i].Name} to Square will throw a {ex.GetType().Name} exception.");
                }
            }

            Console.WriteLine();

            // Pattern matching
            for (int i = 0; i < shapes.Length; i++)
            {
                switch(shapes[i])
                {
                    case Square s:
                        Console.WriteLine($"This is a {s.Name} with length of each sides equals to {s.Length}cm.");
                        break;
                    case Triangle s:
                        Console.WriteLine($"This is a {s.Name} with height equals to {s.Height}cm and width equals to {s.Width}cm.");
                        break;
                    case Circle s:
                        Console.WriteLine($"This is a {s.Name} with diameter equals to {s.Diameter}cm.");
                        break;
                    default:
                        Console.WriteLine($"This is a {shapes[i].Name}.");
                        break;
                }
            }

            Console.WriteLine();

            // Interfaces
            IDescriptive[] descriptives = new IDescriptive[]
            {
                new Square(3),
                new Triangle(3, 4),
                new Circle(7)
            };

            for (int i = 0; i < descriptives.Length; i++)
            {
                PrintDescription(descriptives[i]);
            }

            Console.WriteLine();

            // Function passing
            for (int i = 0; i < shapes.Length; i++)
            {
                switch (shapes[i])
                {
                    case Square s:
                        PrintDescription(s);
                        break;
                    case Triangle s:
                        PrintDescription(s);
                        break;
                    case Circle s:
                        PrintDescription(s);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void PrintDescription(IDescriptive descriptive)
        {
            Console.WriteLine(descriptive.Description());
        }
    }
}
