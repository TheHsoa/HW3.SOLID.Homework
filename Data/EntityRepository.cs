using System;
using System.Collections.Generic;
using System.Linq;
using HomeWork.Infrastructure.Handler;
using HomeWork.Model;

namespace HomeWork.Data
{
    internal class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly List<TEntity> storage = new List<TEntity>();
        private readonly IHandler exceptionHandler;

        public EntityRepository(IHandler exceptionHandler)
        {
            this.exceptionHandler = exceptionHandler;
        }

        public void Add(TEntity contact)
        {
            try
            {
                storage.Add(contact);
            }
            catch (Exception e)
            {
                exceptionHandler.Handle(e);
            }
        }

        public void Remove(TEntity contact)
        {
            storage.Remove(contact);
        }

        public TEntity GetById(long id)
        {
            try
            {
                return storage.First(o => o.Id == id);
            }
            catch (Exception e)
            {
                exceptionHandler.Handle(e);
            }
            return null;
        }

        public TEntity[] GetAll()
        {
            return storage.ToArray();
        }
    }
}
