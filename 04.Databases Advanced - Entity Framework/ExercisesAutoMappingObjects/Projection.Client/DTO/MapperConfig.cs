using AutoMapper;
using Projection.Data;
using Projection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projection.Client.DTO
{
    class MapperConfig
    {
        public static void Init()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Employee, EmployeeDto>()
            .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager.LastName)));
        }
    }
}
