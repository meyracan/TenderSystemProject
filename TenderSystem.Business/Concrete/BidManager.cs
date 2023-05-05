using System;
using System.Collections.Generic;
using System.Text;
using TenderSystem.Business.Abstract;
using TenderSystem.Core.Utilities.Results;
using TenderSystem.DataAccess.Abstract;
using TenderSystem.Entities.Concrete;

namespace TenderSystem.Business.Concrete
{
    public class BidManager:IBidService
    {
        private IBidDal _bidDal;

        public BidManager(IBidDal bidDal)
        {
            _bidDal = bidDal;
        }

        public Result GetAll()
        {
            try
            {
                var data = _bidDal.GetList();
                return new SuccessResult(data, "Bids listed.");
            }
            catch { }

            return new ErrorResult("Error: Bids could not listed.");
        }

        public Result GetById(int bidId)
        {
            try
            {
                var data = _bidDal.Get(a => a.Id == bidId);
                if (data == null)
                {
                    return new ErrorResult("Error: Bid not found.");
                }

                return new SuccessResult(data, "Bid listed.");
            }
            catch { }

            return new ErrorResult("Error: Bid could not listed.");
        }

        public Result GetByTenderId(int tenderId)
        {
            try
            {
                var data = _bidDal.GetList(b => b.TenderId == tenderId);
                if (data ==null)
                {
                    return new ErrorResult("There are no bids registered to this tender Id");
                }

                return new SuccessResult(data, "Bids listed.");
            }
            catch { }

            return new ErrorResult("Error: Bids could not listed.");
        }

        public Result GetByClientId(int clientId)
        {
            try
            {
                var data = _bidDal.GetList(b => b.ClientId == clientId);
                if (data == null)
                {
                    return new ErrorResult("There are no bids registered to this client Id");
                }

                return new SuccessResult(data, "Bids listed.");
            }
            catch { }

            return new ErrorResult("Error: Bids could not listed.");

        }
        public Result Add(Bid bid)
        {
            try
            {
                _bidDal.Add(bid);
                return new SuccessResult("Bid added.");
            }
            catch { }

            return new ErrorResult("Error: Bid could not added.");
        }

        public Result Update(Bid bid)
        {
            try
            {
                _bidDal.Update(bid);
                return new SuccessResult("Bid updated.");
            }
            catch { }

            return new ErrorResult("Error: Bid could not updated.");
        }

        public Result Delete(int bidId)
        {
            try
            {
                var data = _bidDal.Get(a => a.Id == bidId);
                if (data == null)
                {
                    return new ErrorResult("Error: This bid Id could not found.");
                }
                _bidDal.Delete(data);
                return new SuccessResult("Bid deleted.");
            }
            catch { }

            return new ErrorResult("Error: Bid could not deleted.");
        }
    }
}
