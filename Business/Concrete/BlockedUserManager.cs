using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BlockedUserManager : IBlockedUserService
    {
        IBlockedUserDal _blockedUserDal;

        public BlockedUserManager(IBlockedUserDal blockedUserDal)
        {
            _blockedUserDal = blockedUserDal;
        }

        public IResult Add(BlockedUser entity)
        {
            entity.BlockingDate = DateTime.Now;
            _blockedUserDal.Add(entity);
            return new SuccessResult(Messages.BlockedSuccess);
        }

        public IResult Delete(int id)
        {
            var result = _blockedUserDal.Get(b => b.Id == id);
            _blockedUserDal.Delete(result);
            return new SuccessResult(Messages.BlockedDelete);
        }

        public IDataResult<List<BlockedUser>> GetAll()
        {
            return new SuccessDataResults<List<BlockedUser>>(_blockedUserDal.GetAll(), Messages.ListedSuccess);
        }

        public IDataResult<BlockedUser> GetById(int id)
        {
            return new SuccessDataResults<BlockedUser>(_blockedUserDal.Get(b => b.Id == id), Messages.ListedSuccess);
        }

        public IResult Update(BlockedUser entity)
        {
            _blockedUserDal.Update(entity);
            return new SuccessResult(Messages.UpdateSuccess);
        }
    }
}
