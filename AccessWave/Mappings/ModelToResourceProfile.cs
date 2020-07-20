using AccessWave.Domain.Models;
using AccessWave.Resources.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Mappings
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Access, AccessResource>();
            CreateMap<Control, ControlResource>();
            CreateMap<Education, EducationResource>();
            CreateMap<Employee, EmployeeResource>();
            CreateMap<Period, PeriodResource>();
            CreateMap<Rule, RuleResource>();
            CreateMap<Student, StudentResource>();
            CreateMap<User, UserResource>();
        }
    }
}
