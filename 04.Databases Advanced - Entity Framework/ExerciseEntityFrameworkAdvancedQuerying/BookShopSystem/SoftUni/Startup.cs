namespace SoftUni
{
    using System;
    using Data;
    using System.Data.SqlClient;
    using System.Data;
    using ViewModels;
    using System.Linq;

    class Startup
    {
        static void Main()
        {
            SoftUniContext context = new SoftUniContext();

            //Exercise 17
            //CallaStoreProcedure(context);

            //Exercise 18
            //EmployeesMaximumSalaries(context);
        }

        private static void EmployeesMaximumSalaries(SoftUniContext context)
        {
            var departments = context.Departments
                .Join(context.Employees,
                (d => d.DepartmentID),
                (e => e.DepartmentID),
                (d, e) => new
                {
                    DepartmentName = d.Name,
                    EmployeeSalary = e.Department.Employees.Max(s => s.Salary)
                }
                )
                .GroupBy(d => new
                {
                    d.DepartmentName,
                    MaxSalary = d.EmployeeSalary
                })
                .Where(a => a.Key.MaxSalary < 30000 || a.Key.MaxSalary > 70000);


            foreach (var d in departments)
            {
                Console.WriteLine($"{d.Key.DepartmentName} - {d.Key.MaxSalary}");
            }  
        }
        private static void CallaStoreProcedure(SoftUniContext context)
        {
            // CREATE PROCEDURE usp_FindProjectByEmloyeeName(@firstName VARCHAR(MAX), @lastName VARCHAR(MAX))
            // AS
            // BEGIN
            //  SELECT p.Name, p.Description, p.StartDate FROM Employees AS e
            //  INNER JOIN EmployeesProjects AS ep
            //  ON e.EmployeeID = ep.EmployeeID
            //  INNER JOIN Projects AS p
            //  ON p.ProjectID = ep.ProjectID
            //  WHERE e.FirstName = @firstName AND e.LastName = @lastName
            //END

            Console.WriteLine("Please enter first and last name: ");
            string[] names = Console.ReadLine().Split(' ');

            SqlParameter firstName = new SqlParameter("@firstName", SqlDbType.VarChar);
            SqlParameter lastName = new SqlParameter("@lastName", SqlDbType.VarChar);
            firstName.Value = names[0];
            lastName.Value = names[1];

            var project =  context.Database.SqlQuery<ProjectViewModel>("EXEC dbo.usp_FindProjectByEmloyeeName @firstName, @lastName", firstName, lastName);

            foreach (ProjectViewModel p in project)
            {
                Console.WriteLine($"{p.Name} - {p.Description}, {p.StartDate}");
            }

        }
    }
}
