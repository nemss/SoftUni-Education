using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.MathUtilities
{
    class MathUtil
    {
 
        public static double Sum(double firstDigit, double secondDigit)
        {
            double result = firstDigit + secondDigit;
            return result;
        }
        public static double Subtract(double firstDigit, double secondDigit)
        {
            double result = firstDigit - secondDigit;
            return result;
        }
        public static double Multiply(double firstDigit, double secondDigit)
        {
            double result = firstDigit * secondDigit;
            return result;
        }
        public static double Divide(double firstDigit, double secondDigit)
        {
            if (secondDigit > 0)
            {
                double result = firstDigit / secondDigit;
                return result;
            }
            return 0;
        }
        public static double Percentage(double totalNumber, double percentage)
        {
            return totalNumber * (percentage / 100); 
        }
    }
}
