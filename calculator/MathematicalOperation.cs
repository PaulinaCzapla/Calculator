using System;
using System.Collections.Generic;
using System.Text;

namespace calculator
{
    abstract class MathematicalOperation : OperationError
    {
        public abstract string Calculate( double param1, double param2);
    }
}
