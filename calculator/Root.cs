using System;
using System.Collections.Generic;
using System.Text;

namespace calculator
{
    class Root : MathematicalOperation
    {
        public override string Calculate(double param1, double param2 = 2)
        {
            string result;
            if (ValidatePositiveNum(param1))
            {
                if (param2 == 0)
                {
                    result = 1.ToString();
                }
                else if (param2 == 2)
                {
                    result = Math.Sqrt(param1).ToString();
                }
                else
                {
                    result = Math.Pow(param1, 1 / param2).ToString();
                }
            }
            else
            {
                result = "error";
            }
            return result;
        }
    }
}
