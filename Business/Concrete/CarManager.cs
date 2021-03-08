using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Validation;
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

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("product.add,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            
            _carDal.Add(car);
            return new SuccessResult("Başarı ile Eklendi.");

        }

        [SecuredOperation("product.delete,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(int id)
        {
            _carDal.Delete(_carDal.Get(c => c.Id == id));
            return new SuccessResult(Messages.AddedSuccess);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResults<List<Car>> (_carDal.GetAll(), Messages.ListedSuccess);
        }
        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResults<Car> (_carDal.Get(c => c.Id == id), Messages.ListedSuccess);
        }

        [PerformanceAspect(1)]
        public IDataResult<CarDetailDto> GetCarDetail(int id)
        {
            return new SuccessDataResults<CarDetailDto>(_carDal.GetCarDetail(id), Messages.ListedSuccess);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            return new SuccessDataResults<List<CarDetailDto>> (_carDal.GetCarDetails(),Messages.ListedSuccess);
        }

        [SecuredOperation("product.update,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.UpdateSuccess);
        }
    }
}
