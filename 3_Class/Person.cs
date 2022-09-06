using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class Person
    {
        private int _age { get; set; }
        public int Age
        {
            get
            {
                return _age;
            }
        }

        private DateTime _dateOfBirth { get; set; }

        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }

            set
            {
                _age = DateTime.Today.Year - _dateOfBirth.Year;
                _dateOfBirth = value;
            }
        }
    }
}
