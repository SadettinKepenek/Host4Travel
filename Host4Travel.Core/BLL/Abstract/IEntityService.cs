using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.Core.BLL.Concrete;
using Host4Travel.Core.BLL.Concrete.EntityService;

namespace Host4Travel.Core.BLL.Abstract
{
    public interface IEntityService<T>
    {

        T Get(Expression<Func<T,bool>> filter=null);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        ResultModel Add(T entity);
        ResultModel Update(T entity);
        ResultModel Delete(T entity);
    }
}