﻿namespace LearningSystem.Service.Models.Course
{
    using System;

    public class CourseWithStudentInfo
    {
        public DateTime StartDate { get; set; }

        public bool UserIsEnrolled { get; set; }
    }
}