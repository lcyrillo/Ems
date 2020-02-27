using CS.Ems.Application.Interfaces;
using CS.Ems.Domain.Entities;
using CS.Ems.Domain.Interfaces.Services;

namespace CS.Ems.Application.Services
{
    public class TechnicalProfileAppService : BaseAppService<TechnicalProfile>, ITechnicalProfileAppService
    {
        private readonly ITechnicalProfileService _service;

        public TechnicalProfileAppService(ITechnicalProfileService service) 
            : base(service)
        {
            _service = service;
        }
    }
}
