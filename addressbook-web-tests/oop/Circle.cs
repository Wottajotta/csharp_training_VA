using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    internal class Circle : Figure
    {
        private int radius;
        
        public Circle(int radius)
        {
            this.radius = radius;
        }

        public int Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }

    }
}
