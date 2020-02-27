using System.Collections.Generic;

namespace CS.Ems.Application.Interfaces
{
    public interface IBaseAppService<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
        TEntity GetById(int id);
        IList<TEntity> GetByDescrition(string description);
        void Add(TEntity entity);
        TEntity Update(int id, TEntity entity);
        void Delete(TEntity entity);
    }
}
