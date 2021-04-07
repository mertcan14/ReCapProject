using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserOperationClaimService : IEntityService<UserOperationClaim>
    {
        IDataResult<UsersOperationClaimDto> UserOperationDetail(int userId);
        IDataResult<List<UsersOperationClaimDto>> UsersOperationDetail();
        IResult DeleteByUserIdClaimName(int userId, string claimName);
    }
}
