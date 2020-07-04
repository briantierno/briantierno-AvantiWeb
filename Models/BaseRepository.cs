using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;


namespace Avanti_MVC.Models
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        internal AvantiTestEntities context;
        internal DbSet<TEntity> dbSet;

        public string PKName { get; set; }

        public BaseRepository()
            //: this(DataContextManager.Context)
            : this(DataContextManager.Context)
        {
        }

        public AvantiTestEntities GetContext()
        {
            return context;
        }

        public BaseRepository(AvantiTestEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetTable()
        {
            return dbSet;
        }

        public IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }

        public IQueryable<TEntity> GetPaged(IQueryable<TEntity> query, int skip, int count)
        {
            return query.Skip(skip * count).Take(count);
        }

        public virtual int Count(IQueryable<TEntity> query)
        {
            return query.Count();
        }
        
        public virtual IQueryable<TEntity> Get(
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
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void InsertAll(List<TEntity> entities)
        {
            foreach (var e in entities)
                dbSet.Add(e);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            dbSet.Remove(entityToDelete);
        }


        public virtual void ReloadObj(TEntity entity)
        {
            context.Entry(entity).Reload();
        }
        public virtual void DeleteAll(List<TEntity> entities)
        {
            foreach (var e in entities)
                dbSet.Remove(e);
        }

        public virtual void SubmitChanges()
        {
            context.SaveChanges();
        }
    }
}
