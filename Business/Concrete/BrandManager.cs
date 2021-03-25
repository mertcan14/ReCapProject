using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
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

        [ValidationAspect(typeof(BrandValidator))]
        //[SecuredOperation("product.add,admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand entity)
        {
            _brandDal.Add(entity);
            return new SuccessResult(Messages.AddedSuccess);
        }
        [SecuredOperation("product.delete,admin")]
        public IResult Delete(int id)
        {
            _brandDal.Delete(_brandDal.Get(c => c.Id == id));
            return new SuccessResult(Messages.DeletedSuccess);
        }
        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResults<List<Brand>>(_brandDal.GetAll(), Messages.ListedSuccess);
        }
        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResults<Brand>(_brandDal.Get(c => c.Id == id), Messages.ListedSuccess);
        }
        [ValidationAspect(typeof(BrandValidator))]
        //[SecuredOperation("product.update,admin")]
        public IResult Update(Brand entity)
        {
            _brandDal.Update(entity);
            return new SuccessResult(Messages.UpdateSuccess);
        }
    }
}
