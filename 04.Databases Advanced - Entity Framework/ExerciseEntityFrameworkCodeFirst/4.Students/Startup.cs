namespace _4.Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Startup
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while(!input.Equals("End"))
            {
                Student student = new Student(input);
                input = Console.ReadLine();
            }
            Console.WriteLine(Student.instance);
        }
    }
}
