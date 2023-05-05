using System.Linq;
using TenderSystem.Core.DataAccess.EntityFramework;
using TenderSystem.DataAccess.Abstract;
using TenderSystem.Entities.Concrete;

namespace TenderSystem.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, TenderSystemDatabaseContext>, ICategoryDal
    {
        //public Category GetByCategoryTitle(string categoryTitle)
        //{
        //    using (var context = new TenderSystemDatabaseContext())
        //    {
        //        return context.Set<Category>().SingleOrDefault()
        //    }
        //}
    }
}