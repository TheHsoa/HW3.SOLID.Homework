using System;
using System.Collections.Generic;
using System.Linq;
using HomeWork.Infrastructure.Handler;
using HomeWork.Model;
using HomeWork.Validation;

namespace HomeWork.Data
{
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly List<TEntity> _storage = new List<TEntity>();
        protected readonly IHandler _exceptionHandler;

        public EntityRepository(IHandler exceptionHandler)
        {
            _exceptionHandler = exceptionHandler;
        }

        public virtual void Add(TEntity entity)
        {
            try
            {
                entity.ValidateEntityNotNull();
                _storage.Add(entity);
            }
            catch (Exception e)
            {
                _exceptionHandler.Handle(e);
            }
        }

        public void Remove(TEntity entity)
        {
            _storage.Remove(entity);
        }

        public TEntity GetById(long id)
        {
            try
            {
                return _storage.First(o => o.Id == id);
            }
            catch (Exception e)
            {
                _exceptionHandler.Handle(e);
            }
            return null;
        }

        public TEntity[] GetAll()
        {
            return _storage.ToArray();
        }
    }
}
