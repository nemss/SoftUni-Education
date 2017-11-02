namespace SimpleMapping.Client.DTO
{
    using AutoMapper;
    using Models;
    using System;
    class MapperConfig
    {
        public static void Init()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDto>());
        }
    }
}
