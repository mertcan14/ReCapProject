using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IBlockedUserService _blockedUserService;

        public UserManager(IUserDal userDal, IBlockedUserService blockedUserService)
        {
            _userDal = userDal;
            _blockedUserService = blockedUserService;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.AddedSuccess);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccessDataResults<User> (_userDal.Get(u => u.Email == email), Messages.ListedSuccess);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResults<List<User>>(_userDal.GetAll(), Messages.ListedSuccess);
        }

        public IDataResult<List<UserInformation>> GetAllForManager()
        {
            return new SuccessDataResults<List<UserInformation>>(_userDal.GetAllForManager(), Messages.ListedSuccess);
        }

        public IDataResult<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<UserForRegisterDto> GetByIdDto(int id)
        {
            return new SuccessDataResults<UserForRegisterDto> (_userDal.GetById(id), Messages.ListedSuccess);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResults<List<OperationClaim>> (_userDal.GetClaims(user), Messages.ListedSuccess);
        }

        public IResult BlockingUser(int userId)
        {
            var user = _userDal.Get(u => u.Id == userId);
            BlockedUser blockedUser = new BlockedUser { Email = user.Email, FirstName = user.FirstName, LastName = user.LastName, PasswordHash = user.PasswordHash, PasswordSalt = user.PasswordSalt };
            _blockedUserService.Add(blockedUser);
            _userDal.Delete(user);
            return new SuccessResult(Messages.BlockedSuccess);
        }

        public IResult RemoveBlockingUser(int userId)
        {
            var user = _blockedUserService.GetById(userId);
            User removeBlockedUser = new User { Email = user.Data.Email, FirstName = user.Data.FirstName, LastName = user.Data.LastName, PasswordHash = user.Data.PasswordHash, PasswordSalt = user.Data.PasswordSalt, Status = true };
            _userDal.Add(removeBlockedUser);
            _blockedUserService.Delete(user.Data.Id);
            return new SuccessResult("Başarıyla Kaldırıldı");
        }

        public IResult Update(UserForRegisterDto userForRegisterDto)
        {
            var user = _userDal.Get(u => u.Id == userForRegisterDto.Id);
            user.FirstName = userForRegisterDto.FirstName;
            user.LastName = userForRegisterDto.LastName;
            user.Email = userForRegisterDto.Email;
            _userDal.Update(user);
            return new SuccessResult(Messages.UpdateSuccess);
        }

        public IResult UpdatePassword(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UpdateSuccess);
        }
    }
}
