namespace _03.ManyToManyRelation.Data
{
    public class StudentsCourses
    {
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}