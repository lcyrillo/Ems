using CS.Ems.Domain.Entities;
using CS.Ems.Domain.Interfaces.Repository;
using CS.Ems.Domain.Interfaces.Services;

namespace CS.Ems.Domain.Services
{
    public class TechnicalProfileService : BaseService<TechnicalProfile>, ITechnicalProfileService
    {
        private readonly ITechnicalProfileRepository _repository;

        public TechnicalProfileService(ITechnicalProfileRepository repository) 
            : base(repository)
        {
            _repository = repository;
        }
    }
}
