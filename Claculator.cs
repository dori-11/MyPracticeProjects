using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Calculator
{
    internal class Claculator
    {
        public double Calculate(double num1, double num2, string op)
        {
            double result = 0;

            switch (op)
            {
                case "+" : result = num1 + num2; break;
                case "-" : result = num1 - num2; break;
                case "*" : result = num1 * num2; break;
                case "/" :
                    if (num2 != 0) result = num1 / num2;
                    else result = 0;
                    break;
            }
            return result;
        }
    }
}
