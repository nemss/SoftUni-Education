using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.AverageGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersOfStudent = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < numbersOfStudent; i++)
            {
                string[] inputTokens = Console.ReadLine().Split();
                string studentName = inputTokens[0];

                List<double> grades = new List<double>();

                for (int j = 1; j < inputTokens.Length; j++)
                {
                    double grade = double.Parse(inputTokens[j]);
                    grades.Add(grade); 
                }

                Student student = new Student();
                student.Name = studentName;
                student.Grades = grades;

                students.Add(student);

                foreach (Student studen in students.Where(s => s.AverageGrade >= 5)
                    .OrderBy(s => s.Name).ThenByDescending(s => s.AverageGrade))
                {
                    Console.WriteLine("{0} -> {1:f2}",studen.Name, studen.AverageGrade);
                }
            }
           

           
        }
    }

    public class Student
    {
       public string Name { get; set;}
       public List<double> Grades { get; set;}

        public double AverageGrade
        {
            get { return Grades.Average(); }
        }
    }
}
