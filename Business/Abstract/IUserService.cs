﻿using Core.Entities.Concrete;
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
        IDataResult<User> GetByEmail(string email);
        IDataResult<User> GetById(int id);
        IDataResult<UserForRegisterDto> GetByIdDto(int id);
        IResult Update(UserForRegisterDto userForRegisterDto);
        
    }
}
