using AutoMapper;
using dental_clinic.entities;
using dental_clinic.Models;

namespace dental_clinic
{
    public class MappingPostModel : Profile
    {
        public MappingPostModel() 
        {
            CreateMap<dentistPostModels, dentist>().ReverseMap();
            CreateMap<patientPostModels, patient>().ReverseMap();
            CreateMap<turnPostModels, dentist>().ReverseMap();
        }
    }
}
