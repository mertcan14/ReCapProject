using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IResult Add(UserOperationClaim entity)
        {
            _userOperationClaimDal.Add(entity);
            return new SuccessResult(Messages.AddedSuccess);
        }

        public IResult Delete(int id)
        {
            var result = _userOperationClaimDal.Get(u => u.Id == id);
            _userOperationClaimDal.Delete(result);
            return new SuccessResult(Messages.DeletedSuccess);
        }

        public IResult DeleteByUserIdClaimName(int userId, string claimName)
        {
            var result = _userOperationClaimDal.GetUserClaimDetailsByClaimName(userId, claimName);
            _userOperationClaimDal.Delete(result);
            return new SuccessResult(Messages.DeletedSuccess);
        }

        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResults<List<UserOperationClaim>>(_userOperationClaimDal.GetAll(), Messages.ListedSuccess);
        }

        public IDataResult<UserOperationClaim> GetById(int id)
        {
            return new SuccessDataResults<UserOperationClaim>(_userOperationClaimDal.Get(u => u.Id == id), Messages.ListedSuccess);
        }

        public IResult Update(UserOperationClaim entity)
        {
            _userOperationClaimDal.Update(entity);
            return new SuccessResult(Messages.UpdateSuccess);
        }

        public IDataResult<UsersOperationClaimDto> UserOperationDetail(int userId)
        {
            return new SuccessDataResults<UsersOperationClaimDto>(_userOperationClaimDal.GetUserClaimDetails(userId), Messages.ListedSuccess);
        }

        public IDataResult<List<UsersOperationClaimDto>> UsersOperationDetail()
        {
            return new SuccessDataResults<List<UsersOperationClaimDto>>(_userOperationClaimDal.GetUsersClaimDetails(), Messages.ListedSuccess);
        }
    }
}
