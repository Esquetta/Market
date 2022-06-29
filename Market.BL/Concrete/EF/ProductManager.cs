using Market.BL.Abstract;
using Market.Dal.Abstract.EF;
using Market.Dal.Concrete.EF;
using Market.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Market.BL.Concrete.EF
{
    public class ProductManager : IManagerBase<Product, NorthwindDbContext>, IProductService
    {
        private IProductDal productDal;
        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        public List<Product> GetAllProductsWithCategories(Expression<Func<Product, bool>> filter = null)
        {
            return productDal.GetAllInclude(filter,x=>x.Category).ToList();
        }

        public Product GetProductWithCategory(Expression<Func<Product, bool>> filter = null)
        {
            return productDal.GetAllInclude(filter, x => x.Category).FirstOrDefault();
        }
    }
}
