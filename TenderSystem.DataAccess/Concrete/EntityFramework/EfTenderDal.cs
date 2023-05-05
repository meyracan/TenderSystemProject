using System.Collections.Generic;
using System.Linq;
using TenderSystem.Core.DataAccess.EntityFramework;
using TenderSystem.DataAccess.Abstract;
using TenderSystem.Entities.Concrete;

namespace TenderSystem.DataAccess.Concrete.EntityFramework
{
    public class EfTenderDal : EfEntityRepositoryBase<Tender, TenderSystemDatabaseContext>, ITenderDal
    {
        public List<Tender> GetListByClientId(int clientId)
        {
            using (TenderSystemDatabaseContext context = new TenderSystemDatabaseContext())
            {
                var tendersList = (from b in context.Bids
                    join t in context.Tenders
                        on b.TenderId equals t.Id
                    where b.ClientId == clientId
                    select t).ToList();
                return tendersList;
            }
        }
    }
}