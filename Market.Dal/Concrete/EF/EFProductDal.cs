using Market.Dal.Abstract.EF;
using Market.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Dal.Concrete.EF
{
    public class EFProductDal:RepositoryBase<Product,NorthwindDbContext>,IProductDal
    {
    }
}
