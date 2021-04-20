using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace calculator
{
    class Validator
    {
        public bool ValidateNotZeroNum(string num)
        {
            if (num == "0")
            {
                return false;
            }
            return true;

        }

        public bool ValidatePositiveNum(string num)
        {
            if (num[0] == '-')
            {
                return false;
            }
            return true;
        }

        public bool ValidateNumber(string num)
        {
            if (num.Length >= 2)
            {
                if (num[0] == '0' && num[1] != ',' || (num[0] == '-' && num[1] == ','))
                {
                    return false;
                }
            }
            return true;

        }
    }
}
