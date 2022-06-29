using Market.Dal.Abstract;
using Market.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Market.Dal.Concrete
{
    public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        public TContext context { get; set; }
        public RepositoryBase()
        {
            context = new TContext();
        }
        public void Add(TEntity tentity)
        {
            var addedEntity = context.Add(tentity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(TEntity tentity)
        {
            var deletedEntity = context.Remove(tentity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Update(TEntity tentity)
        {
            var updatedEntity = context.Update(tentity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return context.Set<TEntity>().FirstOrDefault(filter);
        }
        /// <summary>
        ///  Returns all values from database table for specified parameter,if parameter is null returns all.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>List of tentity with specified conditions</returns>
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="include">Those who have relations with tentity</param>
        /// <returns>reletated data included with specified conditions </returns>
        public IQueryable<TEntity> GetAllInclude(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] include)
        {
            var query = filter == null ? context.Set<TEntity>() : context.Set<TEntity>().Where(filter);
            return include.Aggregate(query,(current,includeProperty)=>current.Include(includeProperty));
        }
    }
}
