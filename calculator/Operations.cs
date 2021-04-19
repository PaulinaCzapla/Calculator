using System;
using System.Collections.Generic;
using System.Text;

namespace calculator
{
    class Operations
    {
        public Subtraction subtraction;
        public Addition addition;
        public Multiplication multiplication;
        public Division division;
        public Root root;
        public Power power;

        public Operations()
        {
            subtraction = new Subtraction();
            addition = new Addition();
            multiplication = new Multiplication();
            division = new Division();
            root = new Root();
            power = new Power();
        }
    }
}
