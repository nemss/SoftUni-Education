﻿namespace NinjectIoCContainer
{
    using NinjectIoCContainer.Contracts;
    using System;
    using System.Collections.Generic;

    public class Courses
    {
        private ICourseData data;

        public Courses(ICourseData data)
        {
            this.data = data;
        }

        public void PrintAll()
        {
            var courses = this.data.CourseNames();
            this.Print(courses);
        }

        private void Print(IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}