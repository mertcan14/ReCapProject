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
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        [SecuredOperation("product.add,admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental entity)
        {
            var result = GetCarAvailab();
            foreach (var car in result.Data)
            {
                if (entity.CarId == car.Id)
                {
                    _rentalDal.Add(entity);
                    return new SuccessResult(Messages.AddedSuccess);
                    
                }
            }
            return new ErrorResult(Messages.AddedError);

        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<CarAvailable>> GetCarAvailab()
        {
            //return new SuccessDataResults<List<Rental>>(_rentalDal.GetAll(r => r.ReturnDate != null), Messages.ListedSuccess);
            

            return new SuccessDataResults<List<CarAvailable>>(_rentalDal.CarAvailab(), Messages.ListedSuccess);
        }


        [SecuredOperation("product.delete,admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(int id)
        {
            _rentalDal.Delete(_rentalDal.Get(u => u.Id == id));
            return new SuccessResult(Messages.DeletedSuccess);
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResults<List<Rental>>(_rentalDal.GetAll(), Messages.ListedSuccess);
        }

        [CacheAspect]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResults<Rental>(_rentalDal.Get(u => u.Id == id), Messages.ListedSuccess);
        }

        [ValidationAspect(typeof(RentalValidator))]
        [SecuredOperation("product.update,admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.UpdateSuccess);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResults<List<RentalDetailDto>>(_rentalDal.RentalDetails(), Messages.ListedSuccess);
        }
    }
}
