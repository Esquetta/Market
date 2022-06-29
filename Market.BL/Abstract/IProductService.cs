using Market.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Market.BL.Abstract
{
    public interface IProductService:IServiceBase<Product>
    {
        Product GetProductWithCategory(Expression<Func<Product,bool>>filter=null);
        List<Product> GetAllProductsWithCategories(Expression<Func<Product, bool>> filter = null);
    }
}
