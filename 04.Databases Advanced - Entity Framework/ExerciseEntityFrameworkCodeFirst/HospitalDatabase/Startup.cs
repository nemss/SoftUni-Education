namespace HospitalDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Startup
    {
        static void Main()
        {
            HospitalContext context = new HospitalContext();
            context.Database.Initialize(true);
           
        }
    }
}
