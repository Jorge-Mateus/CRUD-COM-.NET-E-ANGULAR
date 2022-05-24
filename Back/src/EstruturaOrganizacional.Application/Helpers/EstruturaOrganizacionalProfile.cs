using AutoMapper;
using EstruturaOrganizacional.Application.Dtos;
using EstruturaOrganizacional.Domain;

namespace EstruturaOrganizacional.API.Helpers
{
    public class EstruturaOrganizacionalProfile : Profile
    {
        public EstruturaOrganizacionalProfile()
        {
            CreateMap<BusinessArea, BusinessAreaDto>().ReverseMap();
            CreateMap<MarketArea, MarketAreaDtos>().ReverseMap();
            CreateMap<OperatingUnit, OperatingUnitsDtos>().ReverseMap();
            CreateMap<TechnologicalArea, TechnologicalAreaDtos>().ReverseMap();
            CreateMap<OrganizationalStructure, OrganizationalStructureDtos>().ReverseMap();
        }
    }
}