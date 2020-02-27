using CS.Ems.Application.Interfaces;
using CS.Ems.Domain.Entities;
using CS.Ems.Domain.Interfaces.Services;

namespace CS.Ems.Application.Services
{
    public class ModuleAppService : BaseAppService<Module>, IModuleAppService
    {
        public readonly IModuleService _service;

        public ModuleAppService(IModuleService service)
            : base(service)
        {
            _service = service;
        }
    }
}
