namespace AdvanceMapping.Models
{
    using System;
    using System.Collections.Generic;

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public bool IsOnHoliday { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public Employee Manager { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
