namespace _1.CodeFirstStudentSystem.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_1.CodeFirstStudentSystem.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "_1.CodeFirstStudentSystem.StudentSystemContext";
        }

        protected override void Seed(_1.CodeFirstStudentSystem.StudentSystemContext context)
        {
            context.Courses.AddOrUpdate(c => c.Name,
                new Course()
                {
                    Name = "Database Advance - Entity Framework",
                    Description = "Entity Framework",
                    EndDate = new DateTime(2017, 4, 9),
                    Price = 48,
                    Homeworks = new List<Homework>()
                   {
                       new Homework()
                       {
                           Content = "Database",
                           Type = ContentType.application,
                           SubmissionDate = DateTime.Now,
                           Student = new Student()
                           {
                                Name = "Pesho",
                                RegistrationDate = DateTime.Today,
                                PhoneNumber = "092034354545"
                           }
                       },
                       new Homework()
                       {
                           Content = "DataBase-Advance",
                           Type = ContentType.zip,
                           SubmissionDate = DateTime.Today,
                            Student = new Student()
                            {
                                Name = "Gosho",
                                RegistrationDate = DateTime.Today,
                                PhoneNumber = "04495986865"
                            }
                       }
                       },
                    StartDate = DateTime.Today,
                    Students = new List<Student>()
                    {
                        new Student()
                        {
                            Name = "Valentin",
                            RegistrationDate = DateTime.Today,
                            PhoneNumber = "09895485544"
                        },
                        new Student()
                        {
                            Name = "Reni",
                            RegistrationDate = DateTime.Today,
                            PhoneNumber = "09955444355"
                        }
                    },
                    Resources = new List<Resource>()
                    {
                        new Resource()
                        {
                            Name = "internet",
                            Type = ResourceType.other,
                            Url = "gsdss"                           
                        },
                        new Resource()
                        {
                            Name = "DCCCS",
                            Type = ResourceType.documentl,
                            Url = "wwww.dcsdcdcvdv.com"
                        }
                    }
               
                });
        }
    }
}
