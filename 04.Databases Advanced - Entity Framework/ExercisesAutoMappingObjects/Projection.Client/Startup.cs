namespace Projection.Client
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using DTO;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Startup
    {
        static void Main(string[] args)
        {
            ProjectionContext context = new ProjectionContext();
            //context.Database.Initialize(true);

            MapperConfig.Init();

            var employees = context.Employees
                .Where(e => e.Birthday.Value.Year > 1990)
                .OrderByDescending(e => e.Salary)
                .ProjectTo<EmployeeDto>();

            foreach (EmployeeDto em in employees)
            {
                Console.WriteLine(em.ToString());
            }
        }
    }
}
