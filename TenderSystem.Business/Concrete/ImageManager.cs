using System;
using System.Collections.Generic;
using System.Text;
using TenderSystem.Business.Abstract;
using TenderSystem.Core.Utilities.Results;
using TenderSystem.DataAccess.Abstract;
using TenderSystem.Entities.Concrete;

namespace TenderSystem.Business.Concrete
{
    public class ImageManager:IImageService
    {
        private IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public Result GetAll()
        {
            try
            {
                var data = _imageDal.GetList();
                return new SuccessResult(data, "Images listed.");
            }
            catch { }

            return new ErrorResult("Error: Images could not listed.");
        }

        public Result GetById(int imageId)
        {
            try
            {
                var data = _imageDal.Get(a => a.Id == imageId);
                if (data == null)
                {
                    return new ErrorResult("Error: Image not found.");
                }

                return new SuccessResult(data, "Image listed.");
            }
            catch { }

            return new ErrorResult("Error: Image could not listed.");
        }

        public Result GetByTenderId(int tenderId)
        {
            try
            {
                var data = _imageDal.GetList(b => b.TenderId == tenderId);
                if (data == null)
                {
                    return new ErrorResult("There are no images registered to this tender Id");
                }

                return new SuccessResult(data, "Images listed.");
            }
            catch { }

            return new ErrorResult("Error: Images could not listed.");
        }
        public Result Add(Image image)
        {
            try
            {
                _imageDal.Add(image);
                return new SuccessResult("Image added.");
            }
            catch { }

            return new ErrorResult("Error: Image could not added.");
        }

        public Result Update(Image image)
        {
            try
            {
                _imageDal.Update(image);
                return new SuccessResult("Image updated.");
            }
            catch { }

            return new ErrorResult("Error: Bid could not updated.");
        }

        public Result Delete(int imageId)
        {
            try
            {
                var data = _imageDal.Get(a => a.Id == imageId);
                if (data == null)
                {
                    return new ErrorResult("Error: This image Id could not found.");
                }
                _imageDal.Delete(data);
                return new SuccessResult("Image deleted.");
            }
            catch { }

            return new ErrorResult("Error: Image could not deleted.");
        }
    
    }
}
