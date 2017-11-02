namespace Projection.Client.DTO
{
    using System;
    public class EmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public string ManagerName { get; set; }

        public override string ToString()
        {
            return $"        - {this.FirstName} {this.LastName} Manager: {this.ManagerName ?? "[no manager]"}";
        }
    }
}
