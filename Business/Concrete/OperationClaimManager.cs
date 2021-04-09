using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {

        IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }
        [SecuredOperation("admin")]
        public IResult Add(OperationClaim entity)
        {
            _operationClaimDal.Add(entity);
            return new SuccessResult(Messages.AddedSuccess);
        }
        [SecuredOperation("admin")]
        public IResult Delete(int id)
        {
            var result = _operationClaimDal.Get(o => o.Id == id);
            _operationClaimDal.Delete(result);
            return new SuccessResult(Messages.DeletedSuccess);
        }

        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResults<List<OperationClaim>>(_operationClaimDal.GetAll(), Messages.ListedSuccess);
        }

        public IDataResult<OperationClaim> GetById(int id)
        {
            return new SuccessDataResults<OperationClaim>(_operationClaimDal.Get(o => o.Id == id), Messages.ListedSuccess);
        }
        [SecuredOperation("admin")]
        public IResult Update(OperationClaim entity)
        {
            _operationClaimDal.Update(entity);
            return new SuccessResult(Messages.UpdateSuccess);
        }
    }
}
