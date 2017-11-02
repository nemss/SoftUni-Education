namespace AdvanceMapping.Client
{
    using Data;
    using DTO;
    using Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using AutoMapper;

    class Startup
    {
        static void Main(string[] args)
        {
            MapperCinfig.Init();

            AdvanceMappingContext context = new AdvanceMappingContext();
            //context.Database.Initialize(true);
            var employees = context.Employees;
            var managersDtos = AutoMapper.Mapper.Map<IEnumerable<Employee>, ManagerDto[]>(employees);

            foreach (var maneger in managersDtos)
            {
                Console.WriteLine($"{maneger.FirstName} {maneger.LastName} | Employees : {maneger.EmployeesCount}");

                foreach (var m in maneger.Employees)
                {
                    Console.WriteLine($"{m.FirstName} - {m.LastName}");
                }
            }
        }
    }
}
