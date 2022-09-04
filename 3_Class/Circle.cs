using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class Circle : Shape, IDescriptive
    {
        private double _diameter { get; set; }

        public double Diameter
        {
            get
            {
                return _diameter;
            }
        }

        public double Radius
        {
            get
            {
                return Diameter / 2;
            }
        }

        public Circle(double diameter)
        {
            _name = "Circle";
            _diameter = diameter;
        }

        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public string Description()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"This is a {_name}");
            stringBuilder.AppendLine($"Diamerter: {Diameter} cm, Radius: {Radius} cm");
            stringBuilder.AppendLine($"Perimeter: {GetPerimeter()} cm");
            stringBuilder.AppendLine($"Area: {GetArea()} cm2");

            return stringBuilder.ToString();
        }
    }
}
