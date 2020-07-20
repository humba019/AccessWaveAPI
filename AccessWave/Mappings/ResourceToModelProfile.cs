using AccessWave.Domain.Models;
using AccessWave.Resources;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessWave.Mappings
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveAccessResource, Access>();
            CreateMap<SaveControlResource, Control>();
            CreateMap<SaveEducationResource, Education>();
            CreateMap<SaveEmployeeResource, Employee>();
            CreateMap<SavePeriodResource, Period>();
            CreateMap<SaveRuleResource, Rule>();
            CreateMap<SaveStudentResource, Student>();
            CreateMap<SaveUserResource, User>();
        }
    }
}
