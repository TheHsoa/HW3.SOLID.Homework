using System;

using HomeWork.Model;

namespace HomeWork.Validation
{
    public static class EntityValidators
    {
        public static void ValidateEntityNotNull<TEntity>(this TEntity entity) where TEntity : IEntity
        {
            if (entity == null)
            {
                throw new ArgumentNullException(typeof(TEntity).Name);
            }
        }
    }
}
