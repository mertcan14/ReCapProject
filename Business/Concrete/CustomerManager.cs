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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer entity)
        {
            _customerDal.Add(entity);
            return new SuccessResult(Messages.AddedSuccess);
        }

        public IResult Delete(int id)
        {
            _customerDal.Delete(_customerDal.Get(u => u.UserId == id));
            return new SuccessResult(Messages.DeletedSuccess);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResults<List<Customer>>(_customerDal.GetAll(), Messages.ListedSuccess);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResults<Customer>(_customerDal.Get(u => u.UserId == id), Messages.ListedSuccess);
        }

        public IResult Update(Customer entity)
        {
            _customerDal.Update(entity);
            return new SuccessResult(Messages.UpdateSuccess);
        }
    }
}
