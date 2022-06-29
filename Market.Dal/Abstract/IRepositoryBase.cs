using Market.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Market.Dal.Abstract
{
    public interface IRepositoryBase<Tentity> where Tentity : class, IEntity, new()
    {
        void Add(Tentity tentity);
        void Update(Tentity tentity);
        void Delete(Tentity tentity);
        Tentity Get(Expression<Func<Tentity, bool>> filter = null);
        List<Tentity> GetAll(Expression<Func<Tentity, bool>> filter = null);
        IQueryable<Tentity> GetAllInclude(Expression<Func<Tentity, bool>> filter = null, params Expression<Func<Tentity, object>>[] include);

    }
}
