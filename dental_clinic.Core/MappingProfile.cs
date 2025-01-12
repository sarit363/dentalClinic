using AutoMapper;
using dental_clinic.Core.DTOs;
using dental_clinic.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace dental_clinic.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<dentist, dentistDto>().ReverseMap();
            CreateMap<patient, patientDto>().ReverseMap();
            CreateMap<turn, turnDto>().ReverseMap();
        }
    }
}
