using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace InfinityTask.DAL
{
    public class GenericRepository<TEntity> where TEntity: class 
    {
        internal MyContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(MyContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public virtual TEntity GetOne(
            Expression<Func<TEntity, bool>> filter = null)
        {
            return dbSet.Where(filter).FirstOrDefault();
        }

        public virtual int GetCount(
            Expression<Func<TEntity, bool>> filter = null)
        {
            return dbSet.Count(filter); 
        }
    }
}