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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color entity)
        {
            _colorDal.Add(entity);
            return new Result(true, Messages.AddedSuccess);
        }

        public IResult Delete(int id)
        {
            _colorDal.Delete(_colorDal.Get(c => c.Id == id));
            return new Result(true, Messages.DeletedSuccess);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResults<List<Color>>(_colorDal.GetAll(), Messages.ListedSuccess);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResults<Color> (_colorDal.Get(c => c.Id == id), Messages.ListedSuccess);
        }

        public IResult Update(Color entity)
        {
            _colorDal.Update(entity);
            return new Result(true, Messages.UpdateSuccess);
        }
    }
}
