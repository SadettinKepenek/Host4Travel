﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Host4Travel.Core.DAL.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Host4Travel.Core.DAL.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity:class,new()
        where TContext:DbContext,new()
    {
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();
            return context.Set<TEntity>().SingleOrDefault(filter);
            
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using var context = new TContext();
            return filter==null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
        }

        public void Add(TEntity entity)
        {
            using var context = new TContext();
            var addedEntry = context.Entry(entity);
            addedEntry.State = EntityState.Added;
            // Unit of work design patern entity framework
            // Change Tracking
            
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            using var context = new TContext();
            var updatedEntry = context.Entry(entity);
            updatedEntry.State = EntityState.Modified;
            context.SaveChanges();

        }

        public void Delete(TEntity entity)
        {
            using var context = new TContext();
            var deletedEntry = context.Entry(entity);
            deletedEntry.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}