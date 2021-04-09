using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        [SecuredOperation("productAdd,admin")]
        public IResult Add(Color entity)
        {
            _colorDal.Add(entity);
            return new Result(true, Messages.AddedSuccess);
        }

        [SecuredOperation("productDelete,admin")]
        public IResult Delete(int id)
        {
            _colorDal.Delete(_colorDal.Get(c => c.Id == id));
            return new Result(true, Messages.DeletedSuccess);
        }

        [PerformanceAspect(5)]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResults<List<Color>>(_colorDal.GetAll(), Messages.ListedSuccess);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResults<Color> (_colorDal.Get(c => c.Id == id), Messages.ListedSuccess);
        }

        [ValidationAspect(typeof(ColorValidator))]
        [SecuredOperation("productUpdate,admin")]
        public IResult Update(Color entity)
        {
            _colorDal.Update(entity);
            return new Result(true, Messages.UpdateSuccess);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Color entity)
        {
            Add(entity);
            if (entity.ColorName.Length < 10)
            {
                throw new Exception("");
            }
            entity.Id += 1;
            entity.ColorName = "asdasd";
            Add(entity);
            return null;
        }
    }
}
