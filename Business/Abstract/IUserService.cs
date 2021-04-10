using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult Add(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByEmail(string email);
        IDataResult<User> GetById(int id);
        IDataResult<UserForRegisterDto> GetByIdDto(int id);
        IResult Update(UserForRegisterDto userForRegisterDto);
        IResult UpdatePassword(User user);
        IResult BlockingUser(int userId);
        IResult RemoveBlockingUser(int userId);
        IDataResult<List<UserInformation>> GetAllForManager();


    }
}
