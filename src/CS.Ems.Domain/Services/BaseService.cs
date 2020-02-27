using CS.Ems.Domain.Interfaces.Repository;
using CS.Ems.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Ems.Domain.Services
{
    public class BaseService<TEntity> : IDisposable, IBaseService<TEntity> where TEntity : class
    {

        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public IList<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IList<TEntity> GetByDescrition(string description)
        {
            return _repository.GetByDescription(description);
        }

        public void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public TEntity Update(int id, TEntity entity)
        {
            return _repository.Update(id, entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
