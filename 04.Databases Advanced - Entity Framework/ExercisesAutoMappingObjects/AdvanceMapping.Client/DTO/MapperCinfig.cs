namespace AdvanceMapping.Client.DTO
{
    using AutoMapper;
    using Models;
    using System;
    class MapperCinfig
    {
        public static void Init()
        {
            Mapper.Initialize(cfg =>
            {
            cfg.CreateMap<Employee, EmployeeDto>();
                cfg.CreateMap<Employee, ManagerDto>()
                    .ForMember(d => d.EmployeesCount, opt => opt.MapFrom(src => src.Employees.Count));
        });
        }
    }
}
