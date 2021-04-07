using Business.Abstract;
using Business.Constants;
using Core.Aspect.Autofac.Performance;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService ,ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user,claims.Data);
            return new SuccessDataResults<AccessToken>(accessToken, Messages.CreatedToken);
        }
        [PerformanceAspect(5)]
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResults<User>(Messages.NotFoundUser);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResults<User>(Messages.PasswordError);
            }
            return new SuccessDataResults<User>(userToCheck.Data, Messages.LoginSuccess);
        }
        [PerformanceAspect(5)]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatingPasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResults<User>(user, Messages.AddedSuccess);

        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByEmail(email).Data != null)
            {
                return new ErrorResult(Messages.UserAvailable);
            }
            return new SuccessResult();
        }

        public IResult ChangePassword(UserForLoginDto userForLoginDto)
        {
            var userToUpdate = _userService.GetByEmail(userForLoginDto.Email);
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatingPasswordHash(userForLoginDto.Password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                Id = userToUpdate.Data.Id,
                Email = userForLoginDto.Email,
                FirstName = userToUpdate.Data.FirstName,
                LastName = userToUpdate.Data.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.UpdatePassword(user);
            return new SuccessResult();
        }
    }
}
