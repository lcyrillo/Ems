using AutoMapper;
using CS.Ems.Application.ViewModels;
using CS.Ems.Domain.Entities;

namespace CS.Ems.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<TechnicalProfileViewModel, TechnicalProfile>();
        }
    }
}
