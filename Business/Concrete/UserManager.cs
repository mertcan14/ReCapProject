using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult(Messages.AddedSuccess);
        }

        public IResult Delete(int id)
        {
            _userDal.Delete(_userDal.Get(u => u.Id == id));
            return new SuccessResult(Messages.DeletedSuccess);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResults<List<User>>(_userDal.GetAll(), Messages.ListedSuccess);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResults<User>(_userDal.Get(u => u.Id == id), Messages.ListedSuccess);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult(Messages.UpdateSuccess);
        }
    }
}
