using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, Context>, IUserOperationClaimDal
    {
        public UsersOperationClaimDto GetUserClaimDetails(int userID)
        {
            using (Context context = new Context())
            {
                var result = from us in context.UserOperationClaims.Where(u => u.UserId == userID)
                             join op in context.OperationClaims
                             on us.OperationClaimId equals op.Id
                             join user in context.Users
                             on us.UserId equals user.Id
                             
                             select new UsersOperationClaimDto
                             {
                                 Id = us.Id,
                                 ClaimName= (from us in context.UserOperationClaims join op in context.OperationClaims on us.OperationClaimId equals op.Id where us.UserId == user.Id select op.Name).ToArray(),
                                 Email = user.Email,
                                 UserId = user.Id
                             };
                return result.FirstOrDefault();

            }

        }
        public List<UsersOperationClaimDto> GetUsersClaimDetails(Expression<Func<UsersOperationClaimDto, bool>> filter = null)
        {
            using (Context context = new Context())
            {
                var result = from us in context.UserOperationClaims
                             join op in context.OperationClaims
                             on us.OperationClaimId equals op.Id
                             join user in context.Users
                             on us.UserId equals user.Id
                             select new UsersOperationClaimDto
                             {
                                 Email = user.Email,
                                 UserId = user.Id,
                                 ClaimName = (from us in context.UserOperationClaims join op in context.OperationClaims on us.OperationClaimId equals op.Id where us.UserId == user.Id select op.Name).ToArray(),
                             };
                return filter == null ? result.Distinct().ToList() : result.Distinct().Where(filter).ToList();


            }

        }
        public UserOperationClaim GetUserClaimDetailsByClaimName(int userID, string claimName)
        {
            using (Context context = new Context())
            {
                var result = from us in context.UserOperationClaims.Where(u => u.UserId == userID)
                             join op in context.OperationClaims
                             on us.OperationClaimId equals op.Id
                             join user in context.Users
                             on us.UserId equals user.Id
                             where op.Name == claimName
                             select new UserOperationClaim
                             {
                                 Id = us.Id,
                                 OperationClaimId=op.Id,
                                 UserId=user.Id
                             };
                return result.FirstOrDefault();

            }

        }
    }
}
