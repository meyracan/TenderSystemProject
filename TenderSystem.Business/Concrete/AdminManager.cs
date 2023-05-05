using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using TenderSystem.Business.Abstract;
using TenderSystem.Core.Utilities.Results;
using TenderSystem.DataAccess.Abstract;
using TenderSystem.Entities.Concrete;

namespace TenderSystem.Business.Concrete
{
    public class AdminManager:IAdminService
    {
        private IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }


        public Result GetAll()
        {
            try
            {
                var data = _adminDal.GetList();
                return new SuccessResult(data, "Admins listed.");
            }
            catch { }

            return new ErrorResult("Error: Admins could not listed.");
        }

        public Result GetById(int adminId)
        {
            try
            {
                var data = _adminDal.Get(a => a.UserId == adminId);
                if (data == null)
                {
                    return new ErrorResult("Error: Admin not found.");
                }

                return new SuccessResult(data, "Admin listed.");
            }
            catch { }

            return new ErrorResult("Error: Admin could not listed.");
        }

        public Result Add(Admin admin)
        {
            try
            {
                var data = _adminDal.Get(c => c.Email == admin.Email);
                if (data != null)
                {
                    return new ErrorResult("Email is already in use!");
                }

                data = _adminDal.Get(c => c.IdentityNumber == admin.IdentityNumber);
                if (data != null)
                {
                    return new ErrorResult("Identity number is already in use!");
                }

                _adminDal.Add(data);
                return new SuccessResult("Admin added.");
            }
            catch { }

            return new ErrorResult("Error: Admin could not added.");
        }

        public Result Update(Admin admin)
        {
            try
            {
                var data = _adminDal.Get(c => c.Email == admin.Email);
                if (data != null)
                {
                    return new ErrorResult("Email is already in use!");
                }

                data = _adminDal.Get(c => c.IdentityNumber == admin.IdentityNumber);
                if (data != null)
                {
                    return new ErrorResult("Identity number is already in use!");
                }

                _adminDal.Update(admin);
                return new SuccessResult("Admin updated.");
            }
            catch { }

            return new ErrorResult("Error: Admin could not updated.");
        }

        public Result Delete(int adminId)
        {
            try
            {
                var data = _adminDal.Get(a => a.UserId == adminId);
                if (data == null)
                {
                    return new ErrorResult("Error: This admin Id could not found.");
                }
                _adminDal.Delete(data);
                return new SuccessResult("Admin deleted.");
            }
            catch { }

            return new ErrorResult("Error: Admin could not deleted.");
        }
    }
}
