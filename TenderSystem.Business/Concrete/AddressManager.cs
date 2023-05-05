using System;
using System.Collections.Generic;
using System.Text;
using TenderSystem.Business.Abstract;
using TenderSystem.Core.Utilities.Results;
using TenderSystem.DataAccess.Abstract;
using TenderSystem.Entities.Concrete;

namespace TenderSystem.Business.Concrete
{
    public class AddressManager:IAddressService
    {
        private IAddressDal _addressDal;

        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public Result GetAll()
        {
            try
            {
                var data = _addressDal.GetList();
                return new SuccessResult(data, "Addresses listed.");
            }
            catch { }

            return new ErrorResult("Error: Addresses could not listed.");

        }

        public Result GetById(int addressId)
        {
            try
            {
                var data = _addressDal.Get(a => a.Id == addressId);
                if (data == null)
                {
                    return new ErrorResult("Error: Address not found.");
                }

                return new SuccessResult(data, "Address listed.");
            }
            catch { }

            return new ErrorResult("Error: Address could not listed.");

        }

        public Result GetByClientId(int clientId)
        {
            try
            {
                var data = _addressDal.Get(c => c.Id == clientId);
                if (data==null)
                {
                    return new ErrorResult("Error: There is no addresses registered to this client Id.");
                }

                return new SuccessResult(data, "Addresses listed by client Id.");
            }
            catch { }

            return new ErrorResult("Error: Addresses could not listed.");
        }

        public Result Add(Address address)
        {
            try
            { 
                _addressDal.Add(address);
                return new SuccessResult("Address added.");

            }
            catch { }

            return new ErrorResult("Error: Address could not added.");
        }

        public Result Update(Address address)
        {
            try
            {
                _addressDal.Update(address);
                return new SuccessResult("Address updated.");
            }
            catch { }

            return new ErrorResult("Error: Address could not updated.");
        }

        public Result Delete(int addressId)
        {
            try
            {
                var data = _addressDal.Get(a => a.Id == addressId);
                if (data==null)
                {
                    return new ErrorResult("Error: This address Id could not found.");
                }
                _addressDal.Delete(data);
                return new SuccessResult("Address deleted.");
            }
            catch { }

            return new ErrorResult("Error: Address could not deleted.");
        }
    }
}
