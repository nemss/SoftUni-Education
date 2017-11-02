namespace AdvanceMapping.Client.DTO
{
    using Models;
    using System;
    using System.Collections.Generic;

    class ManagerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeesCount { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
