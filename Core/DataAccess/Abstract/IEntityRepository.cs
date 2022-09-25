using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}