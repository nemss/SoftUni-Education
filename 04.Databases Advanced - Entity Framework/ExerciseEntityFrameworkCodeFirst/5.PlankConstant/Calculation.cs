namespace _5.PlankConstant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Calculation
    {
        static double constant = 6.62606896e-34;
        static double Pi = 3.14159;
        
         public static double PlanckConstant()
        {
            double result = (constant / (2 * (Pi)));
            return result;
        }
    }
}
