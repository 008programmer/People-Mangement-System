using AutoMapper;
using PMS.Dtos;
using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMS.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Person, PersonDto>();
            Mapper.CreateMap<PersonDto, Person>();
        }
    }
}