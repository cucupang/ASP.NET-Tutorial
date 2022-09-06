using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class EqualateralTriangle : Triangle
    {
        public EqualateralTriangle(double width, double height) 
            : base(width, height)
        {
        }

        // Not able to override due to sealed.
        //public override double GetArea()
        //{

        //}

        public override double GetPerimeter()
        {
            return Width * 3;
        }
    }
}
