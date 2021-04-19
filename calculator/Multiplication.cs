using System;
using System.Collections.Generic;
using System.Text;

namespace calculator
{
    class Multiplication : MathematicalOperation
    {
        public override string Calculate(double param1, double param2)
        {
            return (param1 * param2).ToString();
        }
    }
}
