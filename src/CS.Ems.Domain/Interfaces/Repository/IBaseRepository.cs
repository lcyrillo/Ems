using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Ems.Domain.Interfaces.Repository
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        IList<TEntity> GetAll();
        TEntity GetById(int id);
        IList<TEntity> GetByDescription(string description);
        void Add(TEntity entity);
        TEntity Update(int id, TEntity entity);
        void Delete(TEntity entity);
    }
}
