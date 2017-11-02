namespace _01.StudentSystem
{
    using _01.StudentSystem.Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            using (var db = new StudentSystemDbContext())
            {
                db.Database.Migrate();

                //SeedDate(db);
                //SeedLicenses(db);

                //PrintAllStudentsWithHomeworks(db);

                //PrintAllCoursesWithTheirResources(db);

                //PrintAllCoursesWithMoreThan5Resources(db);

                //PrintAllCoursesWithGivenDate(db);

                //PrintStudentsWithPrices(db);

                //PrintAllCoursesWithResourcesAndLicenses(db);

                //PrintStudentsAndCountOfCourses(db);
            }
        }

        private static void PrintStudentsAndCountOfCourses(StudentSystemDbContext db)
        {
            var result = db
                .Students
                .Where(s => s.Courses.Any())
                .Select(s => new
                {
                    s.Name,
                    Courses = s.Courses.Count,
                    Resources = s.Courses.Sum(c => c.Course.Resources.Count),
                    Licenses = s.Courses.Sum(l => l.Course.Resources.Sum(r => r.Licenses.Count))
                });

            foreach (var student in result)
            {
                Console.WriteLine($"--- Name {student.Name} ---");
                Console.WriteLine($"Courses   ---> {student.Courses}");
                Console.WriteLine($"Resources ---> {student.Resources}");
                Console.WriteLine($"Licenses  ---> {student.Licenses}");
                Console.WriteLine(new string('-', 20));
            }
        }

        private static void PrintAllCoursesWithResourcesAndLicenses(StudentSystemDbContext db)
        {
            var result = db
                .Courses
                .OrderByDescending(c => c.Resources.Count)
                .ThenBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    Resources = c
                        .Resources
                        .OrderByDescending(r => r.Licenses.Count)
                        .ThenBy(r => r.Name)
                        .Select(r => new
                        {
                            r.Name,
                            Licenses = r.Licenses.Select(l => l.Name)
                        })
                })
                .ToList();

            foreach (var cousrse in result)
            {
                Console.WriteLine($"{cousrse.Name}");

                foreach (var resource in cousrse.Resources)
                {
                    Console.WriteLine($"---> {resource.Name}");

                    foreach (var license in resource.Licenses)
                    {
                        Console.WriteLine($"-------> {license}");
                    }
                }
            }
        }

        private static void SeedLicenses(StudentSystemDbContext db)
        {
            var resourcesIds = db
                .Resources
                .Select(r => r.Id)
                .ToList();

            for (int i = 0; i < resourcesIds.Count; i++)
            {
                var random = new Random();
                var totalLicenses = random.Next(1, 4);

                for (int j = 0; j < totalLicenses; j++)
                {
                    db.Licenses.Add(new License
                    {
                        Name = $"Licenses {i}",
                        ResourceId = resourcesIds[i]
                    });
                }

                db.SaveChanges();
            }
        }

        private static void PrintStudentsWithPrices(StudentSystemDbContext db)
        {
            var result = db
                .Students
                .Where(s => s.Courses.Any())
                .Select(s => new
                {
                    s.Name,
                    Courses = s.Courses.Count,
                    TotalPrice = s.Courses.Sum(p => p.Course.Price),
                    AveragePrice = s.Courses.Average(p => p.Course.Price)
                })
                .OrderByDescending(c => c.TotalPrice)
                .ThenByDescending(c => c.Courses)
                .ThenBy(s => s.Name)
                .ToList();

            foreach (var student in result)
            {
                Console.WriteLine($"{student.Name} - {student.Courses} - {student.TotalPrice} - {student.AveragePrice}");
            }
        }

        private static void PrintAllCoursesWithGivenDate(StudentSystemDbContext db)
        {
            var date = DateTime.Now;

            var result = db
                .Courses
                .Where(c => c.StartDate < date && date < c.EndDate)
                .Select(c => new
                {
                    c.Name,
                    c.StartDate,
                    c.EndDate,
                    Duration = c.EndDate.Subtract(c.StartDate),
                    StudentsCount = c.Students.Count
                })
                .OrderByDescending(c => c.StudentsCount)
                .ThenByDescending(c => c.Duration)
                .ToList();

            foreach (var course in result)
            {
                Console.WriteLine($"{course.Name}: {course.StartDate.ToShortDateString()} - {course.EndDate.ToShortDateString()}");
                Console.WriteLine($"---> Duration{course.Duration.Days}");
                Console.WriteLine($"---> Students {course.StudentsCount}");
            }

        }

        private static void PrintAllCoursesWithMoreThan5Resources(StudentSystemDbContext db)
        {
            var result = db
                .Courses
                .Where(c => c.Resources.Count > 5)
                .OrderByDescending(c => c.Resources.Count)
                .ThenByDescending(c => c.StartDate)
                .Select(c => new
                {
                    c.Name,
                    ResourcesCount = c.Resources.Count
                })
                .ToList();

            foreach (var course in result)
            {
                Console.WriteLine($"{course.Name} ---> {course.ResourcesCount}");
            }
        }

        private static void PrintAllCoursesWithTheirResources(StudentSystemDbContext db)
        {
            var result = db
                .Courses
                .OrderBy(c => c.StartDate)
                .ThenByDescending(c => c.EndDate)
                .Select(c => new
                {
                    c.Name,
                    c.Description,
                    Resources = c.Resources.Select(r => new
                    {
                        r.Name,
                        r.URL,
                        r.Type
                    })

                })
                .ToList();

            foreach (var course in result)
            {
                Console.WriteLine($"{course.Name} - {course.Description}");

                foreach (var resource in course.Resources)
                {
                    Console.WriteLine($"---> {resource.Name} - {resource.URL} {resource.Type}");
                }
            }
        }

        private static void PrintAllStudentsWithHomeworks(StudentSystemDbContext db)
        {
            var result = db
                .Students
                .Select(s => new
                {
                    s.Name,
                    Homeworks = s.Homeworks.Select(h => new
                    {
                        h.Content,
                        h.Type
                    })
                })
                .ToList();

            foreach (var student in result)
            {
                Console.WriteLine($"-------- {student.Name}");

                foreach (var homework in student.Homeworks)
                {
                    Console.WriteLine($"---> {homework.Content} - {homework.Type}");
                }
            }
        }

        private static void SeedDate(StudentSystemDbContext db)
        {
            var currentDate = DateTime.Now;
            var totalStudents = 20;
            var totalCourses = 10;

            //Add students in database
            for (int i = 1; i < totalStudents; i++)
            {
                db.Add(new Student
                {
                    Name = $"Student {i}",
                    RegistrationDate = currentDate.AddDays(i),
                    Birthday = currentDate.AddYears(-20).AddDays(i),
                    Phone = $"Phone.... 0894{i}"
                });
            }

            db.SaveChanges();

            //Add courses in database
            var addedCourses = new List<Course>();

            for (int i = 0; i < totalCourses; i++)
            {
                var course = new Course
                {
                    Name = $"Course {i}",
                    Description = $"Course Details {i}",
                    Price = 100 * i,
                    StartDate = currentDate.AddDays(i),
                    EndDate = currentDate.AddDays(10 + i)
                };

                addedCourses.Add(course);
                db.Courses.Add(course);
            }

            db.SaveChanges();

            var random = new Random();

            var studentsIds = db
                .Students
                .Select(s => s.Id)
                .ToList();

            //Studens in Courses
            for (int i = 0; i < totalCourses; i++)
            {
                var currentCurse = addedCourses[i];
                var studentInCoourse = random.Next(2, totalStudents / 2);

                for (int j = 0; j < studentInCoourse; j++)
                {
                    var studentId = studentsIds[random.Next(0, studentsIds.Count)];

                    if (!currentCurse.Students.Any(s => s.StudentId == studentId))
                    {
                        currentCurse.Students.Add(new StudentCourse
                        {
                            StudentId = studentId
                        });
                    }
                    else
                    {
                        j--;
                    }
                }

                var resourcesInCourse = random.Next(2, 8);
                var types = new[] { 0, 1, 2, 999 };

                currentCurse.Resources.Add(new Resource
                {
                    Name = $"Resourses {i}",
                    URL = $"Url {i}",
                    Type = (ResourceType)(types[random.Next(0, types.Length)])
                });
            }

            db.SaveChanges();

            //Add homeworks in database
            for (int i = 0; i < totalCourses; i++)
            {
                var currentCourse = addedCourses[i];

                var studentInCourseIds = currentCourse
                    .Students
                    .Select(s => s.StudentId)
                    .ToList();

                for (int j = 0; j < studentInCourseIds.Count; j++)
                {
                    var totalHomeworks = random.Next(2, 5);

                    for (int k = 0; k < totalHomeworks; k++)
                    {
                        db.Homeworks.Add(new Homework
                        {
                            Content = $"Content Homework {i}",
                            SubmissionDate = currentDate.AddDays(-i),
                            Type = ContentType.Zip,
                            StudentId = studentInCourseIds[j],
                            CourseId = currentCourse.Id
                        });
                    }

                }

                db.SaveChanges();
            }
        }
    }
}