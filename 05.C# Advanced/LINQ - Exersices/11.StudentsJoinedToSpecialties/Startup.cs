using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace _11.StudentsJoinedToSpecialties
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var specialities = GetSpecialities();
            var students = GetStudents();

            var resultJoin = students.Join(specialities,
                st => st.FacNum,
                sp => sp.FacNum,
                (st, sp) => new
                {
                    Name = st.Name,
                    Faculty = st.FacNum,
                    Speciality = sp.Name
                });

            Console.WriteLine(string.Join(Environment.NewLine, resultJoin
                .OrderBy(st => st.Name)
                .Select(st => $"{st.Name} {st.Faculty} {st.Speciality}")));

        }

        private static List<Student> GetStudents()
        {
            var students = new List<Student>();
            var input = Console.ReadLine().Trim();

            while (input != "END")
            {
                var indexOfFirstSpace = input.IndexOf(' ');

                if (indexOfFirstSpace > 0)
                {
                    students.Add(new Student
                    {
                        Name = input.Substring(indexOfFirstSpace + 1).Trim(),
                        FacNum = input.Substring(0, indexOfFirstSpace).Trim()
                    });
                }

                input = Console.ReadLine().Trim();
            }

            return students;
        }

        private static List<StudentSpecialty> GetSpecialities()
        {
            var specialities = new List<StudentSpecialty>();
            var input = Console.ReadLine().Trim();

            while (input != "Students:")
            {
                var indexOfLastSpace = input.LastIndexOf(' ');

                if (indexOfLastSpace > 0)
                {
                    specialities.Add(new StudentSpecialty
                    {
                        Name = input.Substring(0, indexOfLastSpace).Trim(),
                        FacNum = input.Substring(indexOfLastSpace + 1).Trim()
                    });
                }

                input = Console.ReadLine().Trim();
            }

            return specialities;
        }

        public class Student
        {
            public string Name { get; set; }

            public string FacNum { get; set; }
        }
        public class StudentSpecialty
        {
            public string Name { get; set; }

            public string FacNum { get; set; }
        }

    }
}
