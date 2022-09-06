using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class Triangle : Shape, IDescriptive
    {
        private double _height { get; set; }
        private double _width { get; set; }

        public double Height
        {
            get 
            { 
                return _height; 
            }
        }

        public double Width
        {
            get
            {
                return _width;
            }
        }

        public Triangle(double width, double height)
        {
            _name = "Triangle";
            _height = height;
            _width = width;
        }

        public sealed override double GetArea()
        {
            return (Height * Width) / 2;
        }

        public override double GetPerimeter()
        {
            double edgeLength = Math.Sqrt(Math.Pow(_width / 2, 2) + Math.Pow(_height, 2));

            return _width + (edgeLength * 2);
        }

        public string Description()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"This is a {_name}");
            stringBuilder.AppendLine($"Height: {Height} cm, Width: {Width} cm");
            stringBuilder.AppendLine($"Perimeter: {GetPerimeter()} cm");
            stringBuilder.AppendLine($"Area: {GetArea()} cm2");

            return stringBuilder.ToString();
        }

        public virtual void Draw()
        {
            for (int h = 0; h < Height; h++)
            {
                if (Height <= 0)
                {
                    Console.WriteLine(new String('*', (int)Width));
                }

                else
                {
                    int width = (int)Width - 2 <= 0
                        ? 1
                        : (int)Width - 2;

                    Console.WriteLine(new String('*', width));
                }
            }
        }
    }
}
