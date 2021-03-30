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
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCard entity)
        {
            _creditCardDal.Add(entity);
            return new SuccessResult(Messages.AddedSuccess);
        }

        public IResult Delete(int id)
        {
            _creditCardDal.Delete(_creditCardDal.Get(c => c.Id == id));
            return new SuccessResult(Messages.DeletedSuccess);
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResults<List<CreditCard>>(_creditCardDal.GetAll(), Messages.ListedSuccess);
        }

        public IDataResult<CreditCard> GetById(int id)
        {
            return new SuccessDataResults<CreditCard>(_creditCardDal.Get(c => c.Id == id), Messages.ListedSuccess);
        }

        public IDataResult<List<CreditCard>> GetByUserId(int userId)
        {
            return new SuccessDataResults<List<CreditCard>>(_creditCardDal.GetAll(c => c.UserId == userId), Messages.ListedSuccess);
        }

        public IResult Update(CreditCard entity)
        {
            _creditCardDal.Update(entity);
            return new SuccessResult(Messages.UpdateSuccess);
        }
    }
}
