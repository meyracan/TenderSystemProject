using System;
using System.Collections.Generic;
using System.Text;
using TenderSystem.Business.Abstract;
using TenderSystem.Core.Utilities.Results;
using TenderSystem.DataAccess.Abstract;
using TenderSystem.Entities.Concrete;

namespace TenderSystem.Business.Concrete
{
    public class TenderStatusManager:ITenderStatusService
    {
        private ITenderStatusDal _tenderStatusDal;

        public TenderStatusManager(ITenderStatusDal tenderStatusDal)
        {
            _tenderStatusDal = tenderStatusDal;
        }

        public Result GetAll()
        {
            try
            {
                var data = _tenderStatusDal.GetList();
                return new SuccessResult(data, "Tender Statuses listed.");
            }
            catch { }

            return new ErrorResult("Error: Tender Statuses could not listed.");
        }

        public Result GetById(int tenderStatusId)
        {
            try
            {
                var data = _tenderStatusDal.Get(a => a.Id == tenderStatusId);
                if (data == null)
                {
                    return new ErrorResult("Error: Tender Status not found.");
                }

                return new SuccessResult(data, "Tender Status listed.");
            }
            catch { }

            return new ErrorResult("Error: Tender Status could not listed.");
        }
    }
}
