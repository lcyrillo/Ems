using AutoMapper;
using CS.Ems.Application.ViewModels;
using CS.Ems.Domain.Entities;

namespace CS.Ems.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<TechnicalProfile, TechnicalProfileViewModel>();
            CreateMap<Module, ModuleViewModel>();
        }
    }
}
