using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfOperationClaimsDal : EfEntityRepositoryBase<OperationClaim, CarDealershipContext>, IOperationClaimsDal
    {
    }
}
