using System;
using System.Collections.Generic;
using System.Text;

namespace calculator
{
    class Multiplication : MathematicalOperation
    {
        public override double Calculate(double param1, double param2)
        {
            return param1 * param2;
        }

        public override string[] Parse(string currentOperationText)
        {
            string [] elements= currentOperationText.Split('*');

            if (!ValidateNumber(elements[0]) || !ValidateNumber(elements[1]))
            {
                elements[0] = "error";
            }

            return elements;
        }
    }
}
