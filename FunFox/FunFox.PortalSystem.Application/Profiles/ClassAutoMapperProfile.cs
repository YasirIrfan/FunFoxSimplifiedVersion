using AutoMapper;
using FunFox.PortalSystem.Domain.Entities;
using FunFox.PortalSystem.Domain.ViewModels.Class;
using FunFox.PortalSystem.Domain.ViewModels.Plant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunFox.PortalSystem.Application.Profiles
{
    public class ClassAutoMapperProfile : Profile
    {
        public ClassAutoMapperProfile()
        {
            //CreateMap<string, PlantCategoryViewModel>()
            //    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src));

            //CreateMap<AllPlant, PlantViewModel>()
            //    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.ImportedOn == default ? "Pending" : "Completed"));

            CreateMap<FunFoxClass, ClassViewModel>();

            CreateMap<string, ClassGradeLevelViewModel>()
                .ForMember(dest => dest.GradeLevel, opt => opt.MapFrom(src => src)); ;

        }
    }

}
