using Microsoft.EntityFrameworkCore;
using NutriApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NutriApp.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class
    {
        protected DbSet<TEntity> DbSet;
        protected readonly NutriAppContext Db;
        public RepositoryBase(NutriAppContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
        public virtual void Add(TEntity obj)
        {
            Db.Add(obj);
        }

        public virtual void Update(TEntity obj)
        {
            Db.Update(obj);
        }

        public virtual void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
