using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if(car.Description.Length > 2 &&  car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult("Başarı ile Eklendi.");
            }
            else
            {
                return new ErrorResult("Araba model ismi 3 karakterden küçük veya araba günlük fiyatı 0 dan büyük değil");
            }
            
        }

        public IResult Delete(int id)
        {
            _carDal.Delete(_carDal.Get(c => c.Id == id));
            return new SuccessResult(Messages.AddedSuccess);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResults<List<Car>> (_carDal.GetAll(), Messages.ListedSuccess);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResults<Car> (_carDal.Get(c => c.Id == id), Messages.ListedSuccess);
        }

        public IDataResult<CarDetailDto> GetCarDetail(int id)
        {
            return new SuccessDataResults<CarDetailDto>(_carDal.GetCarDetail(id), Messages.ListedSuccess);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            return new SuccessDataResults<List<CarDetailDto>> (_carDal.GetCarDetails(),Messages.ListedSuccess);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.UpdateSuccess);
        }
    }
}
