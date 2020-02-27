using CS.Ems.Domain.Entities;
using CS.Ems.Domain.Interfaces.Repository;
using CS.Ems.Domain.Interfaces.Services;

namespace CS.Ems.Domain.Services
{
    public class ModuleService : BaseService<Module> , IModuleService
    {
        private readonly IModuleRepository _repository;

        public ModuleService(IModuleRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
