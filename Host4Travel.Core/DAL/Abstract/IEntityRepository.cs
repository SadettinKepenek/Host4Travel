using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.Core.EntityLayer.Abstract;

namespace Host4Travel.Core.DataAccessLayer.Abstract
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        T Get(Expression<Func<T,bool>> filter=null);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}