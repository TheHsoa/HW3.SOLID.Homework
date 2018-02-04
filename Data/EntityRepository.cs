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
        protected readonly List<TEntity> Storage = new List<TEntity>();
        protected readonly IExceptionHandler ExceptionHandler;

        public EntityRepository(IExceptionHandler exceptionHandler)
        {
            ExceptionHandler = exceptionHandler;
        }

        public virtual void Add(TEntity entity)
        {
            try
            {
                entity.ValidateEntityNotNull();
                Storage.Add(entity);
            }
            catch (Exception e)
            {
                ExceptionHandler.Handle(e);
            }
        }

        public void Remove(TEntity entity)
        {
            Storage.Remove(entity);
        }

        public TEntity GetById(long id)
        {
            try
            {
                return Storage.First(o => o.Id == id);
            }
            catch (Exception e)
            {
                ExceptionHandler.Handle(e);
            }
            return null;
        }

        public TEntity[] GetAll()
        {
            return Storage.ToArray();
        }
    }
}
