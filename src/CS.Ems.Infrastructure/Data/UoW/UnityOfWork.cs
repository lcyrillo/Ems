using CS.Ems.Domain.Interfaces.UoW;
using CS.Ems.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Ems.Infrastructure.Data.UoW
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly EmsContext _context;

        public UnityOfWork(EmsContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
