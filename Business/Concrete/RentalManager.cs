using Business.Abstract;
using Business.Constants;
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
        List<Car> cars;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental entity)
        {
            var result = CarAvailab();
            foreach (var car in result.Data)
            {
                if (entity.CarId != car.Id)
                {
                    return new ErrorResult(Messages.AddedError);
                }
            }
            _rentalDal.Add(entity);
            return new SuccessResult(Messages.AddedSuccess);
        }

        public IDataResult<List<CarAvailable>> CarAvailab()
        {
            //return new SuccessDataResults<List<Rental>>(_rentalDal.GetAll(r => r.ReturnDate != null), Messages.ListedSuccess);
            

            return new SuccessDataResults<List<CarAvailable>>(_rentalDal.CarAvailab(), Messages.ListedSuccess);
        }

        public IResult Delete(int id)
        {
            _rentalDal.Delete(_rentalDal.Get(u => u.Id == id));
            return new SuccessResult(Messages.DeletedSuccess);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResults<List<Rental>>(_rentalDal.GetAll(), Messages.ListedSuccess);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResults<Rental>(_rentalDal.Get(u => u.Id == id), Messages.ListedSuccess);
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.UpdateSuccess);
        }
    }
}
