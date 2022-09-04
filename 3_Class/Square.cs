using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class Square : Shape, IDescriptive
    {
        public double Length { get; set; }

        public Square(double length)
        {
            _name = "Square";
            Length = length;
        }

        public override double GetArea()
        {
            return Length * Length;
        }

        public override double GetPerimeter()
        {
            return Length * 4;
        }

        public string Description()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"This is a {_name}");
            stringBuilder.AppendLine($"Length of each sides: {Length} cm");
            stringBuilder.AppendLine($"Perimeter: {GetPerimeter()} cm");
            stringBuilder.AppendLine($"Area: {GetArea()} cm2");

            return stringBuilder.ToString();
        }
    }
}
