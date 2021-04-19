using System;
using System.Collections.Generic;
using System.Text;

namespace calculator
{
    class Power : MathematicalOperation
    {
        public override string Calculate(double param1, double param2)
        {
            return System.Math.Pow(param1, param2).ToString();
        }
    }
}
