using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserOperationClaimDal : IEntityRepository<UserOperationClaim>
    {
        UsersOperationClaimDto GetUserClaimDetails(int userID);
        List<UsersOperationClaimDto> GetUsersClaimDetails(Expression<Func<UsersOperationClaimDto, bool>> filter = null);
        UserOperationClaim GetUserClaimDetailsByClaimName(int userID, string claimName);
    }
}
