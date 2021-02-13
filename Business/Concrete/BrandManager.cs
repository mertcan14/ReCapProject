using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand entity)
        {
            _brandDal.Add(entity);
            return new SuccessResult(Messages.AddedSuccess);
        }

        public IResult Delete(int id)
        {
            _brandDal.Delete(_brandDal.Get(c => c.Id == id));
            return new SuccessResult(Messages.DeletedSuccess);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResults<List<Brand>>(_brandDal.GetAll(), Messages.ListedSuccess);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResults<Brand>(_brandDal.Get(c => c.Id == id), Messages.ListedSuccess);
        }

        public IResult Update(Brand entity)
        {
            _brandDal.Update(entity);
            return new SuccessResult(Messages.UpdateSuccess);
        }
    }
}
