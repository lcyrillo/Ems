using CS.Ems.Application.Interfaces;
using CS.Ems.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS.Ems.Application.Services
{
    public class BaseAppService<TEntity> : IBaseAppService<TEntity> where TEntity : class
    {
        private readonly IBaseService<TEntity> _service;

        public BaseAppService(IBaseService<TEntity> service)
        {
            _service = service;
        }

        public void Add(TEntity entity)
        {
            _service.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _service.Delete(entity);
        }

        public IList<TEntity> GetAll()
        {
            return _service.GetAll();
        }

        public IList<TEntity> GetByDescrition(string description)
        {
            return _service.GetByDescrition(description);
        }

        public TEntity GetById(int id)
        {
            return _service.GetById(id);
        }

        public TEntity Update(int id, TEntity entity)
        {
            return _service.Update(id, entity);
        }
    }
}
