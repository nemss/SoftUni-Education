namespace BashSoft.Contracts
{
    using BashSoft.DataStructures;
    using System.Collections.Generic;

    public interface IRequester
    {
        void GetStudentMarkInCourse(string courseName, string userName);

        void GetStudentsByCourse(string courseName);

        ISimpleOrderedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> cmp);

        ISimpleOrderedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> cmp);
    }
}