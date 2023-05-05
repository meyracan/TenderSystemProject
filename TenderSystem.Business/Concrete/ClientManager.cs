using System;
using System.Collections.Generic;
using System.Text;
using TenderSystem.Business.Abstract;
using TenderSystem.Core.Utilities.Results;
using TenderSystem.DataAccess.Abstract;
using TenderSystem.Entities.Concrete;

namespace TenderSystem.Business.Concrete
{
    public class ClientManager:IClientService
    {
        private IClientDal _clientDal;

        public ClientManager(IClientDal clientDal)
        {
            _clientDal = clientDal;
        }

        public Result GetAll()
        {
            try
            {
                var data = _clientDal.GetList();
                return new SuccessResult(data, "Clients listed.");
            }
            catch { }

            return new ErrorResult("Error: Clients could not listed.");
        }

        public Result GetById(int clientId)
        {
            try
            {
                var data = _clientDal.Get(c => c.UserId == clientId);
                if (data == null)
                {
                    return new ErrorResult("Client Id could not found.");
                }

                return new SuccessResult(data, "Client listed.");
            }
            catch { }

            return new ErrorResult("Error: Client could not listed.");
        }

        public Result GetByUserName(string userName)
        {
            try
            {
                var data = _clientDal.Get(c => c.UserName == userName);
                if (data == null)
                {
                    return new ErrorResult("User name could not found.");
                }

                return new SuccessResult(data, "User name listed.");
            }
            catch { }

            return new ErrorResult("Error: User name could not listed.");

        }


        public Result Add(Client client)
        {
            try
            {
                var data = _clientDal.Get(c => c.Email == client.Email);
                if (data != null)
                {
                    return new ErrorResult("Email is already in use!");
                }

                data = _clientDal.Get(c => c.IdentityNumber == client.IdentityNumber);
                if (data != null)
                {
                    return new ErrorResult("Identity number is already in use!");
                }

                data = _clientDal.Get(c => c.UserName == client.UserName);
                if (data != null)
                {
                    return new ErrorResult("User name is already in use!");
                }

                _clientDal.Add(client);
                return new SuccessResult("Client added.");
            }
            catch { }

            return new ErrorResult("Error: Client could not added.");
        }

        public Result Update(Client client)
        {
            try
            {
                var data = _clientDal.Get(c => c.Email == client.Email);
                if (data != null)
                {
                    return new ErrorResult("Email is already in use!");
                }

                data = _clientDal.Get(c => c.IdentityNumber == client.IdentityNumber);
                if (data != null)
                {
                    return new ErrorResult("Identity number is already in use!");
                }

                data = _clientDal.Get(c => c.UserName == client.UserName);
                if (data != null)
                {
                    return new ErrorResult("User name is already in use!");
                }

                _clientDal.Update(client);
                return new SuccessResult("Client updated.");
            }
            catch { }

            return new ErrorResult("Error: Client could not updated.");
        }

        public Result Delete(int clientId)
        {
            try
            {
                var data = _clientDal.Get(a => a.UserId == clientId);
                if (data == null)
                {
                    return new ErrorResult("Error: This client Id could not found.");
                }
                _clientDal.Delete(data);
                return new SuccessResult("Client deleted.");
            }
            catch { }

            return new ErrorResult("Error: Client could not deleted.");
        }
    }
}
