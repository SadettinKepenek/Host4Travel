﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Host4Travel.Core.BLL.Concrete;

namespace Host4Travel.Core.BLL.Abstract
{
    public interface IEntityService<T>
    {

        T Get(Expression<Func<T,bool>> filter=null);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}