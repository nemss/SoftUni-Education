namespace CreateUser
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
            UsersContext context = new UsersContext();
            context.Database.Initialize(true);
        }
    }
}
