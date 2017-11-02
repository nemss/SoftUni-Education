namespace _1.CodeFirstStudentSystem
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("name=StudentSystemContext")
        {
        }
        public virtual IDbSet<Student> Students { get; set; }
        public virtual IDbSet<Course> Courses { get; set; }
        public virtual IDbSet<Homework> Homeworks { get; set; }
        public virtual IDbSet<Resource> Resources { get; set; }
        public virtual IDbSet<Licence> Licences { get; set; }
    }
}