namespace NinjectIoCContainer
{
    using NinjectIoCContainer.Contracts;
    using System.Collections.Generic;

    public class CourseData : ICourseData
    {
        public IEnumerable<string> CourseNames()
        {
            return new[] { "JS Applications", "High Quality Code" };
        }
    }
}