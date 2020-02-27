using CS.Ems.Domain.Entities;
using CS.Ems.Domain.Interfaces.Repository;
using CS.Ems.Infrastructure.Data.Context;

namespace CS.Ems.Infrastructure.Data.Repositories
{
    public class TechnicalProfileRepository : BaseRepository<TechnicalProfile>, ITechnicalProfileRepository
    {
        public TechnicalProfileRepository(EmsContext context) : base(context)
        {

        }
    }
}
