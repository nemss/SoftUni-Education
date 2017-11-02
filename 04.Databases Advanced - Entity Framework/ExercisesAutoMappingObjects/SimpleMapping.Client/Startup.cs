namespace SimpleMapping.Client
{
    using AutoMapper;
    using Data;
    using DTO;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Startup
    {
        static void Main(string[] args)
        {
            SimpleMappingContext context = new SimpleMappingContext();
            //context.Database.Initialize(true);

            MapperConfig.Init();
            var employee = context.Employees.FirstOrDefault(e => e.FirstName == "Pesho");
            var employeeDto = Mapper.Map<Employee, EmployeeDto>(employee);

            Console.WriteLine($"{employeeDto.FirstName} {employeeDto.LastName} {employeeDto.Salary}");
        }
    }
}
