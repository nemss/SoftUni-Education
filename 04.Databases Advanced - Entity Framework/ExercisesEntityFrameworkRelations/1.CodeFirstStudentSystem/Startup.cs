namespace CodeFirstStudentSystem
{
    using _1.CodeFirstStudentSystem;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.SqlServer;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Program
    {
        static void Main()
        {
            StudentSystemContext context = new StudentSystemContext();
            //context.Database.Initialize(true);

            AllStudentHomeworkSubmissions(context);
            Console.WriteLine(new string('-', 30));

            AllCoursesWithTheirCorrespondingResources(context);
            Console.WriteLine(new string('-', 30));

            AllCoursesWithMoreThan5Resorces(context);
            Console.WriteLine(new string('-', 30));

            AllCoursesWhichWereActiveOnGivenDate(context, DateTime.Today);
            Console.WriteLine(new string('-', 30));

            AllStudentInformation(context);
            Console.WriteLine(new string('-', 30));

        }

        private static void AllStudentInformation(StudentSystemContext context)
        {
            var students = context.Students
                .OrderByDescending(s => s.Courses.Sum(c => c.Price))
                .ThenByDescending(s => s.Courses.Count)
                .ThenBy(c => c.Name);

            foreach (var s in students)
            {
                if (s.Courses.Count != 0)
                {
                    Console.WriteLine($"{s.Name} - {s.Courses.Count} - {s.Courses.Sum(c => c.Price)} - {s.Courses.Average(c => c.Price)}");
                }
            }
        }

        private static void AllCoursesWhichWereActiveOnGivenDate(StudentSystemContext context, DateTime activeDate)
        {
            var courses = context.Courses
                .Where(c => c.StartDate <= activeDate && c.EndDate >= activeDate)
                .Select(c => new
                {
                    c.Name,
                    c.StartDate,
                    c.EndDate,
                    Duration = SqlFunctions.DateDiff("DAY", c.StartDate, c.EndDate),
                    StudentsCount = c.Students.Count
                });

            foreach (var c in courses.OrderByDescending(c => c.StudentsCount).ThenByDescending(c => c.Duration))
            {
                Console.WriteLine($"{c.Name} - {c.StartDate} - {c.EndDate} - {c.Duration} - {c.StudentsCount}");
            }
        }

        private static void AllCoursesWithMoreThan5Resorces(StudentSystemContext context)
        {
            var courses = context.Courses
                .Where(c => c.Resources.Count() > 5)
                .OrderByDescending(c => c.Resources.Count())
                .ThenByDescending(c => c.StartDate);

            foreach (var c in courses)
            {
                Console.WriteLine($"{c.Name} - {c.Resources.Count()}");
            }
        }

        private static void AllCoursesWithTheirCorrespondingResources(StudentSystemContext context)
        {
            var allCourses = context.Courses
                .OrderBy(c => c.StartDate)
                .ThenBy(c => c.EndDate);

            foreach (var c in allCourses)
            {
                Console.WriteLine($"{c.Name} - {c.Description}");

                foreach (var r in c.Resources)
                {
                    Console.WriteLine($"{r.Name} - {r.Type} - {r.Url}");
                }
            }
        }

        private static void AllStudentHomeworkSubmissions(StudentSystemContext context)
        {
            var allStudent = context.Students;

            foreach (var s in allStudent)
            {
                Console.WriteLine($"{s.Name}");
                foreach (var c in s.Homeworks)
                {
                    Console.WriteLine($"{c.Content} - {c.Type}");
                }
            }
        }
    }
}
