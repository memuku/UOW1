using AutoMapper;
using UOWW.Core.Entities;
using UOWW.Service.DTO.PMS;

namespace UOWW.Service.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProjectDTO, Project>().ReverseMap();
        }
    }
}
