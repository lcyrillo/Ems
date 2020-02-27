using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Ems.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
        TEntity GetById(int id);
        IList<TEntity> GetByDescrition(string description);
        void Add(TEntity entity);
        TEntity Update(int id, TEntity entity);
        void Delete(TEntity entity);
    }
}
