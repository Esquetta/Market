using Market.BL.Abstract;
using Market.Dal.Concrete.EF;
using Market.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BL.Concrete.EF
{
    public class CategoryManager : IManagerBase<Category, NorthwindDbContext>, ICategoryService
    {
    }
}
