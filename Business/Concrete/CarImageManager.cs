using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }


        public IResult Add(CarImage entity)
        {
            var result = BusinessRules.Run(
                CheckImageCount(entity.CarId)
                );
            if (result.Success)
            {
                entity.Date = DateTime.Now;
                _carImageDal.Add(entity);
                return new SuccessResult();
            }
            return new ErrorResult(result.Messages);
            
        }
        public IResult Delete(int id)
        {
            _carImageDal.DeleteImage(_carImageDal.Get(c => c.Id == id).ImagePath);
            _carImageDal.Delete(_carImageDal.Get(c => c.Id == id));
            return new SuccessResult(Messages.DeletedSuccess);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResults<List<CarImage>>(_carImageDal.GetAll(), Messages.ListedSuccess);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResults<CarImage>(_carImageDal.Get(c => c.Id == id), Messages.ListedSuccess);
        }

        public IDataResult<List<CarImage>> GetCarImage(int carId)
        {
            List<CarImage> result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count == 0)
            {
                DefaultCarImage(carId, result);
            }
            return new SuccessDataResults<List<CarImage>>(result, Messages.ListedSuccess);
        }

        

        public IResult Update(CarImage entity)
        {
            _carImageDal.Update(entity);
            return new SuccessResult(Messages.UpdateSuccess);
        }

        private IResult CheckImageCount(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count >= 5)
            {
                return new ErrorResult(Messages.ImageCount);
            }
            return new SuccessResult();
        }

        private static void DefaultCarImage(int carId, List<CarImage> result)
        {
            CarImage carImage = new CarImage();
            carImage.CarId = carId;
            const string path = @"C:\Users\Mert1\source\repos\ReCapProject\WebAPI\wwwroot\uploads\default.jpg";
            carImage.ImagePath = path;
            result.Add(carImage);
        }
    }
}
