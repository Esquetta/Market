using Market.BL.Abstract;
using Market.Dal.Abstract;
using Market.Dal.Concrete;
using Market.Dal.Concrete.EF;
using Market.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Market.BL.Concrete
{
    public class IManagerBase<Tentity, TContext> : IServiceBase<Tentity> where Tentity : class, IEntity, new() where TContext : DbContext, new()
    {

        private readonly IRepositoryBase<Tentity> repositoryBase;
        public IManagerBase()
        {
            repositoryBase = new RepositoryBase<Tentity, TContext>();
        }

        public void Add(Tentity entity)
        {
            repositoryBase.Add(entity);
        }

        public void Delete(Tentity entity)
        {
            repositoryBase.Delete(entity);
        }

        public Tentity Get(Expression<Func<Tentity, bool>> filter = null)
        {
            return repositoryBase.Get(filter);
        }

        public List<Tentity> GetAll(Expression<Func<Tentity, bool>> filter = null)
        {
            return repositoryBase.GetAll(filter);
        }

        public IQueryable<Tentity> GetAllInclude(Expression<Func<Tentity, bool>> filter = null, params Expression<Func<Tentity, object>>[] include)
        {
            return repositoryBase.GetAllInclude(filter, include);
        }

        public void Update(Tentity entity)
        {
            repositoryBase.Update(entity);
        }
    }
}
