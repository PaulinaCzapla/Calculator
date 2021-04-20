using System;
using System.Collections.Generic;
using System.Text;

namespace calculator
{
    class Root : MathematicalOperation
    {
        public override double Calculate(double param1, double param2 = 2)
        {
            double result;

            if (param2 == 0)
            {
                result = 1;
            }
            else if (param2 == 2)
            {
                result = Math.Sqrt(param1);
            }
            else
            {
                result = Math.Pow(param1, 1 / param2);
            }

            return result;
        }
    }
}
