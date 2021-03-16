using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileUploads;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        //ICarImageDal _carImageDal;

        //public CarImageManager(ICarImageDal carImageDal)
        //{
        //    _carImageDal = carImageDal;
        //}

        ////[SecuredOperation("product.add,admin")]
        //public IResult Add(CarImage entity)
        //{
        //    var result = BusinessRules.Run(
        //        CheckImageCount(entity.CarId)
        //        );
        //    if (true)
        //    {
        //        entity.Date = DateTime.Now;
        //        var addedCarImage = CreatedFile(entity).Data;
        //        _carImageDal.Add(entity);
        //        return new SuccessResult();
        //    }
        //    return new ErrorResult(result.Messages);

        //}
        //[SecuredOperation("product.delete,admin")]
        //public IResult Delete(int id)
        //{
        //    _carImageDal.DeleteImage(_carImageDal.Get(c => c.Id == id).ImagePath);
        //    _carImageDal.Delete(_carImageDal.Get(c => c.Id == id));
        //    return new SuccessResult(Messages.DeletedSuccess);
        //}

        //public IDataResult<List<CarImage>> GetAll()
        //{
        //    return new SuccessDataResults<List<CarImage>>(_carImageDal.GetAll(), Messages.ListedSuccess);
        //}

        //public IDataResult<CarImage> GetById(int id)
        //{
        //    return new SuccessDataResults<CarImage>(_carImageDal.Get(c => c.Id == id), Messages.ListedSuccess);
        //}

        //public IDataResult<List<CarImage>> GetCarImage(int carId)
        //{
        //    List<CarImage> result = _carImageDal.GetAll(c => c.CarId == carId);
        //    if (result.Count == 0)
        //    {
        //        DefaultCarImage(carId, result);
        //    }
        //    return new SuccessDataResults<List<CarImage>>(result, Messages.ListedSuccess);
        //}


        //[SecuredOperation("product.update,admin")]
        //public IResult Update(CarImage entity)
        //{
        //    _carImageDal.Update(entity);
        //    return new SuccessResult(Messages.UpdateSuccess);
        //}

        //private IResult CheckImageCount(int carId)
        //{
        //    var result = _carImageDal.GetAll(c => c.CarId == carId);
        //    if (result.Count >= 5)
        //    {
        //        return new ErrorResult(Messages.ImageCount);
        //    }
        //    return new SuccessResult();
        //}

        //private static void DefaultCarImage(int carId, List<CarImage> result)
        //{
        //    CarImage carImage = new CarImage();
        //    carImage.CarId = carId;
        //    const string path = @"C:\Users\Mert1\source\repos\ReCapProject\WebAPI\wwwroot\uploads\default.jpg";
        //    carImage.ImagePath = path;
        //    result.Add(carImage);
        //}
        //private IDataResult<CarImage> CreatedFile(CarImage carImage)
        //{
        //    string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Image");
        //    var uniqueFilename = Guid.NewGuid().ToString("N")
        //        + "CAR-" + carImage.CarId + "-" + DateTime.Now.ToShortDateString();

        //    string source = Path.Combine(carImage.ImagePath);

        //    string result = $@"{path}\{uniqueFilename}";

        //    try
        //    {

        //        File.Move(source, path + @"\" + uniqueFilename);
        //    }
        //    catch (Exception exception)
        //    {

        //        return new ErrorDataResults<CarImage>(exception.Message);
        //    }

        //    return new SuccessDataResults<CarImage>(new CarImage { Id = carImage.Id, CarId = carImage.CarId, ImagePath = result, Date = DateTime.Now }, "resim eklendi");
        //}
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResults<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId);

            if (result.Count > 0)
            {
                return new SuccessDataResults<List<CarImage>>(result);
            }

            List<CarImage> images = new List<CarImage>();
            images.Add(new CarImage() { CarId = 0, Id = 0, ImagePath = "/images/defaultCar.png" });

            return new SuccessDataResults<List<CarImage>>(images);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResults<CarImage>(_carImageDal.Get(i => i.Id == id));
        }

        public IResult Addd(IFormFile image, CarImage carImage)
        {
            
            var imageCount = _carImageDal.GetAll(c => c.CarId == carImage.CarId).Count;

            if (imageCount >= 5)
            {
                return new ErrorResult("One car must have 5 or less images");
            }
            carImage.Date = DateTime.Now;
            var imageResult = FileUpload.Upload(image);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Messages);
            }
            carImage.ImagePath = imageResult.Messages;
            _carImageDal.Add(carImage);
            return new SuccessResult("Car image added");
        }

        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.Id == carImage.Id);
            if (image == null)
            {
                return new ErrorResult("Image not found");
            }

            FileUpload.Delete(image.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult("Image was deleted successfully");
        }

        public IResult Update(IFormFile image, CarImage carImage)
        {
            var isImage = _carImageDal.Get(c => c.Id == carImage.Id);
            if (isImage == null)
            {
                return new ErrorResult("Image not found");
            }

            var updatedFile = FileUpload.Update(image, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Messages);
            }
            carImage.ImagePath = updatedFile.Messages;
            _carImageDal.Update(carImage);
            return new SuccessResult("Car image updated");

        }

        public IDataResult<List<CarImage>> GetCarImage(int carId)
        {
            List<CarImage> result = _carImageDal.GetAll(c => c.CarId == carId);
            return new SuccessDataResults<List<CarImage>>(result, Messages.ListedSuccess);
        }

        public IResult Add(CarImage entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(CarImage entity)
        {
            throw new NotImplementedException();
        }
    }
}
