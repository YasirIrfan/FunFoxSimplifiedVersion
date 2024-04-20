using AutoMapper;
using FunFox.PortalSystem.Domain.Entities;
using FunFox.PortalSystem.Domain.ViewModels.Plant;

namespace FunFox.PortalSystem.Application.Profiles;

public class PlantAutoMapperProfile : Profile
{
    public PlantAutoMapperProfile()
    {
        CreateMap<string, PlantCategoryViewModel>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src));

        CreateMap<AllPlant, PlantViewModel>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.ImportedOn == default ? "Pending" : "Completed"));
    }
}