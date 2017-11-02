namespace DependencyInversionDatabaseAfter
{
    using DependencyInversionDatabaseAfter.Contracts;
    using System.Collections.Generic;

    public class CourseData : ICourseData
    {
        public IEnumerable<int> CourseIds()
        {
            // return course ids
            return null;
        }

        public IEnumerable<string> CourseNames()
        {
            // return course names
            return null;
        }

        public IEnumerable<string> Search(string substring)
        {
            // return found results
            return null;
        }

        public string GetCourseById(int id)
        {
            // return course by id
            return null;
        }
    }
}