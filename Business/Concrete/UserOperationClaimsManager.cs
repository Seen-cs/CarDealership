using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserOperationClaimsManager : IUserOperationClaimService
    {
        IUserOperationClaimsDal _userOperationClaimsDal;
        public UserOperationClaimsManager(IUserOperationClaimsDal userOperationClaimsDal)
        {
            _userOperationClaimsDal = userOperationClaimsDal;
        }
        public IResult Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimsDal.Add(userOperationClaim);
            return new SuccessResult();
        }
    }
}
