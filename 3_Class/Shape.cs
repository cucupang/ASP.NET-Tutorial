using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public abstract class Shape
    {
        protected string _name { get; set; }

        public string Name 
        {
            get
            {
                return _name;
            }
        }

        public abstract double GetArea();
        public abstract double GetPerimeter();
    }
}
